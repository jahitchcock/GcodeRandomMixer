
namespace GcodeRandomMixer
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_originalFile = new System.Windows.Forms.TextBox();
            this.btn_fileBrowser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_extruders = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original Gcode File";
            // 
            // txt_originalFile
            // 
            this.txt_originalFile.Location = new System.Drawing.Point(20, 33);
            this.txt_originalFile.Name = "txt_originalFile";
            this.txt_originalFile.Size = new System.Drawing.Size(290, 20);
            this.txt_originalFile.TabIndex = 1;
            // 
            // btn_fileBrowser
            // 
            this.btn_fileBrowser.Location = new System.Drawing.Point(235, 59);
            this.btn_fileBrowser.Name = "btn_fileBrowser";
            this.btn_fileBrowser.Size = new System.Drawing.Size(75, 23);
            this.btn_fileBrowser.TabIndex = 2;
            this.btn_fileBrowser.Text = "File Browser";
            this.btn_fileBrowser.UseVisualStyleBackColor = true;
            this.btn_fileBrowser.Click += new System.EventHandler(this.btn_fileBrowser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Extruders";
            // 
            // cmb_extruders
            // 
            this.cmb_extruders.FormattingEnabled = true;
            this.cmb_extruders.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmb_extruders.Location = new System.Drawing.Point(121, 61);
            this.cmb_extruders.Name = "cmb_extruders";
            this.cmb_extruders.Size = new System.Drawing.Size(59, 21);
            this.cmb_extruders.TabIndex = 4;
            this.cmb_extruders.Text = "3";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(20, 147);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(144, 61);
            this.btn_submit.TabIndex = 5;
            this.btn_submit.Text = "Generate Random Mix";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Text to Search";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(20, 108);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(290, 20);
            this.txt_Search.TabIndex = 7;
            this.txt_Search.Text = ";LAYER:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 226);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.cmb_extruders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_fileBrowser);
            this.Controls.Add(this.txt_originalFile);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Random Gcode Mix Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_originalFile;
        private System.Windows.Forms.Button btn_fileBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_extruders;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

