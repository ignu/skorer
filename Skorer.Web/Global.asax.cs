using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using Castle.Windsor;
using Castle.MonoRail.WindsorExtension;
using Rhino.Commons;
using Rhino.Commons.Binsor;

namespace Skorer.Web
{
    public class ScorerApplication : System.Web.HttpApplication, IContainerAccessor
    {
        protected static RhinoContainer _Container;
        public IWindsorContainer Container
        {
            get 
            {                
                return Skorer.IOC.Container.GetContainer(); 
            }
        }
    }
    public class Global : ScorerApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            _Container = new RhinoContainer();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Windsor.boo";
            Console.WriteLine(path);
            BooReader.Read(_Container, path);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}