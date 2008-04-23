using System;
using Skorer.Core;
using Skorer.DataAccess;

namespace Skorer.Services
{
    public interface IGameConfigurationPersister
    {
        Game SyncGame(GameData gameData);
    }

    public class GameConfigurationPersister : IGameConfigurationPersister
    {
        IGameRepository _GameRepository;
        IGameEventRepository _GameEventRepository;

        public GameConfigurationPersister(IGameRepository gameRepository, IGameEventRepository gameEventRepository)
        {
            _GameRepository = gameRepository;
            _GameEventRepository = gameEventRepository;
        }

        public Game SyncGame(GameData gameData)
        {
            Game existingGame = _GameRepository.GetByName(gameData.Name);
            if (existingGame == null)
            {
                existingGame = new Game();
                existingGame.Name = gameData.Name;
            }

            existingGame.DistinctPlayerRounds = gameData.DistinctPlayerRounds;
            _GameRepository.Save(existingGame);
            _GameRepository.Flush();


            foreach (GameEvent gameEvent in gameData.GetEvents())
            {
                GameEvent eventToSave = gameEvent;
                GameEvent existingGameEvent = _GameEventRepository.GetByNameAndGame(gameEvent.Name, existingGame);
                
                if (existingGameEvent != null && existingGameEvent.ID > 0)
                    eventToSave = existingGameEvent;

                existingGame.AddEvent(eventToSave);                
            }

            _GameRepository.Save(existingGame);
            _GameEventRepository.Flush();

            return existingGame;
        }
    }
}
