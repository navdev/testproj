using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Testcore.Website;

namespace Testcore.Website
{
    public class MvcApplication : Application
    {
        protected void Application_Start()
        {
            IoC.Initialize();
        }
    }
}
