using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TryOutConsole.Infrastructure
{
    public interface IModelBuilder
    {
        
    }

    public interface IModelBuilder<in T>: IModelBuilder where T: IModel
    {
        string Name { get;  }
        void Build(T model);

    }
}
