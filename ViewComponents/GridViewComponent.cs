using Microsoft.AspNetCore.Mvc;

namespace RazorView.ViewComponents;

public class GridViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View(); /* Invoked a partial view & path is: Views/Shared/Components/Grid/Default.cshtml */
  }
}
