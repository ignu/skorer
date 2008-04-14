using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Castle.MonoRail.Framework;

namespace Skorer.Web.Controllers
{
    public class BaseController : SmartDispatcherController
    {
        public override void Initialize()
        {
            PropertyBag["ConfirmationMessage"] = ConfirmationMessage;
            base.Initialize();
        }


        
        
        public string ConfirmationMessage
        {
            get 
            {                
                if (Flash["ConfirmationMessage"] == null)
                    return String.Empty;

                return Flash["ConfirmationMessage"].ToString();
            }
            set
            {
                Flash["ConfirmationMessage"] = value;
            }
        }
        
    }
}
