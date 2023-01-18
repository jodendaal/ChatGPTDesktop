using NamedPipes.Helper;
using System.Windows.Forms;

namespace ChatGPTDesktop
{
    internal static class Program
    {
        static Form1 _form;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            App.SingleInstance(nameof(ChatGPTDesktop), () =>
            {
                _form = new Form1(new PromptHttpClient(new HttpClient()));
                Application.Run(_form);
            }, 
            (message) => {
                _form.ShowForm();
            });

           
        }
    }
}