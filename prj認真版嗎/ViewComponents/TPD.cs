using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewComponents
{
    public class TPDViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult>InvokeAsync()
        {
            return View();
        }
    }
}
