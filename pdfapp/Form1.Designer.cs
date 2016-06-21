using System.Windows.Forms;

namespace pdfapp
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.bSelectPDF = new System.Windows.Forms.Button();
            this.lPathPDF = new System.Windows.Forms.Label();
            this.tb_pages = new System.Windows.Forms.TextBox();
            this.bCreatePDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_close = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfViewer = new AxAcroPDFLib.AxAcroPDF();
            this.bNextPage = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // bSelectPDF
            // 
            this.bSelectPDF.Location = new System.Drawing.Point(70, 98);
            this.bSelectPDF.Name = "bSelectPDF";
            this.bSelectPDF.Size = new System.Drawing.Size(94, 40);
            this.bSelectPDF.TabIndex = 0;
            this.bSelectPDF.Text = "Select PDF";
            this.bSelectPDF.UseVisualStyleBackColor = true;
            this.bSelectPDF.Click += new System.EventHandler(this.bSelectPDF_Click);
            // 
            // lPathPDF
            // 
            this.lPathPDF.AutoSize = true;
            this.lPathPDF.Location = new System.Drawing.Point(7, 38);
            this.lPathPDF.Name = "lPathPDF";
            this.lPathPDF.Size = new System.Drawing.Size(118, 13);
            this.lPathPDF.TabIndex = 1;
            this.lPathPDF.Text = "No PDF File Selected...";
            // 
            // tb_pages
            // 
            this.tb_pages.Enabled = false;
            this.tb_pages.Location = new System.Drawing.Point(50, 66);
            this.tb_pages.Name = "tb_pages";
            this.tb_pages.Size = new System.Drawing.Size(290, 20);
            this.tb_pages.TabIndex = 2;
            // 
            // bCreatePDF
            // 
            this.bCreatePDF.Enabled = false;
            this.bCreatePDF.Location = new System.Drawing.Point(201, 98);
            this.bCreatePDF.Name = "bCreatePDF";
            this.bCreatePDF.Size = new System.Drawing.Size(94, 40);
            this.bCreatePDF.TabIndex = 3;
            this.bCreatePDF.Text = "Create PDF";
            this.bCreatePDF.UseVisualStyleBackColor = true;
            this.bCreatePDF.Click += new System.EventHandler(this.bCreatePDF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pages:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_help,
            this.menu_close});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menu_help
            // 
            this.menu_help.Name = "menu_help";
            this.menu_help.Size = new System.Drawing.Size(103, 22);
            this.menu_help.Text = "Help";
            this.menu_help.Click += new System.EventHandler(this.menu_help_click);
            // 
            // menu_close
            // 
            this.menu_close.Name = "menu_close";
            this.menu_close.Size = new System.Drawing.Size(103, 22);
            this.menu_close.Text = "Close";
            this.menu_close.Click += new System.EventHandler(this.menu_close_click);
            // 
            // pdfViewer
            // 
            this.pdfViewer.Enabled = true;
            this.pdfViewer.Location = new System.Drawing.Point(377, 38);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfViewer.OcxState")));
            this.pdfViewer.Size = new System.Drawing.Size(338, 374);
            this.pdfViewer.TabIndex = 7;
            // 
            // bNextPage
            // 
            this.bNextPage.Location = new System.Drawing.Point(579, 377);
            this.bNextPage.Name = "bNextPage";
            this.bNextPage.Size = new System.Drawing.Size(75, 23);
            this.bNextPage.TabIndex = 8;
            this.bNextPage.Text = "Next Page";
            this.bNextPage.UseVisualStyleBackColor = true;
            this.bNextPage.Click += new System.EventHandler(bNextPage_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(727, 424);
            this.Controls.Add(this.bNextPage);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCreatePDF);
            this.Controls.Add(this.tb_pages);
            this.Controls.Add(this.lPathPDF);
            this.Controls.Add(this.bSelectPDF);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Baze PDF v1.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            this.form += new FormClosingEventHandler();

        }

        #endregion

        private System.Windows.Forms.Button bSelectPDF;
        private System.Windows.Forms.Label lPathPDF;
        private System.Windows.Forms.TextBox tb_pages;
        private System.Windows.Forms.Button bCreatePDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_help;
        private System.Windows.Forms.ToolStripMenuItem menu_close;
        private AxAcroPDFLib.AxAcroPDF pdfViewer;
        private System.Windows.Forms.Button bNextPage;
    }
}

