using System;
using Rhino.DSL;
using Boo.Lang.Compiler;
using Skorer.Core;

namespace Skorer.Services
{
    public class GameDataDslEngine : DslEngine
    {
        protected override void CustomizeCompiler(BooCompiler compiler, CompilerPipeline pipeline, string[] urls)
        {
            pipeline.Insert(1, new AnonymousBaseClassCompilerStep(typeof(GameData),
                "Prepare",
                "Skorer.Core"
                ));
                
        }
    }
}