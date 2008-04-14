import Rhino.Commons.Binsor
import Rhino.Commons
import Skorer.Core 
import Skorer.DataAccess
import System.Reflection
import Skorer.IOC
import Castle.Core
import Castle.MonoRail.WindsorExtension
import Castle.MonoRail.Framework
import Skorer.Web
import Skorer.Web.Controllers


Facility( "rails", MonoRailFacility )
	
webAsm = Assembly.Load("Skorer.Web")

for type in webAsm.GetTypes():
	System.Diagnostics.Debug.WriteLine("Checking: " + type.Name)
	if typeof(Controller).IsAssignableFrom(type):
		System.Diagnostics.Debug.WriteLine("Registering: " + type.Name + " -=-==-=-==-=-==-=-==-=-==-=-==-=-==-=-==-=-==-=-==-=-==-=-==-=-==-=-==-=- ")
		Component(type.Name, type)
	elif typeof(ViewComponent).IsAssignableFrom(type):
		Component(type.Name, type)


Component("NHibernateSessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("SessionManager", INHibernateSessionManager, NHibernateSessionManager)
Component("Repository", IRepository, Repository)

#Component("home.controller", HomeController)
#Component("player.controller", PlayerController)

System.Diagnostics.Debug.WriteLine("Done Loading Config.")