using ChatGPTDesktop.Models;
using System.Data;
using System.Windows.Forms;

namespace ChatGPTDesktop
{
    public partial class Form1 : Form
    {
        bool _allowedToClose;
        List<ActPrompt> _actPrompts = new List<ActPrompt>();
        private readonly PromptHttpClient _promptClient;
        ActPrompt _selectedItem;
        public Form1(PromptHttpClient promptClient)
        {
            InitializeComponent();
            _promptClient = promptClient;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(_allowedToClose)
            {
                base.OnFormClosing(e);
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPage();
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            btnShow.Click += BtnShow_Click;
            btnQuit.Click += BtnQuit_Click;
            btnEditPrompt.Click += BtnEditPrompt_Click;
            LoadAsync();

        }

        private void BtnEditPrompt_Click(object sender, EventArgs e)
        {
            using (frmAddPromptDialog addPrompt = new frmAddPromptDialog())
            {
                if (addPrompt.ShowDialog(_selectedItem) == DialogResult.OK)
                {
                    var act = addPrompt.Prompt;
                    _actPrompts[_actPrompts.IndexOf(_selectedItem)] = act;
                    dataGridView1.RefreshEdit();// = _actPrompts;
                    dataGridView1.Refresh();
                }
            }
        }

        private void BtnQuit_Click(object? sender, EventArgs e)
        {
            _allowedToClose = true;
            Application.Exit();
        }

        private void BtnShow_Click(object? sender, EventArgs e)
        {
            ShowForm();
        }

        public void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Focus();

        }

        private async void LoadPage()
        {
            await webView.EnsureCoreWebView2Async();
            AddScript();
            webView.CoreWebView2.Navigate("https://chat.openai.com/");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPage();
            LoadAsync();

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private async void LoadAsync()
        {
            _actPrompts = await _promptClient.GetPrompts();

            dataGridView1.DataSource = _actPrompts;
            dataGridView1.Columns["Prompt"].Visible = false;
            dataGridView1.Columns["Act"].ToolTipText = "Prompt";
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                var text = dataGridView1.Rows[e.RowIndex].Cells["Prompt"].Value.ToString();
                InjectPromptText(text);
            }
        }

        private void AddScript()
        {
            var text = @"function setMessageText(message) {
                            document.getElementsByTagName(""textarea"")[0].value = message;
                        }";
            webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(text);
        }

        private void InjectPromptText(string promptText)
        {
           webView.CoreWebView2.ExecuteScriptAsync($@"setMessageText('{promptText}')");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterGrid(txtSearch.Text);
        }

        private void FilterGrid(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                dataGridView1.DataSource = _actPrompts.Where(i => i.Act.Contains(text,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                dataGridView1.DataSource = _actPrompts;
            }
        }

        private void btnShowActPrompts_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private void btnAddPrompt_Click(object sender, EventArgs e)
        {
            using (frmAddPromptDialog addPrompt = new frmAddPromptDialog())
            {
                if (addPrompt.ShowDialog() == DialogResult.OK)
                {
                    var act = addPrompt.Prompt;
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                contextMenuStrip2.Show(Cursor.Position.X, Cursor.Position.Y);
                _selectedItem = dataGridView1.Rows[e.RowIndex].DataBoundItem as ActPrompt;
            }
        }
    }
}