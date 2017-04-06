using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using TryOutConsole.Infrastructure;
using TryOutConsole.NonReferencedLibrary;
using TryOutConsole.ReferencedLibrary;

namespace TryOutConsole.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting tryout");
           var container =  RegisterComponents();

            using (var lifetimeScope = container.BeginLifetimeScope())
            {
                var modelWizard = lifetimeScope.Resolve<IModelWizard>();

                var model = new ModelOne();
                modelWizard.CastFireBall(model);
            }

            System.Console.ReadLine();
        }

        private static IContainer RegisterComponents()
        {
            var builder = new ContainerBuilder();

            var referencedAssemby = typeof (IAmReferencedLibrary).Assembly;

            var assemblyTypes = referencedAssemby.GetTypes();
            var typeWithInterface = typeof(IModelBuilder<IModel>);

            foreach (var type in assemblyTypes.Where(t => typeWithInterface.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract))
            {
                builder.RegisterType(type).As<IModelBuilder<IModel>>().InstancePerLifetimeScope();
            }

            return builder.Build();
        }
    }
}
