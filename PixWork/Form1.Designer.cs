namespace PixWork
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussian5X5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenLowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenMediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenHighToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findEdgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelEdgeVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramEquilizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.laplacianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianOfGaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.imageToolStripMenuItem1,
            this.filerToolStripMenuItem,
            this.adjustmentsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1057, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newImageToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newImageToolStripMenuItem
            // 
            this.newImageToolStripMenuItem.Name = "newImageToolStripMenuItem";
            this.newImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.newImageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.newImageToolStripMenuItem.Text = "Open Image";
            this.newImageToolStripMenuItem.Click += new System.EventHandler(this.newImageToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.imageToolStripMenuItem.Text = "View";
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showAllToolStripMenuItem.Text = "Show All";
            // 
            // imageToolStripMenuItem1
            // 
            this.imageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateToolStripMenuItem,
            this.flipToolStripMenuItem,
            this.grayscaleToolStripMenuItem});
            this.imageToolStripMenuItem1.Name = "imageToolStripMenuItem1";
            this.imageToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem1.Text = "Image";
            this.imageToolStripMenuItem1.Click += new System.EventHandler(this.imageToolStripMenuItem1_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cWToolStripMenuItem,
            this.cCWToolStripMenuItem});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            // 
            // cWToolStripMenuItem
            // 
            this.cWToolStripMenuItem.Name = "cWToolStripMenuItem";
            this.cWToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cWToolStripMenuItem.Text = "90* CW";
            this.cWToolStripMenuItem.Click += new System.EventHandler(this.cWToolStripMenuItem_Click);
            // 
            // cCWToolStripMenuItem
            // 
            this.cCWToolStripMenuItem.Name = "cCWToolStripMenuItem";
            this.cCWToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cCWToolStripMenuItem.Text = "90* CCW";
            this.cCWToolStripMenuItem.Click += new System.EventHandler(this.cCWToolStripMenuItem_Click);
            // 
            // flipToolStripMenuItem
            // 
            this.flipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem});
            this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
            this.flipToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.flipToolStripMenuItem.Text = "Flip";
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // filerToolStripMenuItem
            // 
            this.filerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurToolStripMenuItem,
            this.sharperToolStripMenuItem,
            this.findEdgesToolStripMenuItem,
            this.embossToolStripMenuItem,
            this.laplacianToolStripMenuItem,
            this.laplacianOfGaussianToolStripMenuItem});
            this.filerToolStripMenuItem.Name = "filerToolStripMenuItem";
            this.filerToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filerToolStripMenuItem.Text = "Filter";
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxToolStripMenuItem,
            this.gaussianToolStripMenuItem,
            this.gaussian5X5ToolStripMenuItem});
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            // 
            // boxToolStripMenuItem
            // 
            this.boxToolStripMenuItem.Name = "boxToolStripMenuItem";
            this.boxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.boxToolStripMenuItem.Text = "Box ( Mean )";
            this.boxToolStripMenuItem.Click += new System.EventHandler(this.boxToolStripMenuItem_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gaussianToolStripMenuItem.Text = "Gaussian ( 3 x 3 )";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.gaussianToolStripMenuItem_Click);
            // 
            // gaussian5X5ToolStripMenuItem
            // 
            this.gaussian5X5ToolStripMenuItem.Name = "gaussian5X5ToolStripMenuItem";
            this.gaussian5X5ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gaussian5X5ToolStripMenuItem.Text = "Gaussian ( 5 x 5 )";
            this.gaussian5X5ToolStripMenuItem.Click += new System.EventHandler(this.gaussian5X5ToolStripMenuItem_Click);
            // 
            // sharperToolStripMenuItem
            // 
            this.sharperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sharpenLowToolStripMenuItem,
            this.sharpenMediumToolStripMenuItem,
            this.sharpenHighToolStripMenuItem});
            this.sharperToolStripMenuItem.Name = "sharperToolStripMenuItem";
            this.sharperToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sharperToolStripMenuItem.Text = "Sharpen";
            // 
            // sharpenLowToolStripMenuItem
            // 
            this.sharpenLowToolStripMenuItem.Name = "sharpenLowToolStripMenuItem";
            this.sharpenLowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sharpenLowToolStripMenuItem.Text = "Sharpen ( Low )";
            this.sharpenLowToolStripMenuItem.Click += new System.EventHandler(this.sharpenLowToolStripMenuItem_Click);
            // 
            // sharpenMediumToolStripMenuItem
            // 
            this.sharpenMediumToolStripMenuItem.Name = "sharpenMediumToolStripMenuItem";
            this.sharpenMediumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sharpenMediumToolStripMenuItem.Text = "Sharpen ( Medium )";
            this.sharpenMediumToolStripMenuItem.Click += new System.EventHandler(this.sharpenMediumToolStripMenuItem_Click);
            // 
            // sharpenHighToolStripMenuItem
            // 
            this.sharpenHighToolStripMenuItem.Name = "sharpenHighToolStripMenuItem";
            this.sharpenHighToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sharpenHighToolStripMenuItem.Text = "Sharpen ( High )";
            this.sharpenHighToolStripMenuItem.Click += new System.EventHandler(this.sharpenHighToolStripMenuItem_Click);
            // 
            // findEdgesToolStripMenuItem
            // 
            this.findEdgesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.highToolStripMenuItem,
            this.sobelEdgeToolStripMenuItem,
            this.sobelEdgeVerticalToolStripMenuItem});
            this.findEdgesToolStripMenuItem.Name = "findEdgesToolStripMenuItem";
            this.findEdgesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.findEdgesToolStripMenuItem.Text = "Find Edges";
            // 
            // lowToolStripMenuItem
            // 
            this.lowToolStripMenuItem.Name = "lowToolStripMenuItem";
            this.lowToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.lowToolStripMenuItem.Text = "Low";
            this.lowToolStripMenuItem.Click += new System.EventHandler(this.lowToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.highToolStripMenuItem.Text = "High";
            this.highToolStripMenuItem.Click += new System.EventHandler(this.highToolStripMenuItem_Click);
            // 
            // sobelEdgeToolStripMenuItem
            // 
            this.sobelEdgeToolStripMenuItem.Name = "sobelEdgeToolStripMenuItem";
            this.sobelEdgeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.sobelEdgeToolStripMenuItem.Text = "Sobel Edge ( Horizontal )";
            this.sobelEdgeToolStripMenuItem.Click += new System.EventHandler(this.sobelEdgeToolStripMenuItem_Click);
            // 
            // sobelEdgeVerticalToolStripMenuItem
            // 
            this.sobelEdgeVerticalToolStripMenuItem.Name = "sobelEdgeVerticalToolStripMenuItem";
            this.sobelEdgeVerticalToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.sobelEdgeVerticalToolStripMenuItem.Text = "Sobel Edge ( Vertical )";
            this.sobelEdgeVerticalToolStripMenuItem.Click += new System.EventHandler(this.sobelEdgeVerticalToolStripMenuItem_Click);
            // 
            // embossToolStripMenuItem
            // 
            this.embossToolStripMenuItem.Name = "embossToolStripMenuItem";
            this.embossToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.embossToolStripMenuItem.Text = "Emboss";
            this.embossToolStripMenuItem.Click += new System.EventHandler(this.embossToolStripMenuItem_Click);
            // 
            // adjustmentsToolStripMenuItem
            // 
            this.adjustmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramEquilizationToolStripMenuItem,
            this.inverToolStripMenuItem});
            this.adjustmentsToolStripMenuItem.Name = "adjustmentsToolStripMenuItem";
            this.adjustmentsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.adjustmentsToolStripMenuItem.Text = "Adjustments";
            // 
            // histogramEquilizationToolStripMenuItem
            // 
            this.histogramEquilizationToolStripMenuItem.Name = "histogramEquilizationToolStripMenuItem";
            this.histogramEquilizationToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.histogramEquilizationToolStripMenuItem.Text = "Histogram Equilization";
            this.histogramEquilizationToolStripMenuItem.Click += new System.EventHandler(this.histogramEquilizationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fAQToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.fAQToolStripMenuItem.Text = "FAQ";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.aboutToolStripMenuItem.Text = "About ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBar2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(842, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 580);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 580);
            this.panel2.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(842, 580);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // laplacianToolStripMenuItem
            // 
            this.laplacianToolStripMenuItem.Name = "laplacianToolStripMenuItem";
            this.laplacianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.laplacianToolStripMenuItem.Text = "Laplacian";
            this.laplacianToolStripMenuItem.Click += new System.EventHandler(this.laplacianToolStripMenuItem_Click);
            // 
            // laplacianOfGaussianToolStripMenuItem
            // 
            this.laplacianOfGaussianToolStripMenuItem.Name = "laplacianOfGaussianToolStripMenuItem";
            this.laplacianOfGaussianToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.laplacianOfGaussianToolStripMenuItem.Text = "Laplacian Of Gaussian";
            this.laplacianOfGaussianToolStripMenuItem.Click += new System.EventHandler(this.laplacianOfGaussianToolStripMenuItem_Click);
            // 
            // inverToolStripMenuItem
            // 
            this.inverToolStripMenuItem.Name = "inverToolStripMenuItem";
            this.inverToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.inverToolStripMenuItem.Text = "Invert";
            this.inverToolStripMenuItem.Click += new System.EventHandler(this.inverToolStripMenuItem_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(3, 24);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Minimum = -255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(209, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Brightness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contrast";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(6, 75);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Minimum = -100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(206, 45);
            this.trackBar2.TabIndex = 3;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 604);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PixWork";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findEdgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussian5X5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelEdgeVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenLowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenMediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenHighToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramEquilizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianOfGaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar2;
    }
}

