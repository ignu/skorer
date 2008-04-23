using System;
using System.Collections.Generic;
using System.IO;
using Rhino.DSL;
using Skorer.Core;

namespace Skorer.Services
{    
    public interface IGameDataFactory
    {
        List<string> GetGames();
        Game LoadGame(string gameName);
    }

    public class GameDataFactory : IGameDataFactory
    {
        private const string BASE_DIRECTORY = "GameDefinitions\\";
        DslFactory _Factory = new DslFactory();

        IGameConfigurationPersister _GameConfigurationPersister;

        public GameDataFactory(IGameConfigurationPersister gameConfigurationPersister)
        {
            _GameConfigurationPersister = gameConfigurationPersister;
            _Factory.BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _Factory.Register<GameData>(new GameDataDslEngine());
        }

        public Game LoadGame(string gameName)
        {
            string fileName = BASE_DIRECTORY + gameName + ".boo";
            GameData data = _Factory.Create<GameData>(fileName);
            data.Prepare();
            Game rv = _GameConfigurationPersister.SyncGame(data);            
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