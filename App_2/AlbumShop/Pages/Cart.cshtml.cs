using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlbumShop.Infrastracture;
using AlbumShop.Models;

namespace AlbumShop.Pages {

    public class CartModel : PageModel {
        private IShopRepository repo;

        public CartModel(IShopRepository repo_) {
            repo = repo_;
        }

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        [HttpGet]
        public void OnGet(string returnUrl) {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
    
        //PARAMETRUL Id TEBUIE SA FIE DE ACELASI TIP SI SA AIBA EXACT ACELASI NUME CA CEL DIN REPOSITORY(Albums.Id)
        [HttpPost]
        public IActionResult OnPost(long Id, string returnUrl) {
            Album? product = repo.Albums
                .FirstOrDefault(p => p.Id == Id);
            var currentGenre = String.Empty; 
            if (product != null){
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                currentGenre = product?.Genre;
                HttpContext.Session.SetJson("cart", Cart);
            }
            ;
            return RedirectToPage(new {returnUrl = returnUrl});
        }
    }
}