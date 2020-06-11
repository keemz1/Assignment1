using Assignment1.Domain;
using Assignment1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1.Pages.SubPages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new ApplicationDbContext()));

            if (manager.FindByName(txtUserName.Text) == null &&
                manager.FindByName(txtUserName.Text) == null &&
                manager.FindByEmail(txtUserName.Text) == null)
            {

                var user = new AppUser()
                {
                    UserName = txtUserName.Text,
                    Email = txtemail.Text,
                    EmailConfirmed = true,
                    FirstName = txtfname.Text,
                    LastName = txtlname.Text

                };

                manager.Create(user, txtpass.Text);
                manager.FindByName(txtUserName.Text);
                manager.AddToRole(user.Id, "Customer");
                Response.Redirect("/Pages/SubPages/Login.aspx");
            }
            else
            {
                return;
            }
        }
    }
}