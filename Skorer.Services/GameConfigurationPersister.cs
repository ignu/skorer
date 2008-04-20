using System;
using Skorer.Core;
using Skorer.DataAccess;

namespace Skorer.Services
{
    public interface IGameConfigurationPersister
    {
        void SyncGame(Game game);
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

        public void SyncGame(Game game)
        {
            Game existingGame = _GameRepository.GetByName(game.Name);

            if (existingGame != null && existingGame.ID > 0)
                game = existingGame;
            else
                _GameRepository.Save(game);

            foreach (GameEvent gameEvent in game.GetEvents())
            {
                GameEvent eventToSave = gameEvent;
                GameEvent existingGameEvent = _GameEventRepository.GetByNameAndGame(gameEvent.Name, game);
                if (existingGameEvent != null && existingGameEvent.ID > 0)
                    eventToSave = existingGameEvent;

                gameEvent.Game = game;

                _GameEventRepository.SaveOrUpdate(eventToSave);
            }
        }
    }
}
