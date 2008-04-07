using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.DSL;
using Boo.Lang.Compiler;
using Skorer.Core;

namespace Skorer.Services
{
    public class GameDslEngine : DslEngine
    {
        protected override void CustomizeCompiler(BooCompiler compiler, CompilerPipeline pipeline, string[] urls)
        {
            pipeline.Insert(1, new AnonymousBaseClassCompilerStep(typeof(Game),
                "Prepare",
                "Skorer.Core"));
        }
    }
}