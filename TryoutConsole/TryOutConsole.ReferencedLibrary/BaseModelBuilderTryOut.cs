using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryOutConsole.Infrastructure;

namespace TryOutConsole.ReferencedLibrary
{
    public abstract class BaseModelBuilderTryOut<T> : BaseModelBuilder<T> where T : IModel
    {
    }
}
