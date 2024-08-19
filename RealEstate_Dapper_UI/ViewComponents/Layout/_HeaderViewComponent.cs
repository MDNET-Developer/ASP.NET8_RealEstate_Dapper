using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Layout
{
    public class _HeaderViewComponent : ViewComponent
    {
        //Header Partial component
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
