using Winforms.Routing;

namespace Winforms.Routing.Tests
{
    [Route("product")]
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        [Route("product/{productId}")]
        public void ShowForm(int productId)
        {

        }
    }
}