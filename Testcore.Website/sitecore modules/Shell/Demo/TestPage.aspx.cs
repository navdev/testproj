using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testcore.Website.sitecore_modules.Shell.Demo
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var database = Sitecore.Web.WebUtil.GetQueryString("database");
            var itemId = Sitecore.Web.WebUtil.GetQueryString("id");
            Response.Write(database);
            Response.Write(itemId);
        }
    }
}