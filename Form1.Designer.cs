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
            this.btnPlagarism = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lbxOutput = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLevSize = new System.Windows.Forms.TextBox();
            this.btnOpenDirectory = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbxContains = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlagarism
            // 
            this.btnPlagarism.Location = new System.Drawing.Point(3, 616);
            this.btnPlagarism.Name = "btnPlagarism";
            this.btnPlagarism.Size = new System.Drawing.Size(314, 178);
            this.btnPlagarism.TabIndex = 0;
            this.btnPlagarism.Text = "Check Files";
            this.btnPlagarism.UseVisualStyleBackColor = true;
            this.btnPlagarism.Click += new System.EventHandler(this.BtnPlagarism_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.lbxOutput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(2646, 1152);
            this.splitContainer1.SplitterDistance = 2334;
            this.splitContainer1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtLevSize);
            this.flowLayoutPanel1.Controls.Add(this.cbxContains);
            this.flowLayoutPanel1.Controls.Add(this.btnOpenDirectory);
            this.flowLayoutPanel1.Controls.Add(this.btnPlagarism);
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
            this.btnOpenDirectory.Location = new System.Drawing.Point(3, 409);
            this.btnOpenDirectory.Name = "btnOpenDirectory";
            this.btnOpenDirectory.Size = new System.Drawing.Size(314, 201);
            this.btnOpenDirectory.TabIndex = 2;
            this.btnOpenDirectory.Text = "Open Folder";
            this.btnOpenDirectory.UseVisualStyleBackColor = true;
            this.btnOpenDirectory.Click += new System.EventHandler(this.BtnOpenDirectory_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(3, 800);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(314, 201);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print to File";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // cbxContains
            // 
            this.cbxContains.Location = new System.Drawing.Point(3, 190);
            this.cbxContains.Name = "cbxContains";
            this.cbxContains.Size = new System.Drawing.Size(293, 213);
            this.cbxContains.TabIndex = 5;
            this.cbxContains.Text = "Include Where one file contains another file";
            this.cbxContains.UseVisualStyleBackColor = true;
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
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlagarism;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ListBox lbxOutput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOpenDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLevSize;
        private System.Windows.Forms.CheckBox cbxContains;
    }
}

