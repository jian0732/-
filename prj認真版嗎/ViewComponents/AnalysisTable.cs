using Microsoft.AspNetCore.Mvc;
using prjMvcCoreModel.ViewModel;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewComponents
{
    public class AnalysisTableViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<C年份營業額統計> x)
        {
            return View(x);
        }
    }
}
