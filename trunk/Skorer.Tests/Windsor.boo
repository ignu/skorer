import Rhino.Commons.Binsor
import Rhino.Commons
import Skorer.Core 
import Skorer.DataAccess
import System.Reflection
import Skorer.IOC
import Castle.Core

Component("NHibernateSessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("SessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("Repository", IRepository, Repository)