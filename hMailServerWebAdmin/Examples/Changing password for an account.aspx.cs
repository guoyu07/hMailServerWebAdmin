﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hMailServerWebAdmin.Examples
{
    public partial class Changing_password_for_an_account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hMailServerNetRemote.IClassFactory cf = RemoteActivation.GetRemoteClassFactory("http://216.167.175.124/hMailServerWebAdmin/");

            hMailServerNetRemote.IApplication application;
            if (Session["hMailServerNetRemoteApplication"] == null)
            {
                application = cf.CreateApplication();
                Session["hMailServerNetRemoteApplication"] = application;
            }
            else
            {
                application = (hMailServerNetRemote.Application)Session["hMailServerNetRemoteApplication"];
            }

            // the rest is the same
            application.Authenticate("Administrator", "testar");
            
            // You can do it like VB, but let's do it the C# way. :)
            // hMailServerNetRemote.Domain domain = application.Domains.ItemByName("example.com");
            hMailServerNetRemote.IDomain domain = application.Domains["example.com"];

            hMailServerNetRemote.IAccount account = domain.Accounts.ItemByAddress("account@example.com");
            account.Password = "secret";
            account.Save();            
        }
    }
}