using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Contracts.Interfaces;
using TestTask.DAL.DataBase;
using TestTask.DAL.Repositories;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class IPAdressController : Controller
    {

        private readonly TestTaskContext context = new TestTaskContext();
        private readonly IIPAdressRepository ipadress;

        public IPAdressController()
        {
            ipadress = new IPAdressRepositories(context);
        }

        public ActionResult Index()
        {
            IList<IPAdressModel> model = new List<IPAdressModel>();

            foreach (var item in ipadress.GetAll())
            {
                model.Add(
                    new IPAdressModel
                    {
                        ID_IP = item.ID_IP,
                        IP = item.IP,
                        Name_of_company = item.Name_of_company,
                    }
                );
            }

            return View("Index", model);
        }

    }
}