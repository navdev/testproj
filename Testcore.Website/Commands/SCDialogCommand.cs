using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Testcore.Website.Commands
{
    public class SCDialogCommand : Command
    {
        public override void Execute(CommandContext context)
        {
            Sitecore.Diagnostics.Log.Info("Writing from sc dialog command command", this);
            //todo
            if (context.Items != null && context.Items.Length > 0)
            {

                var currentItem = context.Items[0];
                NameValueCollection parameters = new NameValueCollection();
                //SheerResponse.Alert("You called the command from item " + currentItem.Name);
                //Sitecore.Context.Job.Status.Messages.Add  //Show messages in job UI
                parameters["id"] = currentItem.ID.ToString();
                parameters["name"] = currentItem.Name;
                parameters["database"] = currentItem.Database.Name;
                parameters["language"] = currentItem.Language.ToString();

                Sitecore.Context.ClientPage.Start(this, "Run", parameters);
            }
        }

        protected void Run(Sitecore.Web.UI.Sheer.ClientPipelineArgs args)
        {
            if (args.IsPostBack)
            {

            } else
            {
                Sitecore.Text.UrlString url = new Sitecore.Text.UrlString("/sitecore/client/Your Apps/View Jobs/Job Listing?sc_lang=en");
                url.Append("id", args.Parameters["id"]);
                url.Append("database", args.Parameters["database"]);
                Sitecore.Context.ClientPage.ClientResponse.ShowModalDialog(url.ToString(), true);
                args.WaitForPostBack(true);
            }
        }

    }
}