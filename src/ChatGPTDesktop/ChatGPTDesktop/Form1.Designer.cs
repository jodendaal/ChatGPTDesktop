namespace ChatGPTDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnShowActPrompts = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rdMyPrompts = new System.Windows.Forms.RadioButton();
            this.btnAddActPrompt = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopyPrompt = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditPrompt = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeletePrompt = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(541, 480);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowActPrompts,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(826, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnShowActPrompts
            // 
            this.btnShowActPrompts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowActPrompts.Image = ((System.Drawing.Image)(resources.GetObject("btnShowActPrompts.Image")));
            this.btnShowActPrompts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowActPrompts.Name = "btnShowActPrompts";
            this.btnShowActPrompts.Size = new System.Drawing.Size(23, 22);
            this.btnShowActPrompts.Text = "toolStripButton1";
            this.btnShowActPrompts.Click += new System.EventHandler(this.btnShowActPrompts_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShow,
            this.btnQuit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // btnShow
            // 
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(103, 22);
            this.btnShow.Text = "Show";
            // 
            // btnQuit
            // 
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(103, 22);
            this.btnQuit.Text = "Quit";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radioButton2);
            this.splitContainer1.Panel1.Controls.Add(this.rdMyPrompts);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddActPrompt);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webView);
            this.splitContainer1.Size = new System.Drawing.Size(826, 480);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(108, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(119, 19);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "Awsome Prompts";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.awsomePromptChanged_CheckedChanged);
            // 
            // rdMyPrompts
            // 
            this.rdMyPrompts.AutoSize = true;
            this.rdMyPrompts.Checked = true;
            this.rdMyPrompts.Location = new System.Drawing.Point(12, 3);
            this.rdMyPrompts.Name = "rdMyPrompts";
            this.rdMyPrompts.Size = new System.Drawing.Size(90, 19);
            this.rdMyPrompts.TabIndex = 2;
            this.rdMyPrompts.TabStop = true;
            this.rdMyPrompts.Text = "My Prompts";
            this.rdMyPrompts.UseVisualStyleBackColor = true;
            this.rdMyPrompts.CheckedChanged += new System.EventHandler(this.myPromptTypeChanged_CheckedChanged);
            // 
            // btnAddActPrompt
            // 
            this.btnAddActPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddActPrompt.BackColor = System.Drawing.Color.Transparent;
            this.btnAddActPrompt.Image = ((System.Drawing.Image)(resources.GetObject("btnAddActPrompt.Image")));
            this.btnAddActPrompt.Location = new System.Drawing.Point(245, 23);
            this.btnAddActPrompt.Name = "btnAddActPrompt";
            this.btnAddActPrompt.Size = new System.Drawing.Size(30, 25);
            this.btnAddActPrompt.TabIndex = 2;
            this.btnAddActPrompt.UseVisualStyleBackColor = false;
            this.btnAddActPrompt.Click += new System.EventHandler(this.btnAddActPrompt_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(0, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(241, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(275, 436);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyPrompt,
            this.btnEditPrompt,
            this.btnDeletePrompt});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(108, 70);
            // 
            // btnCopyPrompt
            // 
            this.btnCopyPrompt.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyPrompt.Image")));
            this.btnCopyPrompt.Name = "btnCopyPrompt";
            this.btnCopyPrompt.Size = new System.Drawing.Size(107, 22);
            this.btnCopyPrompt.Text = "Copy";
            this.btnCopyPrompt.Click += new System.EventHandler(this.btnCopyPrompt_Click);
            // 
            // btnEditPrompt
            // 
            this.btnEditPrompt.Image = ((System.Drawing.Image)(resources.GetObject("btnEditPrompt.Image")));
            this.btnEditPrompt.Name = "btnEditPrompt";
            this.btnEditPrompt.Size = new System.Drawing.Size(107, 22);
            this.btnEditPrompt.Text = "Edit";
            this.btnEditPrompt.Click += new System.EventHandler(this.btnEditPrompt_Click_1);
            // 
            // btnDeletePrompt
            // 
            this.btnDeletePrompt.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePrompt.Image")));
            this.btnDeletePrompt.Name = "btnDeletePrompt";
            this.btnDeletePrompt.Size = new System.Drawing.Size(107, 22);
            this.btnDeletePrompt.Text = "Delete";
            this.btnDeletePrompt.Click += new System.EventHandler(this.btnDeletePrompt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 505);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Chat GPT";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private ToolStrip toolStrip1;
        private ToolStripButton btnRefresh;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem btnShow;
        private ToolStripMenuItem btnQuit;
        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private TextBox txtSearch;
        private ToolStripButton btnShowActPrompts;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem btnEditPrompt;
        private RadioButton radioButton2;
        private RadioButton rdMyPrompts;
        private ToolStripMenuItem btnDeletePrompt;
        private Button btnAddActPrompt;
        private ToolStripMenuItem btnCopyPrompt;
    }
}