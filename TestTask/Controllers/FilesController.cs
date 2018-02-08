using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Contracts.Interfaces;
using TestTask.DAL.DataBase;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class FilesController : Controller
    {

        private readonly TestTaskContext context = new TestTaskContext();
        private readonly IFilesRepository fileRepository;

        public ActionResult Index()
        {
            IList<FilesModel> model = new List<FilesModel>();

            foreach (var item in fileRepository.GetAll())
            {
                model.Add(
                    new FilesModel
                    {
                        ID_of_file = item.ID_of_file,
                        Size= item.Size,
                        Title=item.Title,
                        Way=item.Way,
                    }
                );
            }

            return View("Index", model);
        }

    }
}