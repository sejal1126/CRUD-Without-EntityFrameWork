using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public string Name(string name )
        {
            return "Welcome to "+name;
        }
        public string FullName(string FirstName,string LastName=null)
        {
            string profile = string.Empty;
            if(FirstName!=null && LastName!=null)
                profile= "Your First name is =" + FirstName + " and Last name is = " + LastName;
            else if (FirstName != null)
                profile= "Your First name is =" + FirstName;
            else if(LastName!=null)
                profile= "Last name is = " + LastName;

            return profile;

        }
    }
}