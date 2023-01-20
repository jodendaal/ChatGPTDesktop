using ChatGPTDesktop.Models;
using ChatGPTDesktop.Services;
using System.Data;
using System.Text.Json;

namespace ChatGPTDesktop
{
    public partial class Form1 : Form
    {
        bool _allowedToClose;
        List<ActPrompt> _actPrompts = new List<ActPrompt>();
        private readonly PromptHttpClient _promptClient;
        private readonly IAwsomePromptsRespository _promptsRespository;
        private readonly IMyPromptsRespository _myPromptsRespository;
        ActPrompt _selectedItem;
        public Form1(PromptHttpClient promptClient, IAwsomePromptsRespository promptsRespository,IMyPromptsRespository myPromptsRespository)
        {
            InitializeComponent();
            _promptClient = promptClient;
            _promptsRespository = promptsRespository;
            _myPromptsRespository = myPromptsRespository;
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
            LoadAsync();
        }

       

        private void ShowPromptEditor(ActPrompt prompt)
        {
            using (frmAddPromptDialog addPrompt = new frmAddPromptDialog())
            {
                if (addPrompt.ShowDialog(prompt) == DialogResult.OK)
                {
                    SavePrompt(addPrompt.Prompt);

                    var itemIndex = _actPrompts.IndexOf(prompt);
                    if(itemIndex > 0)
                    {
                        _actPrompts[itemIndex] = addPrompt.Prompt;
                        dataGridView1.RefreshEdit();
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        _actPrompts.Insert(0,prompt);
                        LoadAsync();
                    }
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
            if (rdMyPrompts.Checked)
            {
                _actPrompts = _myPromptsRespository.GetAll();
            }

            if (radioButton2.Checked)
            {
                _actPrompts = _promptsRespository.GetAll();
                if (_actPrompts.Count == 0)
                {
                    _actPrompts = await _promptClient.GetPrompts();
                    _promptsRespository.SaveAll(_actPrompts);
                }
            }

            BindData(_actPrompts);
           
        }

        private void BindData(List<ActPrompt> prompts)
        {
            dataGridView1.DataSource = null;//This is for delete/refresh odd but it needed winforms :)
            dataGridView1.DataSource = prompts;
            dataGridView1.Columns["Prompt"].Visible = false;
            dataGridView1.Columns["Act"].ToolTipText = "Prompt";
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                var prompt = dataGridView1.Rows[e.RowIndex].DataBoundItem as ActPrompt;
                InjectPromptText(prompt);
            }
        }

        private void AddScript()
        {
            var text = @"function setMessageText(message) {
                            document.getElementsByTagName(""textarea"")[0].value = message.Prompt;
                            return document.getElementsByTagName(""textarea"")[0];
                        }";
            webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(text);
        }

        private async Task InjectPromptText(ActPrompt prompt)
        {
           var functionCall = $@"setMessageText({JsonSerializer.Serialize(prompt)})";
           var result = await webView.CoreWebView2.ExecuteScriptAsync(functionCall);
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

        private void SavePrompt(ActPrompt prompt)
        {
            if (rdMyPrompts.Checked)
            {
                _myPromptsRespository.Save(prompt);
            }

            if (radioButton2.Checked)
            {
                _promptsRespository.Save(prompt);
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

        private void myPromptTypeChanged_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMyPrompts.Checked)
            {
                LoadAsync();
            }
        }

        private void awsomePromptChanged_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                LoadAsync();
            }
        }

        private void btnDeletePrompt_Click(object sender, EventArgs e)
        {
            DeletePrompt();
        }

        private void DeletePrompt()
        {
            if (rdMyPrompts.Checked)
            {
                _myPromptsRespository.Delete(_selectedItem);
            }

            if (radioButton2.Checked)
            {
                _promptsRespository.Delete(_selectedItem);
            }

            var itemIndex = _actPrompts.IndexOf(_selectedItem);
            _actPrompts.RemoveAt(itemIndex);
            BindData(_actPrompts);
        }

        private void btnEditPrompt_Click_1(object sender, EventArgs e)
        {
            ShowPromptEditor(_selectedItem);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void btnAddActPrompt_Click(object sender, EventArgs e)
        {
            ShowPromptEditor(new ActPrompt());
        }

        private void btnCopyPrompt_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_selectedItem.Prompt);
        }
    }
}