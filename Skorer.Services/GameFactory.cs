using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Rhino.DSL;
using Skorer.Core;

namespace Skorer.Services
{
    public interface IGameFactory
    {
        Game LoadGame(string gameName);
    }

    public class GameFactory : IGameFactory
    {
        DslFactory _Factory = new DslFactory();

        public GameFactory()
        {
            _Factory.BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _Factory.Register<Game>(new GameDslEngine());
        }

        public Game LoadGame(string gameName)
        {
            string fileName = "GameDefinitions\\" + gameName + ".boo";
            Game rv = _Factory.Create<Game>(fileName);
            rv.Prepare();
            return rv;
        }
    }
}