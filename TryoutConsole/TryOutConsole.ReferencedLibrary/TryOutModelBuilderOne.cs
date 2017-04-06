using System;
using TryOutConsole.NonReferencedLibrary;

namespace TryOutConsole.ReferencedLibrary
{
    public class TryOutModelBuilderOne : BaseModelBuilderTryOut<ModelOne>
    {
        public override string Name => typeof(ModelOne).Name;

        protected override void DoCustomStuff()
        {
           Console.WriteLine($"Doing custom stuff for Model: {Model.Name}");
        }
    }
}
