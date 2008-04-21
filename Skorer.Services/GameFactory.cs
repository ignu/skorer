using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Rhino.DSL;
using Skorer.Core;
using Skorer.DataAccess;

namespace Skorer.Services
{    
    public interface IGameFactory
    {
        List<string> GetGames();
        Game LoadGame(string gameName);
    }

    public class GameFactory : IGameFactory
    {
        private const string BASE_DIRECTORY = "GameDefinitions\\";
        DslFactory _Factory = new DslFactory();

        IGameConfigurationPersister _GameConfigurationPersister;

        public GameFactory(IGameConfigurationPersister gameConfigurationPersister)
        {
            _GameConfigurationPersister = gameConfigurationPersister;
            _Factory.BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _Factory.Register<Game>(new GameDslEngine());
        }

        public Game LoadGame(string gameName)
        {
            string fileName = BASE_DIRECTORY + gameName + ".boo";
            Game rv = _Factory.Create<Game>(fileName);
            rv.Prepare();
            _GameConfigurationPersister.SyncGame(rv);            
            return rv;
        }

        public List<string> GetGames()
        {
            List<string> rv = new List<string>();
            string directoryName = AppDomain.CurrentDomain.BaseDirectory + "\\" + BASE_DIRECTORY;

            System.Diagnostics.Debug.Write(directoryName);

            DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(directoryName);

            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                rv.Add(fileInfo.Name.Replace(".boo", String.Empty));
            }

            return rv;
        }
        
    }
}