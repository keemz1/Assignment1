using Assignment1.Domain;
using Assignment1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        UserManager<AppUser> userManager = new UserManager<AppUser>(new UserStore<AppUser>(new ApplicationDbContext()));

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            StatusMessage.Visible = false;
            StatusMessage.Text = "";
            userManager.UserValidator = new UserValidator<AppUser>(userManager);
            var userEmail = userManager.FindByEmail(txtemail.Text);
            bool confirm = userManager.CheckPassword(userEmail, txtpass.Text);
            if (userEmail == null || confirm == false)
            {
                StatusMessage.Visible = true;
                StatusMessage.Text = "User not found  or Incorrect password was entered";
            }
            else
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(userEmail, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                Response.Redirect("/Pages/SubPages/ServiceProviderQueue.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SubPages/Register.aspx");
        }
    }
}