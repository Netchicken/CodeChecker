namespace CodeChecker
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
            this.btnRnPlagCheck = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lbxOutput = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxHTML = new System.Windows.Forms.CheckBox();
            this.cbxJS = new System.Windows.Forms.CheckBox();
            this.cbxCSS = new System.Windows.Forms.CheckBox();
            this.cbxCS = new System.Windows.Forms.CheckBox();
            this.cbxContains = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLevSize = new System.Windows.Forms.TextBox();
            this.btnOpenDirectory = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbxSameFolder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRnPlagCheck
            // 
            this.btnRnPlagCheck.Enabled = false;
            this.btnRnPlagCheck.Location = new System.Drawing.Point(3, 397);
            this.btnRnPlagCheck.Name = "btnRnPlagCheck";
            this.btnRnPlagCheck.Size = new System.Drawing.Size(314, 178);
            this.btnRnPlagCheck.TabIndex = 0;
            this.btnRnPlagCheck.Text = "Check Files";
            this.btnRnPlagCheck.UseVisualStyleBackColor = true;
            this.btnRnPlagCheck.Click += new System.EventHandler(this.BtnPlagarism_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // lbxOutput
            // 
            this.lbxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxOutput.FormattingEnabled = true;
            this.lbxOutput.HorizontalScrollbar = true;
            this.lbxOutput.ItemHeight = 42;
            this.lbxOutput.Location = new System.Drawing.Point(0, 0);
            this.lbxOutput.Name = "lbxOutput";
            this.lbxOutput.Size = new System.Drawing.Size(2334, 1152);
            this.lbxOutput.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.lbxOutput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(2646, 1152);
            this.splitContainer1.SplitterDistance = 2334;
            this.splitContainer1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cbxHTML);
            this.flowLayoutPanel2.Controls.Add(this.cbxJS);
            this.flowLayoutPanel2.Controls.Add(this.cbxCSS);
            this.flowLayoutPanel2.Controls.Add(this.cbxCS);
            this.flowLayoutPanel2.Controls.Add(this.cbxContains);
            this.flowLayoutPanel2.Controls.Add(this.cbxSameFolder);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 1052);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(2334, 100);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // cbxHTML
            // 
            this.cbxHTML.AutoSize = true;
            this.cbxHTML.Location = new System.Drawing.Point(3, 3);
            this.cbxHTML.Name = "cbxHTML";
            this.cbxHTML.Size = new System.Drawing.Size(169, 48);
            this.cbxHTML.TabIndex = 0;
            this.cbxHTML.Text = "HTML";
            this.cbxHTML.UseVisualStyleBackColor = true;
            this.cbxHTML.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // cbxJS
            // 
            this.cbxJS.AutoSize = true;
            this.cbxJS.Location = new System.Drawing.Point(178, 3);
            this.cbxJS.Name = "cbxJS";
            this.cbxJS.Size = new System.Drawing.Size(110, 48);
            this.cbxJS.TabIndex = 1;
            this.cbxJS.Text = "JS";
            this.cbxJS.UseVisualStyleBackColor = true;
            this.cbxJS.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // cbxCSS
            // 
            this.cbxCSS.AutoSize = true;
            this.cbxCSS.Location = new System.Drawing.Point(294, 3);
            this.cbxCSS.Name = "cbxCSS";
            this.cbxCSS.Size = new System.Drawing.Size(143, 48);
            this.cbxCSS.TabIndex = 2;
            this.cbxCSS.Text = "CSS";
            this.cbxCSS.UseVisualStyleBackColor = true;
            this.cbxCSS.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // cbxCS
            // 
            this.cbxCS.AutoSize = true;
            this.cbxCS.Location = new System.Drawing.Point(443, 3);
            this.cbxCS.Name = "cbxCS";
            this.cbxCS.Size = new System.Drawing.Size(194, 48);
            this.cbxCS.TabIndex = 3;
            this.cbxCS.Text = "CSharp";
            this.cbxCS.UseVisualStyleBackColor = true;
            this.cbxCS.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // cbxContains
            // 
            this.cbxContains.AutoSize = true;
            this.cbxContains.Location = new System.Drawing.Point(643, 3);
            this.cbxContains.Name = "cbxContains";
            this.cbxContains.Size = new System.Drawing.Size(307, 48);
            this.cbxContains.TabIndex = 5;
            this.cbxContains.Text = "Contains Files";
            this.cbxContains.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.cbxContains.UseVisualStyleBackColor = true;
            this.cbxContains.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtLevSize);
            this.flowLayoutPanel1.Controls.Add(this.btnOpenDirectory);
            this.flowLayoutPanel1.Controls.Add(this.btnRnPlagCheck);
            this.flowLayoutPanel1.Controls.Add(this.btnPrint);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(308, 1152);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 132);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set match number - smaller is closer";
            // 
            // txtLevSize
            // 
            this.txtLevSize.Location = new System.Drawing.Point(3, 135);
            this.txtLevSize.Name = "txtLevSize";
            this.txtLevSize.Size = new System.Drawing.Size(348, 49);
            this.txtLevSize.TabIndex = 4;
            this.txtLevSize.Text = "300";
            // 
            // btnOpenDirectory
            // 
            this.btnOpenDirectory.Enabled = false;
            this.btnOpenDirectory.Location = new System.Drawing.Point(3, 190);
            this.btnOpenDirectory.Name = "btnOpenDirectory";
            this.btnOpenDirectory.Size = new System.Drawing.Size(314, 201);
            this.btnOpenDirectory.TabIndex = 2;
            this.btnOpenDirectory.Text = "Open Folder";
            this.btnOpenDirectory.UseVisualStyleBackColor = true;
            this.btnOpenDirectory.Click += new System.EventHandler(this.BtnOpenDirectory_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(3, 581);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(314, 201);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print to File";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // cbxSameFolder
            // 
            this.cbxSameFolder.AutoSize = true;
            this.cbxSameFolder.Location = new System.Drawing.Point(956, 3);
            this.cbxSameFolder.Name = "cbxSameFolder";
            this.cbxSameFolder.Size = new System.Drawing.Size(284, 48);
            this.cbxSameFolder.TabIndex = 6;
            this.cbxSameFolder.Text = "Same Folder";
            this.cbxSameFolder.UseVisualStyleBackColor = true;
            this.cbxSameFolder.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2646, 1152);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Garys Awesome Plagarism Checker";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRnPlagCheck;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ListBox lbxOutput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOpenDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLevSize;
        private System.Windows.Forms.CheckBox cbxContains;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox cbxHTML;
        private System.Windows.Forms.CheckBox cbxJS;
        private System.Windows.Forms.CheckBox cbxCSS;
        private System.Windows.Forms.CheckBox cbxCS;
        private System.Windows.Forms.CheckBox cbxSameFolder;
    }
}

