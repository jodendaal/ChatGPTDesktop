using Winforms.Routing;

namespace ChatGPTDesktop
{
    [Route("product}")]
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        [Route("product/{productId}")]
        public void Show(int productId)
        {

        }
    }
}