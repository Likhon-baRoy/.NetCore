using Microsoft.AspNetCore.Mvc;
using RazorView.Models;

namespace RazorView.ViewComponents;

public class GridViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid)
  {
    return View(grid); /* Invoked a partial view & path is: Views/Shared/Components/Grid/Default.cshtml */
  }
}
