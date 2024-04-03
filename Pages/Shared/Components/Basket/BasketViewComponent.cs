using System.Text.Json;
using Bakery.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Bakery.Pages.Components.Basket;
public class BasketViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        Models.Basket basket = new();
        if (Request.Cookies[nameof(Basket)] is not null)
        {
            basket = JsonSerializer.Deserialize<Models.Basket?>(Request.Cookies[nameof(Basket)]!);
        }
        return View(basket);
    }
}

//public class BasketViewComponent : ViewComponent
//{
//    private readonly BakeryContext context;
//    public BasketViewComponent(BakeryContext context)
//    {
//        this.context = context;
//    }
//    public async Task<IViewComponentResult> InvokeAsync()
//    {
//        var data = await context.Products.ToListAsync();
//        return View(data);
//    }
//}