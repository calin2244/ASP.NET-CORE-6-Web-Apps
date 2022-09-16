using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlbumShop.Infrastracture;
using AlbumShop.Models;

namespace AlbumShop.Pages {

    public class CartModel : PageModel {
        private IShopRepository repository;

        public CartModel(IShopRepository repo) {
            repository = repo;
        }

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl) {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        //PARAMETRUL Id TEBUIE SA FIE DE ACELASI TIP SI SA AIBA EXACT ACELASI NUME CA CEL DIN REPOSITORY(Albums.Id)
        public IActionResult OnPost(long Id, string returnUrl) {
            Album? product = repository.Albums
                .FirstOrDefault(p => p.Id == Id);
                
            if (product != null){
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}