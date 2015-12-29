namespace FlatFileClassGenerator
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chosenFilenameTextBox = new System.Windows.Forms.TextBox();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.pickFileButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.namespaceTextBox = new System.Windows.Forms.TextBox();
            this.namespaceLabel = new System.Windows.Forms.Label();
            this.openOutputDirectoryButton = new System.Windows.Forms.Button();
            this.classNameLabel = new System.Windows.Forms.Label();
            this.classNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chosenFilenameTextBox
            // 
            this.chosenFilenameTextBox.Location = new System.Drawing.Point(105, 12);
            this.chosenFilenameTextBox.Name = "chosenFilenameTextBox";
            this.chosenFilenameTextBox.Size = new System.Drawing.Size(314, 22);
            this.chosenFilenameTextBox.TabIndex = 0;
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(12, 15);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(69, 17);
            this.filenameLabel.TabIndex = 1;
            this.filenameLabel.Text = "Filename:";
            // 
            // pickFileButton
            // 
            this.pickFileButton.Location = new System.Drawing.Point(425, 12);
            this.pickFileButton.Name = "pickFileButton";
            this.pickFileButton.Size = new System.Drawing.Size(75, 23);
            this.pickFileButton.TabIndex = 1;
            this.pickFileButton.Text = "Browse";
            this.pickFileButton.UseVisualStyleBackColor = true;
            this.pickFileButton.Click += new System.EventHandler(this.pickFileButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(12, 109);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(89, 43);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Generate!";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // namespaceTextBox
            // 
            this.namespaceTextBox.Location = new System.Drawing.Point(105, 40);
            this.namespaceTextBox.Name = "namespaceTextBox";
            this.namespaceTextBox.Size = new System.Drawing.Size(314, 22);
            this.namespaceTextBox.TabIndex = 2;
            // 
            // namespaceLabel
            // 
            this.namespaceLabel.AutoSize = true;
            this.namespaceLabel.Location = new System.Drawing.Point(12, 43);
            this.namespaceLabel.Name = "namespaceLabel";
            this.namespaceLabel.Size = new System.Drawing.Size(87, 17);
            this.namespaceLabel.TabIndex = 5;
            this.namespaceLabel.Text = "Namespace:";
            // 
            // openOutputDirectoryButton
            // 
            this.openOutputDirectoryButton.Location = new System.Drawing.Point(107, 109);
            this.openOutputDirectoryButton.Name = "openOutputDirectoryButton";
            this.openOutputDirectoryButton.Size = new System.Drawing.Size(97, 43);
            this.openOutputDirectoryButton.TabIndex = 5;
            this.openOutputDirectoryButton.Text = "Open output directory";
            this.openOutputDirectoryButton.UseVisualStyleBackColor = true;
            this.openOutputDirectoryButton.Click += new System.EventHandler(this.openOutputDirectoryButton_Click);
            // 
            // classNameLabel
            // 
            this.classNameLabel.AutoSize = true;
            this.classNameLabel.Location = new System.Drawing.Point(12, 71);
            this.classNameLabel.Name = "classNameLabel";
            this.classNameLabel.Size = new System.Drawing.Size(46, 17);
            this.classNameLabel.TabIndex = 8;
            this.classNameLabel.Text = "Class:";
            // 
            // classNameTextBox
            // 
            this.classNameTextBox.Location = new System.Drawing.Point(105, 68);
            this.classNameTextBox.Name = "classNameTextBox";
            this.classNameTextBox.Size = new System.Drawing.Size(314, 22);
            this.classNameTextBox.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 163);
            this.Controls.Add(this.classNameLabel);
            this.Controls.Add(this.classNameTextBox);
            this.Controls.Add(this.openOutputDirectoryButton);
            this.Controls.Add(this.namespaceLabel);
            this.Controls.Add(this.namespaceTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.pickFileButton);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.chosenFilenameTextBox);
            this.Name = "Main";
            this.Text = "Flat File Class Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox chosenFilenameTextBox;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.Button pickFileButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox namespaceTextBox;
        private System.Windows.Forms.Label namespaceLabel;
        private System.Windows.Forms.Button openOutputDirectoryButton;
        private System.Windows.Forms.Label classNameLabel;
        private System.Windows.Forms.TextBox classNameTextBox;
    }
}

