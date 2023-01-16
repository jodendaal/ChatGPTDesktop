using Microsoft.Extensions.DependencyInjection;

namespace ChatGPTDesktop.Services
{
    public interface IFormFactory
    {
        T? Create<T>() where T : Form;
    }

    public class FormFactory : IFormFactory
    {
        private readonly IServiceScope _scope;

        public FormFactory(IServiceScopeFactory scopeFactory) 
        {
            _scope = scopeFactory.CreateScope();
        }

        public T? Create<T>() where T : Form
        {
            return _scope.ServiceProvider.GetService<T>();
        }
    }
}
