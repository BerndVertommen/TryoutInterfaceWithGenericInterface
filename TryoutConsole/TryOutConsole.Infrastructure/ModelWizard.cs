using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TryOutConsole.Infrastructure
{
    public class ModelWizard : IModelWizard
    {
        private readonly IEnumerable<IModelBuilder<IModel>> _modelBuilders;

        public ModelWizard(IEnumerable<IModelBuilder<IModel>> modelBuilders)
        {
            _modelBuilders = modelBuilders;
        }

        public void CastFireBall(IModel model)
        {
            var modelBuilder = _modelBuilders.FirstOrDefault(m => m.Name == model.Name);

            if (modelBuilder == null)
            {
                Console.WriteLine($"No modelbuilder found. {_modelBuilders.Count()} modelbuilders injected");
            }
            else
            {
                modelBuilder.Build(model);
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
