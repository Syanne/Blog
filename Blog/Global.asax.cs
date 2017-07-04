using Autofac;
using Autofac.Integration.Mvc;
using Blog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static IContainer container { get; private set; }
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataContext>().AsSelf().InstancePerRequest();
            
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();            
            builder.RegisterModule<AutofacWebTypesModule>();            
            builder.RegisterSource(new ViewRegistrationSource());            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new DataDependencyBuilder());

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
