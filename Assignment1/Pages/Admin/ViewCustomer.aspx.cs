using Assignment1.Domain;
using Assignment1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Assignment1.Pages.Admin
{
    public partial class Remove_Customer : System.Web.UI.Page
    {
        private List<QueueOrder> users;
        IAuthenticationManager authenticationManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = HttpContext.Current.User;
            string id = getUserId();
            users = new List<QueueOrder>();
            authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            GetServiceUsers(authenticationManager);
            
        }

        public void GetServiceUsers(IAuthenticationManager authenticationManager)
        {
            using (var context = new ApplicationDbContext())
            {
                if (authenticationManager.User.IsInRole("Restaurant"))
                {
                    var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == "Restaurant").ToList().FirstOrDefault();
                    users = context.QueueOrders.Where(c => c.ServiceQueueNumber == serviceQueue.ServiceId  && c.CustomerNumber == 1).ToList();
                }
                if (authenticationManager.User.IsInRole("Automotive"))
                {
                    var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == "Automotive").ToList().FirstOrDefault();
                    users = context.QueueOrders.Where(c => c.ServiceQueueNumber == serviceQueue.ServiceId && c.CustomerNumber == 1).ToList();
                }
                if (authenticationManager.User.IsInRole("Digicel"))
                {
                    var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == "Digicel").ToList().FirstOrDefault();
                    var role = context.Roles.Where(x => x.Name == "Digicel").ToList().FirstOrDefault();
                    users = context.QueueOrders.Where(c => c.ServiceQueueNumber == serviceQueue.ServiceId && c.CustomerNumber == 1).ToList();
                }
                if (authenticationManager.User.IsInRole("NCBBank"))
                {
                    var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == "NCBBank").ToList().FirstOrDefault();
                    users = context.QueueOrders.Where(c => c.ServiceQueueNumber == serviceQueue.ServiceId && c.CustomerNumber == 1).ToList();
                }
                userGridView.DataSource = users;
                userGridView.DataBind();

            }
        }

        public void ViewQueue()
        {
            using (var context = new ApplicationDbContext())
            {
                if (authenticationManager.User.IsInRole("Restaurant"))
                {
                    var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == "Restaurant").ToList().FirstOrDefault();
                    users = context.QueueOrders.Where(c => c.ServiceQueueNumber == serviceQueue.ServiceId).ToList();
                }
                if (authenticationManager.User.IsInRole("Automotive"))
                {
                    var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == "Automotive").ToList().FirstOrDefault();
                    users = context.QueueOrders.Where(c => c.ServiceQueueNumber == serviceQueue.ServiceId).ToList();
                }
                if (authenticationManager.User.IsInRole("Digicel"))
                {
                    var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == "Digicel").ToList().FirstOrDefault();
                    var role = context.Roles.Where(x => x.Name == "Digicel").ToList().FirstOrDefault();
                    users = context.QueueOrders.Where(c => c.ServiceQueueNumber == serviceQueue.ServiceId).ToList();
                }
                if (authenticationManager.User.IsInRole("NCBBank"))
                {
                    var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == "NCBBank").ToList().FirstOrDefault();
                    users = context.QueueOrders.Where(c => c.ServiceQueueNumber == serviceQueue.ServiceId).ToList();
                }
                userGridView.DataSource = users;
                userGridView.DataBind();

            }
        }
        public void RemoveUserFromQueue(object sender)
        {
            string id = getUserId();
            var today = DateTime.Now;
            GridViewRow gRow = ((GridViewRow)((HtmlInputButton)sender).Parent.Parent);
            int queueID = Int32.Parse(gRow.Cells[0].Text);

            using (var context = new ApplicationDbContext())
            {
                var item = context.QueueOrders.Where(x => x.QueueOrderNumber == queueID).ToList().FirstOrDefault();
                int newQueueNumber = item.CustomerNumber;
                int nextNumber = item.CustomerNumber + 1;
                var nextCustomer = context.QueueOrders.Where(x => x.CustomerNumber == nextNumber)
                    .ToList().FirstOrDefault();
                var customerQueueOrders = context.QueueOrders.Where(x => x.ServiceQueueNumber == item.ServiceQueueNumber).ToList();
                var queueOrderNumber = context.QueueOrders.Where(x => x.ServiceQueueNumber == item.ServiceQueueNumber).Count();
                int count = 1;
                int counter = 0;
                while (counter < queueOrderNumber)
                {
                    if (nextCustomer == null)
                    {
                        return;
                    }
                    else if (item.CustomerNumber == count)
                    {
                        customerQueueOrders[count].CustomerNumber = count;
                    }
                    count++;
                    counter++;
                }
                context.Entry(item).State = EntityState.Deleted;
                context.SaveChanges();
            };
            Response.AppendHeader("Refresh", "2");
        }

        public string getUserId()
        {
            var user = HttpContext.Current.User;
            string id = user.Identity.GetUserId();
            return id;
        }



        protected void btnRemoveFromQueue(object sender, EventArgs e)
        {
            RemoveUserFromQueue(sender);
        }

        protected void btnViewCustomerQueue(object sender, EventArgs e)
        {
            ViewQueue();
        }
    }
}