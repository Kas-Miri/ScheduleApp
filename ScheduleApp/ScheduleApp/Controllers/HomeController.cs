using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using ScheduleApp.DAL;
using ScheduleApp.Models;

using System.Diagnostics;
using System.Linq;

namespace ScheduleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var db = new ScheluleDB())
            {
                var model = db.Schedule
                              .Include(x => x.Discipline)
                              .Include(x => x.TimeBegin)
                              .Include(x => x.TimeEnd)
                              .ToList();

                return View(model);
            }
        }

        [Route("Discipline")]
        public IActionResult GetDisciplineList()
        {
            using (var db = new ScheluleDB())
            {
                var model = db.Discipline.ToList();
                return View("Discipline", model);
            }
        }

        [Route("Discipline"),HttpPost]
        public IActionResult CreateDiscipline(Discipline item)
        {
            using (var db = new ScheluleDB())
            {
                db.Discipline.Add(item);
                db.SaveChanges();
                var model = db.Discipline.ToList();
                return View("Discipline", model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
