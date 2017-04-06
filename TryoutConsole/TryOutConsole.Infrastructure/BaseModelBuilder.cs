using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOutConsole.Infrastructure
{
    public abstract class BaseModelBuilder<T> : IModelBuilder<T> where T : IModel
    {
        protected T Model { get; set; }
        public abstract string Name { get; }
        public void Build(T model)
        {
            Model = model;

            Console.WriteLine($"Building model : {Model.Name}");
        }

        protected abstract void DoCustomStuff();
    }
}
