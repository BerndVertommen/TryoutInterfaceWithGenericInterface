using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;

namespace TryOutConsole.Infrastructure
{
    public class ModelWizard : IModelWizard
    {
        private readonly ILifetimeScope _scope;

        public ModelWizard(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void CastFireBall(IModel model)
        {
            Type type = typeof(IModelBuilder<>).MakeGenericType(model.GetType());
            dynamic modelBuilder = _scope.Resolve(type);

            if (modelBuilder == null)
            {
                //Console.WriteLine($"No modelbuilder found. {_modelBuilders.Count()} modelbuilders injected");
            }
            else
            {
                modelBuilder.Build((dynamic) model);
                Cast(model);
            }
        }

        private static void Cast(IModel model)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Fireball was cast at: {model.Name}");
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public interface IModelWizard
    {
        void CastFireBall(IModel model);
    }
}
