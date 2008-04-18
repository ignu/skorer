import Rhino.Commons.Binsor
import Rhino.Commons
import Skorer.Core 
import Skorer.DataAccess
import System.Reflection
import Skorer.IOC
import Castle.Core
import Skorer.WinForms

Component("NHibernateSessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("SessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("Repository", IRepository, Repository)
Component("DefaultView", IDefaultView, MainWindow)
Component("MatchForm", IMatchView, MatchForm)

Component("PlayerRepository", IPlayerRepository, PlayerRepository)