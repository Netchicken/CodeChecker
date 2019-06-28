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
            this.components = new System.ComponentModel.Container();
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
            this.cbxSameFolder = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLevSize = new System.Windows.Forms.TextBox();
            this.btnOpenDirectory = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblMemory = new System.Windows.Forms.Label();
            this.lblRamCounter = new System.Windows.Forms.Label();
            this.lblCPU = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.cbxGuid = new System.Windows.Forms.CheckBox();
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
            this.btnRnPlagCheck.Location = new System.Drawing.Point(1, 127);
            this.btnRnPlagCheck.Margin = new System.Windows.Forms.Padding(1);
            this.btnRnPlagCheck.Name = "btnRnPlagCheck";
            this.btnRnPlagCheck.Size = new System.Drawing.Size(86, 55);
            this.btnRnPlagCheck.TabIndex = 0;
            this.btnRnPlagCheck.Text = "Check Files";
            this.btnRnPlagCheck.UseVisualStyleBackColor = true;
            this.btnRnPlagCheck.Click += new System.EventHandler(this.BtnPlagarism_Click);
            this.btnRnPlagCheck.MouseHover += new System.EventHandler(this.BtnRnPlagCheck_MouseHover);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // lbxOutput
            // 
            this.lbxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOutput.FormattingEnabled = true;
            this.lbxOutput.HorizontalScrollbar = true;
            this.lbxOutput.ItemHeight = 16;
            this.lbxOutput.Location = new System.Drawing.Point(0, 0);
            this.lbxOutput.Margin = new System.Windows.Forms.Padding(1);
            this.lbxOutput.Name = "lbxOutput";
            this.lbxOutput.Size = new System.Drawing.Size(635, 362);
            this.lbxOutput.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1);
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
            this.splitContainer1.Size = new System.Drawing.Size(722, 362);
            this.splitContainer1.SplitterDistance = 635;
            this.splitContainer1.SplitterWidth = 1;
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
            this.flowLayoutPanel2.Controls.Add(this.cbxGuid);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 331);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(635, 31);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // cbxHTML
            // 
            this.cbxHTML.AutoSize = true;
            this.cbxHTML.Location = new System.Drawing.Point(1, 1);
            this.cbxHTML.Margin = new System.Windows.Forms.Padding(1);
            this.cbxHTML.Name = "cbxHTML";
            this.cbxHTML.Size = new System.Drawing.Size(56, 17);
            this.cbxHTML.TabIndex = 0;
            this.cbxHTML.Text = "HTML";
            this.cbxHTML.UseVisualStyleBackColor = true;
            this.cbxHTML.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // cbxJS
            // 
            this.cbxJS.AutoSize = true;
            this.cbxJS.Location = new System.Drawing.Point(59, 1);
            this.cbxJS.Margin = new System.Windows.Forms.Padding(1);
            this.cbxJS.Name = "cbxJS";
            this.cbxJS.Size = new System.Drawing.Size(38, 17);
            this.cbxJS.TabIndex = 1;
            this.cbxJS.Text = "JS";
            this.cbxJS.UseVisualStyleBackColor = true;
            this.cbxJS.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // cbxCSS
            // 
            this.cbxCSS.AutoSize = true;
            this.cbxCSS.Location = new System.Drawing.Point(99, 1);
            this.cbxCSS.Margin = new System.Windows.Forms.Padding(1);
            this.cbxCSS.Name = "cbxCSS";
            this.cbxCSS.Size = new System.Drawing.Size(47, 17);
            this.cbxCSS.TabIndex = 2;
            this.cbxCSS.Text = "CSS";
            this.cbxCSS.UseVisualStyleBackColor = true;
            this.cbxCSS.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // cbxCS
            // 
            this.cbxCS.AutoSize = true;
            this.cbxCS.Location = new System.Drawing.Point(148, 1);
            this.cbxCS.Margin = new System.Windows.Forms.Padding(1);
            this.cbxCS.Name = "cbxCS";
            this.cbxCS.Size = new System.Drawing.Size(61, 17);
            this.cbxCS.TabIndex = 3;
            this.cbxCS.Text = "CSharp";
            this.cbxCS.UseVisualStyleBackColor = true;
            this.cbxCS.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // cbxContains
            // 
            this.cbxContains.AutoSize = true;
            this.cbxContains.Location = new System.Drawing.Point(211, 1);
            this.cbxContains.Margin = new System.Windows.Forms.Padding(1);
            this.cbxContains.Name = "cbxContains";
            this.cbxContains.Size = new System.Drawing.Size(91, 17);
            this.cbxContains.TabIndex = 5;
            this.cbxContains.Text = "Contains Files";
            this.cbxContains.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.cbxContains.UseVisualStyleBackColor = true;
            this.cbxContains.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            this.cbxContains.MouseHover += new System.EventHandler(this.CbxContains_MouseHover);
            // 
            // cbxSameFolder
            // 
            this.cbxSameFolder.AutoSize = true;
            this.cbxSameFolder.Location = new System.Drawing.Point(304, 1);
            this.cbxSameFolder.Margin = new System.Windows.Forms.Padding(1);
            this.cbxSameFolder.Name = "cbxSameFolder";
            this.cbxSameFolder.Size = new System.Drawing.Size(85, 17);
            this.cbxSameFolder.TabIndex = 6;
            this.cbxSameFolder.Text = "Same Folder";
            this.cbxSameFolder.UseVisualStyleBackColor = true;
            this.cbxSameFolder.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            this.cbxSameFolder.MouseHover += new System.EventHandler(this.CbxSameFolder_MouseHover);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtLevSize);
            this.flowLayoutPanel1.Controls.Add(this.btnOpenDirectory);
            this.flowLayoutPanel1.Controls.Add(this.btnRnPlagCheck);
            this.flowLayoutPanel1.Controls.Add(this.btnPrint);
            this.flowLayoutPanel1.Controls.Add(this.lblMemory);
            this.flowLayoutPanel1.Controls.Add(this.lblRamCounter);
            this.flowLayoutPanel1.Controls.Add(this.lblCPU);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(86, 362);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set match number - smaller is closer";
            // 
            // txtLevSize
            // 
            this.txtLevSize.Location = new System.Drawing.Point(1, 40);
            this.txtLevSize.Margin = new System.Windows.Forms.Padding(1);
            this.txtLevSize.Name = "txtLevSize";
            this.txtLevSize.Size = new System.Drawing.Size(98, 20);
            this.txtLevSize.TabIndex = 4;
            this.txtLevSize.Text = "300";
            this.txtLevSize.MouseHover += new System.EventHandler(this.TxtLevSize_MouseHover);
            // 
            // btnOpenDirectory
            // 
            this.btnOpenDirectory.Enabled = false;
            this.btnOpenDirectory.Location = new System.Drawing.Point(1, 62);
            this.btnOpenDirectory.Margin = new System.Windows.Forms.Padding(1);
            this.btnOpenDirectory.Name = "btnOpenDirectory";
            this.btnOpenDirectory.Size = new System.Drawing.Size(86, 63);
            this.btnOpenDirectory.TabIndex = 2;
            this.btnOpenDirectory.Text = "Find Files";
            this.btnOpenDirectory.UseVisualStyleBackColor = true;
            this.btnOpenDirectory.Click += new System.EventHandler(this.BtnOpenDirectory_Click);
            this.btnOpenDirectory.MouseHover += new System.EventHandler(this.BtnOpenDirectory_MouseHover);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1, 184);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 63);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print to File";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Location = new System.Drawing.Point(1, 248);
            this.lblMemory.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(0, 13);
            this.lblMemory.TabIndex = 7;
            // 
            // lblRamCounter
            // 
            this.lblRamCounter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRamCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRamCounter.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblRamCounter.Location = new System.Drawing.Point(1, 261);
            this.lblRamCounter.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblRamCounter.Name = "lblRamCounter";
            this.lblRamCounter.Size = new System.Drawing.Size(84, 18);
            this.lblRamCounter.TabIndex = 8;
            this.lblRamCounter.Text = "Ram";
            this.lblRamCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCPU
            // 
            this.lblCPU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPU.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblCPU.Location = new System.Drawing.Point(1, 279);
            this.lblCPU.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(86, 18);
            this.lblCPU.TabIndex = 9;
            this.lblCPU.Text = "CPU";
            this.lblCPU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolTip
            // 
            this.ToolTip.AutomaticDelay = 200;
            this.ToolTip.AutoPopDelay = 10000;
            this.ToolTip.InitialDelay = 200;
            this.ToolTip.IsBalloon = true;
            this.ToolTip.ReshowDelay = 40;
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Information";
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // cbxGuid
            // 
            this.cbxGuid.AutoSize = true;
            this.cbxGuid.Location = new System.Drawing.Point(391, 1);
            this.cbxGuid.Margin = new System.Windows.Forms.Padding(1);
            this.cbxGuid.Name = "cbxGuid";
            this.cbxGuid.Size = new System.Drawing.Size(121, 17);
            this.cbxGuid.TabIndex = 7;
            this.cbxGuid.Text = "ProjectGuid Number";
            this.cbxGuid.UseVisualStyleBackColor = true;
            this.cbxGuid.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            this.cbxGuid.MouseHover += new System.EventHandler(this.CbxGuid_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(722, 362);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(1);
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
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label lblRamCounter;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.CheckBox cbxGuid;
    }
}

