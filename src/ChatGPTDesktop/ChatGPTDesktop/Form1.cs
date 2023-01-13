namespace ChatGPTDesktop
{
    public partial class Form1 : Form
    {
        bool _allowedToClose;

        public Form1()
        {
            InitializeComponent();
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

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Focus();
        }

        private async void LoadPage()
        {
            await webView.EnsureCoreWebView2Async();
            webView.CoreWebView2.Navigate("https://chat.openai.com/");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPage();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }
    }
}