import Rhino.Commons.Binsor
import Rhino.Commons
import Skorer.Core 
import Skorer.DataAccess
import System.Reflection
import Skorer.IOC
import Skorer.Services
import Castle.Core
import Skorer.WinForms

Component("NHibernateSessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("SessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("Repository", IRepository, Repository)
Component("Scorer", IScorer, Scorer)
Component("GameDataFactory", IGameDataFactory, GameDataFactory)
Component("DefaultView", IDefaultView, MainWindow)
Component("MatchForm", IMatchView, MatchForm)
Component("AddPlayerForm", IAddPlayerView, PlayerAdd)

Component("PlayerRepository", IPlayerRepository, PlayerRepository)
Component("GameConfigurationPersister", IGameConfigurationPersister, GameConfigurationPersister)

Component("MatchEventRepository", IMatchEventRepository, MatchEventRepository)
Component("MatchRepository", IMatchRepository, MatchRepository)

Component("GameRepository", IGameRepository, GameRepository)
Component("GameEventRepository", IGameEventRepository, GameEventRepository)