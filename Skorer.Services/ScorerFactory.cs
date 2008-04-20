using System;
using Rhino.DSL;
using Skorer.DataAccess;

namespace Skorer.Services
{
    public class ScorerFactory
    {
        DslFactory _Factory = new DslFactory();
        IGameFactory _GameFactory;
        IMatchRepository _MatchRepository;
        IMatchEventRepository _MatchEventRepository;

        public ScorerFactory(IGameFactory gameFactory, IMatchRepository matchRepository, IMatchEventRepository matchEventRepository)
        {
            _Factory.BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _Factory.Register<Scorer>(new ScorerDslEngine());
            _GameFactory = gameFactory;
            _MatchRepository = matchRepository;
            _MatchEventRepository = matchEventRepository;

        }

        public Scorer GetScorerFor(string gameName)
        {
            string fileName = "Scoring\\" + gameName + ".boo";

            if (!System.IO.File.Exists(_Factory.BaseDirectory + "\\" + fileName))               
                fileName = "Scoring\\Default.boo";

            Scorer rv = _Factory.Create<Scorer>(fileName, _GameFactory, _MatchRepository, _MatchEventRepository);
            rv.LoadGame(gameName);

            return rv;
        }
    }
}
