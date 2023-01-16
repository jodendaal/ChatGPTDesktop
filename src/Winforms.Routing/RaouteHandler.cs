using System.Reflection;
namespace Winforms.Routing
{

    public class FormRoute
    {
        public FormRoute(Type form,MethodInfo method,RouteAttribute attribute) 
        {
            this.Route = attribute.Route;
            this.Form = form;
            this.Method = method;
        }

        public FormRoute(Type form, RouteAttribute attribute)
        {
            this.Route = attribute.Route;
            this.Form = form;
        }

        public string Route { get; set; }
        public Type Form { get; set; }
        public MethodInfo? Method { get; set; }
    }

    public class RouteConfiguration
    {
        public void FindRoute(string path, List<FormRoute> routes)
        {
            var parts = path.Split("/");

            routes.All(i => i.Route.StartsWith($"{parts[0]}"));
        }

        public List<FormRoute> GetRoutes(Type form)
        {
            List<FormRoute> routes = new List<FormRoute>();
            
            var routeAttribute = form.GetCustomAttribute<RouteAttribute>();

            if(routeAttribute != null)
            {
                routes.Add(new FormRoute(form,routeAttribute));
            }

            var methods = form.GetMethods().ToList();//qqq try optimise 
            methods.ForEach(m =>
            {
                var methodRouteAttribute = m.GetCustomAttribute<RouteAttribute>();
                if(methodRouteAttribute != null)
                {
                    routes.Add(new FormRoute(form, m, methodRouteAttribute));
                }
            });

            return routes;
        }

        public void MapRoutes(Assembly assembly)
        {
            List<FormRoute> routes = new List<FormRoute>();

            var forms = assembly
                    .GetTypes()
                    .Where(t => t.BaseType == typeof(Form))
                    .ToList();

            forms.ForEach(form =>
            {
                routes.AddRange(GetRoutes(form));
            });
        }
    }

    public class RouteHandler
    {

    }
}
