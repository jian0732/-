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
    public class CustomerViewViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(List<CMember> x)
        {
            return View(x);  
        }
    }
}
