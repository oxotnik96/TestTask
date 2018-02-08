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
    public class HomeController : Controller
    {
        private readonly TestTaskContext context = new TestTaskContext();
        private readonly IMainLogRepository mainLogRepository;

        private readonly IFilesRepository fileRepository;
        private readonly IIPAdressRepository ipadressRepository;

        public HomeController()
        {
            mainLogRepository = new MainLogRepositories(context);
            fileRepository = new FilesRepositories(context);
            ipadressRepository = new IPAdressRepositories(context);
        }

        public ActionResult Index()
        {
            IList<MainLogModel> model = new List<MainLogModel>();
            
           
            foreach (var item in mainLogRepository.GetAll())
            {
                model.Add(
                    new MainLogModel
                    {
                        ID = item.ID,
                        date = item.date,
                        result = item.result,
                        type = item.type,
                        IPAdressId = item.IdAdress,
                        FilesId = item.IdFiles,
                        Files = fileRepository.GetAll(),
                        IPAdress = ipadressRepository.GetAll(),
                    }
                );
            }
            
            return View("Index", model);
        }
        
    }
}