import Rhino.Commons.Binsor
import Rhino.Commons
import Skorer.Core 
import Skorer.DataAccess
import System.Reflection
import Skorer.Services
import Skorer.IOC
import Castle.Core

Component("NHibernateSessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("SessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("Repository", IRepository, Repository)
Component("PlayerRepository", IPlayerRepository, PlayerRepository)
Component("MatchEventRepository", IMatchEventRepository, MatchEventRepository)
Component("MatchRepository", IMatchRepository, MatchRepository)
Component("GameDataFactory", IGameDataFactory, GameDataFactory)
Component("GameEventRepository", IGameEventRepository, GameEventRepository)
Component("GameRepository", IGameRepository, GameRepository)
Component("GameConfigurationPersister", IGameConfigurationPersister, GameConfigurationPersister)
Component("ScorerFactory", IScorerFactory, ScorerFactory)