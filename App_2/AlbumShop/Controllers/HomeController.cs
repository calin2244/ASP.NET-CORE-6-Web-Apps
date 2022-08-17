using AlbumShop.Models.ViewModels;

namespace AlbumShop.Controllers{
    public class HomeController : Controller{
        private IShopRepository repo;
        
        public HomeController(IShopRepository repo_){
            repo = repo_;
        }

        public int pageSize = 3;
        public IActionResult Index(int prodPage = 1){
            return View(new AlbumsListViewModel{
                Albums = repo.Albums.OrderBy(a => a.Id).Skip((prodPage - 1) * pageSize).Take(pageSize),
                PageInfo = new PageInfo{
                    CurrentPage = prodPage,
                    ItemsPerPage = pageSize,
                    TotalItems = repo.Albums.Count()
                }
            });
        }
    }
}