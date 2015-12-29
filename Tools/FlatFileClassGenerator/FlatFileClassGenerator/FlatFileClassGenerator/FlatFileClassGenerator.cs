using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace FlatFileClassGenerator
{
    public class FlatFileClassGenerator
    {
        private static readonly Regex CamalCaseWordCapturingRegex = new Regex(@"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))");

        public void Generate(string flatFileLocation, string destinationFile, string @namespace, string className)
        {
            using (var outputWriter = new StreamWriter(File.Open(destinationFile, FileMode.Create)))
            using (new ClassHeaderWriter(outputWriter, @namespace, className))
            {
                ProcessWorkbook(outputWriter, flatFileLocation);
            }
        }

        private static void ProcessWorkbook(TextWriter outputWriter, string flatFileLocation)
        {
            Application excelApplication = null;
            Workbook excelBook = null;
            Worksheet excelSheet = null;

            try
            {
                excelApplication = new Application { Visible = false };
                excelBook = excelApplication.Workbooks.Open(flatFileLocation);
                excelSheet = (Worksheet)excelBook.Sheets[1];
                var lastRow = excelSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;

                int totalLength = 0;

                for (var rowIndex = 5; rowIndex <= lastRow; rowIndex++)
                {
                    var cellValues = (Array)excelSheet.Range["A" + rowIndex, "K" + rowIndex].Cells.Value;
                    var propertyData = cellValues.Cast<object>().Select(v => v == null ? null : v.ToString()).ToArray();
                    totalLength = totalLength + GetFieldLength(propertyData[4]);
                    ProcessProperty(outputWriter, propertyData);
                }

                string fileLengthProperty =  @"public int TotalFileLength { get { return " + totalLength + @"; } }";
                outputWriter.WriteLine(fileLengthProperty);

            }
            finally
            {
                if (excelApplication != null) excelApplication.Quit();

                if (excelSheet != null) { Marshal.ReleaseComObject(excelSheet); }
                if (excelBook != null) { Marshal.ReleaseComObject(excelBook); }
                if (excelApplication != null) { Marshal.ReleaseComObject(excelApplication); }
            }
        }

        private static void ProcessProperty(TextWriter outputWriter, IList<string> propertyData)
        {
            if (propertyData[4] == "INTYPE")
            {
                return;
            }

            var index = propertyData[0];
            var name = GetName(propertyData[2], propertyData[6]);
            var propertyName = SanitizeName(name);
            var variableName = GetVariableName(propertyName);
            var type = GetType(propertyData[4]);
            var fixedFieldLength = GetFieldLength(propertyData[4]);
            var usedByNewBalance = propertyData.Count > 9 && GetUsedByNewBalance(propertyData[9]);
            var comments = propertyData.Count > 10 ? propertyData[10] : null;
            var padDirection = type == "string" ? "Right" : "Left";
            var padCharacter = type == "string" ? " " : "0";

            if (usedByNewBalance)
            {
                outputWriter.WriteLine("        // Used by New Balance");
            }

            if (!string.IsNullOrWhiteSpace(comments))
            {
                outputWriter.WriteLine("        // " + Regex.Replace(comments, @"\r\n?|\n", Environment.NewLine + "        // "));
            }

            var nullAttributeString = string.Format(", NullValue=\"{0}\"", GetNullValueString(fixedFieldLength, type));

            if (type == "decimal")
            {
                var decimalMultiplier = string.Format("1{0}.0", new String('0', GetDecimalPlaces(propertyData[4])));
                var backingPropertyName = propertyName + "_Backing";
                var backingType = GetIntegerType(propertyData[4]);

                outputWriter.WriteLine("        private {1} {0};", variableName, backingType);
                outputWriter.WriteLine("        [FixedLengthField({0}, {1}, PaddingChar = '{3}', Padding = Padding.{2}{4})]", index, fixedFieldLength, padDirection, padCharacter, nullAttributeString);
                outputWriter.WriteLine("        public {1} {0}", backingPropertyName, backingType);
                outputWriter.WriteLine("        {");
                outputWriter.WriteLine("            get {1} return {0}; {2}", variableName, "{", "}");
                outputWriter.WriteLine("            set");
                outputWriter.WriteLine("            {");
                outputWriter.WriteLine("                if(value != default(decimal) &&  value{1}.Length > {0}) throw new ArgumentOutOfRangeException(\"value\");", fixedFieldLength, type == "string" ? "" : ".ToString(CultureInfo.InvariantCulture)");
                outputWriter.WriteLine("                {0} = value;", variableName);
                outputWriter.WriteLine("            }");
                outputWriter.WriteLine("        }");
                outputWriter.WriteLine("        public decimal {0}", propertyName);
                outputWriter.WriteLine("        {");
                outputWriter.WriteLine("            get {1} return {0} / {3}m; {2}", backingPropertyName, "{", "}", decimalMultiplier);
                outputWriter.WriteLine("            set {1} {0} = (int)(value * {3}m); {2}", backingPropertyName, "{", "}", decimalMultiplier);
                outputWriter.WriteLine("        }");
            }
            else
            {
             
                outputWriter.WriteLine("        private {0} {1};", type, variableName);
                outputWriter.WriteLine("        [FixedLengthField({0}, {1}, PaddingChar = '{3}', Padding = Padding.{2}{4})]", index, fixedFieldLength, padDirection, padCharacter, nullAttributeString);
                outputWriter.WriteLine("        public {0} {1}", type, propertyName);
                outputWriter.WriteLine("        {");
                outputWriter.WriteLine("            get {1} return {0}; {2}", variableName, "{", "}");
                outputWriter.WriteLine("            set");
                outputWriter.WriteLine("            {");
                outputWriter.WriteLine("                if(value != default({2}) && value{1}.Length > {0}) throw new ArgumentOutOfRangeException(\"value\");", fixedFieldLength, type == "string" ? "" : ".ToString(CultureInfo.InvariantCulture)", type);
                outputWriter.WriteLine("                {0} = value;", variableName);
                outputWriter.WriteLine("            }");
                outputWriter.WriteLine("        }");
            }

            outputWriter.WriteLine();
        }

        private static string GetName(string descriptiveName, string technicalName)
        {
            if (!string.IsNullOrWhiteSpace(technicalName)
                && !string.Equals("N/A", technicalName, StringComparison.InvariantCultureIgnoreCase))
            {
                var lastPart = technicalName.Split(new[] { '/' }, StringSplitOptions.None).Last();
                return CamalCaseWordCapturingRegex.Replace(lastPart, " $0");
            }

            return descriptiveName;
        }

        private static string GetVariableName(string propertyName)
        {
            return "_" + propertyName.Substring(0, 1).ToLowerInvariant() + propertyName.Substring(1);
        }

        private static bool GetUsedByNewBalance(string s)
        {
            return string.Equals("YES", s, StringComparison.InvariantCultureIgnoreCase);
        }

        private static int GetFieldLength(string data)
        {
            return int.Parse(new string(data.TakeWhile(Char.IsDigit).ToArray()));
        }

        private static string GetType(string data)
        {
            var type = new string(data.SkipWhile(Char.IsDigit).TakeWhile(Char.IsLetter).ToArray());

            switch (type)
            {
                case "S":
                    var decimalPlaces = GetDecimalPlaces(data);
                    if (decimalPlaces > 0)
                    {
                        return "decimal";
                    }

                    return GetIntegerType(data);

                case "A":
                    return "string";

                default:
                    throw new ArgumentException("Could not determine type for " + data);
            }
        }

        private static string GetIntegerType(string data)
        {
            var length = GetFieldLength(data);
            if (length <= 9)
            {
                return "int";
            }
            return "long";
        }

        private static int GetDecimalPlaces(string data)
        {
            var decimalPlacesString = new string(data.SkipWhile(char.IsDigit).SkipWhile(char.IsLetter).ToArray());
            var decimalPlaces = int.Parse(decimalPlacesString);
            return decimalPlaces;
        }

        private static string SanitizeName(string data)
        {
            var sanitized = Regex.Replace(data, "#", "Number");
            sanitized = Regex.Replace(sanitized, "[^0-9a-zA-Z ]", "");
            sanitized = Regex.Replace(sanitized, @"\bSpcl\b", "Special", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bPkt\b", "Pickticket", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bCtl\b", "Control", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bNbr\b", "Number", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bRcd\b", "Record", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bID\b", "Id", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bSeq\b", "Sequence", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bInstr\b", "Instruction", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bQty\b", "Quantity", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bRec\b", "Record", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bDesc\b", "Description", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bRef\b", "Reference", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bSched\b", "Scheduled", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bDlvry\b", "Delivery", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bAddr\b", "Address", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bSfx\b", "Suffix", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bOrig\b", "Original", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bPpk\b", "Prepack", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bPpack\b", "Prepack", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bMisc\b", "Miscellaneous", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bCust\b", "Customer", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bAcct\b", "Account", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bDept\b", "Department", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bPo\b", "Purchase Order", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bMerch\b", "Merchandise", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bDiv\b", "Division", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bDtl\b", "Detail", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bDisc\b", "Discount", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bCurr\b", "Currency", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bGen\b", "General", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bDocs\b", "Documents", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bSpecl\b", "Special", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bWhse\b", "Warehouse", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bAttr\b", "Attribute", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bCtrl\b", "Control", RegexOptions.IgnoreCase);
            sanitized = Regex.Replace(sanitized, @"\bLen\b", "Length", RegexOptions.IgnoreCase);

            var capitalized = Regex.Replace(sanitized.ToLowerInvariant(), @"\b.", m => m.Value.ToUpperInvariant());
            return capitalized.Replace(" ", "");
        }

        private static string GetNullValueString(int fixedFieldLength, string type)
        {
            if (type == "string")
            {
                return new String(' ', fixedFieldLength);
            }
            else
            {
                return new string('0', fixedFieldLength);
            }
        }
    }
}
