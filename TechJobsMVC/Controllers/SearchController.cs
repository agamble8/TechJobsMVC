using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        [HttpPost]
        //[Route("/Index")]
        // TODO #3: Create an action method to process a search request and render the updated search view. 
        public IActionResult Results(string searchType, string searchTerm)
        {
            //ViewBag.columns = ListController.ColumnChoices;
            List<Job> jobs2;

            if (string.IsNullOrEmpty(searchTerm))
            {
                jobs2 = JobData.FindAll();
            }
            else
            {
                jobs2 = JobData.FindByColumnAndValue(searchType, searchTerm);
            };

            ViewBag.jobs2 = jobs2;

            return View();
            //return View("Index");
        }
    }
}
