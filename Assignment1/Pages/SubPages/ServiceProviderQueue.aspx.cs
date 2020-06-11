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
using System.Web.UI.WebControls;

namespace Assignment1.Pages.SubPages
{
    public partial class RestaurantQueue : System.Web.UI.Page
    {
        IAuthenticationManager authenticationManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            GetRole(authenticationManager);
            GetQueueNumber();

        }

        //Get User Roles
        public void GetRole(IAuthenticationManager authenticationManager)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Pages/SubPages/Login.aspx", true);
            }
            if (authenticationManager.User.IsInRole("Digicel"))
            {
                Response.Redirect("/Pages/Admin/ViewCustomer.aspx");
            }
            if (authenticationManager.User.IsInRole("NCBBank"))
            {
                Response.Redirect("/Pages/Admin/ViewCustomer.aspx");
            }
            if (authenticationManager.User.IsInRole("Restaurant"))
            {
                Response.Redirect("/Pages/Admin/ViewCustomer.aspx");
            }
            if (authenticationManager.User.IsInRole("Automotive"))
            {
                Response.Redirect("/Pages/Admin/ViewCustomer.aspx");
            }
        }

        //Button Click go to queue
        protected void btnGoToQueue_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            AddRemoveFromQueue(button.Text, button.ID);
        }

        //Save Customer to Queue
        public void SaveToQueue(string queueName)
        {
            using (var context = new ApplicationDbContext())
            {
                string id = getUserId();
                var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == queueName).ToList().FirstOrDefault();
                var queueOrder = context.QueueOrders.Where(x => x.CustomerId == id || x.ServiceQueueNumber == serviceQueue.ServiceId).ToList().FirstOrDefault();
                var countQueue = context.QueueOrders.Where(C => C.ServiceQueueNumber == serviceQueue.ServiceId).ToList().Count();
                var queueList = context.QueueOrders.Where(C => C.ServiceQueueNumber == serviceQueue.ServiceId).ToList();
                int indentCustomerNumber = 0;
                if (queueOrder == null || !queueList.Contains(queueOrder))
                {
                    indentCustomerNumber++;
                }
                else
                {
                    indentCustomerNumber = countQueue + 1;
                }
                context.QueueOrders.Add(new QueueOrder
                {
                    CustomerId = id,
                    ServiceQueueNumber = serviceQueue.ServiceId,
                    CustomerNumber = indentCustomerNumber,
                    Status = "Pending"
                });
                context.SaveChanges();
                //GetQueue(queueName, id);
                Response.AppendHeader("Refresh", "2");
            }
        }

        //Remove Customer From Queue
        public void RemoveFromQueue(string queueName)
        {
            using (var context = new ApplicationDbContext())
            {
                string id = getUserId();
                var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == queueName).ToList().FirstOrDefault();
                var item = context.QueueOrders.Where(x => x.CustomerId == id &&
                x.ServiceQueueNumber == serviceQueue.ServiceId).ToList().FirstOrDefault();
                var customerQueueOrders = context.QueueOrders.Where(x => x.ServiceQueueNumber == serviceQueue.ServiceId).ToList();
                var queueOrderNumber = context.QueueOrders.Where(x => x.ServiceQueueNumber == serviceQueue.ServiceId).Count();
                int newQueueNumber = item.CustomerNumber;
                int nextNumber = item.CustomerNumber + 1;
                var nextCustomer = context.QueueOrders.Where(x => x.CustomerNumber == nextNumber).ToList();
                
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
            }
            Response.AppendHeader("Refresh", "2");
        }

        //Get User Id
        public string getUserId()
        {
            var user = HttpContext.Current.User;
            string id = (string)user.Identity.GetUserId();
            return id;
        }

        //Used to decide whether to add or remove a Customer from Queue
        public void AddRemoveFromQueue(string buttonIdText, string buttonId)
        {
            string id = getUserId();
            using (var context = new ApplicationDbContext())
            {
                var serviceQueue = context.ServiceQueues.Where(x => x.ServiceLabel == buttonId).ToList().FirstOrDefault();
                var item = context.QueueOrders.Where(x => x.CustomerId == id && x.ServiceQueueNumber == serviceQueue.ServiceId).ToList().FirstOrDefault();
                if (item == null)
                {
                    SaveToQueue(buttonId);
                    return;
                }
                if (serviceQueue.ServiceId == 1 && buttonId == "Restaurant")
                {
                    RemoveFromQueue(buttonId);
                    return;
                }
                if (serviceQueue.ServiceId == 2 && buttonId == "Automotive")
                {
                    RemoveFromQueue(buttonId);
                    return;
                }
                if (serviceQueue.ServiceId == 3 && buttonId == "Digicel")
                {
                    RemoveFromQueue(buttonId);
                    return;
                }
                if (serviceQueue.ServiceId == 4 && buttonId == "NCBBank")
                {
                    RemoveFromQueue(buttonId);
                    return;
                }
                else
                    SaveToQueue(buttonId);
            }
        }

        //Get the Customer's number in the Queue to be displayed
        public void GetQueueNumber()
        {
            string id = getUserId();
            using (var context = new ApplicationDbContext())
            {
                var item = context.QueueOrders.Where(x => x.CustomerId == id).ToList();
                var queueOrderNumber = context.QueueOrders.Where(x => x.CustomerId == id).Count();
                int count = 0;
                while (count < queueOrderNumber)
                {
                    if (item == null)
                    {
                        return;
                    }
                    else if (item[count].ServiceQueueNumber == 1)
                        txtQueueNumber4.Text = item[count].CustomerNumber.ToString();
                    else if (item[count].ServiceQueueNumber == 2)
                        txtQueueNumber3.Text = item[count].CustomerNumber.ToString();
                    else if (item[count].ServiceQueueNumber == 3)
                        txtQueueNumber2.Text = item[count].CustomerNumber.ToString();
                    else if (item[count].ServiceQueueNumber == 4)
                        txtQueueNumber1.Text = item[count].CustomerNumber.ToString();
                    count++;
                }
            }
        }
    }
}