using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.DSL;
using Boo.Lang.Compiler;
using Skorer.Core;
using Boo.Lang.Compiler.Ast;

using Boo.Lang.Parser;
namespace Skorer.Services
{
    public class ScorerDslEngine : DslEngine
    {
        protected override void CustomizeCompiler(BooCompiler compiler, CompilerPipeline pipeline, string[] urls)
        {             
            ParameterDeclarationCollection parameters = new ParameterDeclarationCollection();
            ParameterDeclaration newParameterDeclaration =
                new ParameterDeclaration("matchEvent", new SimpleTypeReference("Skorer.Core.MatchEvent"));
            parameters.Add(newParameterDeclaration);

            pipeline.Insert(1, new AnonymousBaseClassCompilerStep(typeof(Scorer),                
                "ScoreEvent",
                parameters,
                "Skorer.Services", "Skorer.Core", "Skorer.DataAccess"));
        }

        
    }
}
