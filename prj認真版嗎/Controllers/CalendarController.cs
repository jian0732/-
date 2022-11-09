using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            C行事曆 s = new C行事曆() {
            title="123",
            start="2022-11-04",
            end = "2022-11-05",
            };

 
            return View();
        }

       
    }
}
