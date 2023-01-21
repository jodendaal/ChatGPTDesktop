using ChatGPTDesktop.Models;

namespace ChatGPTDesktop
{
    public partial class frmAddPromptDialog : Form
    {
        public ActPrompt Prompt { get {
                return new ActPrompt()
                {
                    Act = textBox1.Text,
                    Prompt = textBox2.Text,
                };
            } 
        }
        
        public frmAddPromptDialog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        public DialogResult ShowDialog(ActPrompt prompt)
        {
            textBox1.Text = prompt.Act;
            textBox2.Text= prompt.Prompt;
            return this.ShowDialog();
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isValid = !string.IsNullOrEmpty(textBox1.Text);

            errorProvider1.SetError(textBox1, isValid ? "": "Act is required");
            e.Cancel = !isValid;
        }

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isValid = !string.IsNullOrEmpty(textBox2.Text);

            errorProvider1.SetError(textBox2, isValid ? "" : "Prompt is required");
            e.Cancel = !isValid;
        }
    }
}
