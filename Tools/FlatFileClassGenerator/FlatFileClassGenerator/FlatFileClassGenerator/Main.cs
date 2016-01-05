using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FlatFileClassGenerator
{
    public partial class Main : Form
    {
        private const string OutputDirectory = "Output";
        
        public Main()
        {
            InitializeComponent();
        }

        private void pickFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = "Excel workbooks (.xlsx, .xls)|*.xlsx;*.xls" };
            var result = openFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                chosenFilenameTextBox.Text = openFileDialog.FileName;
            }
        }

        private void openOutputDirectoryButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(OutputDirectory))
            {
                Directory.CreateDirectory(OutputDirectory);
            }

            Process.Start(OutputDirectory);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            var generator = new FlatFileClassGenerator( Convert.ToInt32(textDataRowStart.Text));

            if (string.IsNullOrWhiteSpace(chosenFilenameTextBox.Text))
            {
                MessageBox.Show(this, "File is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(namespaceTextBox.Text))
            {
                MessageBox.Show(this, "Namespace is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(classNameTextBox.Text))
            {
                MessageBox.Show(this, "Class name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            generator.GenerateGeneratedModel(chosenFilenameTextBox.Text, 
                                              Path.Combine(OutputDirectory, classNameTextBox.Text + ".cs"), 
                                              namespaceTextBox.Text, 
                                              classNameTextBox.Text);

            if (generateTableScriptCheckbox.Checked)
            {
                generator.GenerateTableScript(chosenFilenameTextBox.Text,
                                         Path.Combine(OutputDirectory, "TableScript_" + classNameTextBox.Text + ".cs"),
                                         classNameTextBox.Text);
            }
        }
    }
}
