﻿using System;
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
            builder.RegisterType<ModelWizard>().As<IModelWizard>();

            var referencedAssemby = typeof (IAmReferencedLibrary).Assembly;

            //builder.RegisterType<ModelOne>().As<IModel>();
            //builder.RegisterType<TryOutModelBuilderOne>().As<IModelBuilder<ModelOne>>();

            var assemblyTypes = referencedAssemby.GetTypes();

            foreach (var type in assemblyTypes.Where(t => typeof(IModelBuilder).IsAssignableFrom(t) && !t.IsAbstract))
            {
                builder.RegisterType(type).AsSelf().AsImplementedInterfaces();
            }

            builder.RegisterType<ModelWizard>().As<IModelWizard>();

            return builder.Build();
        }
    }
}
