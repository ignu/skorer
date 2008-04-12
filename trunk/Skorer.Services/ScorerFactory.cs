using System;
using Rhino.DSL;

namespace Skorer.Services
{
    public class ScorerFactory
    {
        DslFactory _Factory = new DslFactory();
        IGameFactory _GameFactory;

        public ScorerFactory(IGameFactory gameFactory)
        {
            _Factory.BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _Factory.Register<Scorer>(new ScorerDslEngine());
            _GameFactory = gameFactory;
        }

        public Scorer GetScorerFor(string gameName)
        {
            string fileName = "Scoring\\" + gameName + ".boo";

            if (!System.IO.File.Exists(_Factory.BaseDirectory + "\\" + fileName))               
                fileName = "Scoring\\Default.boo";

            Scorer rv = _Factory.Create<Scorer>(fileName, _GameFactory);
            rv.LoadGame(gameName);

            return rv;
        }
    }
}
