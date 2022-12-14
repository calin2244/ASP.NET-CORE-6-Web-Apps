using AlbumShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlbumShop.Controllers{
    public class HomeController : Controller{
        private IShopRepository repo;
        
        public HomeController(IShopRepository repo_){
            repo = repo_;
        }
        public int pageSize = 3;

        [HttpPost]
        public void IncrementCount()
        {
            Console.WriteLine("a fost apasat");
            foreach(var item in repo.Albums){
                item.Price += 1;
                Console.WriteLine(item.Price);
            }
        }

        [HttpGet]
        public IActionResult Index(string? genre, int prodPage = 1){
            if(genre == null)
                genre = "Catalogue";
            return View(new AlbumsListViewModel{
                Albums = repo.Albums.Where(a => genre == "Catalogue"  || a.Genre.Replace("/", "-") == genre). 
                OrderBy(a => a.Id).Skip((prodPage - 1) * pageSize).Take(pageSize),
                PageInfo = new PageInfo{
                    CurrentPage = prodPage,
                    ItemsPerPage = pageSize,
                    TotalItems = genre == "Catalogue" ? repo.Albums.Count() : repo.Albums.
                    Where(g => g.Genre.Replace("/", "-") == genre).Count()
                },
                CurrentGenre = genre
            });
        }

        [HttpPost]
        public IActionResult Index(string? genre, IShopRepository repo_, int prodPage = 1){
            if(genre == null)
                genre = "Catalogue";
            repo_ = repo;
            return View(new AlbumsListViewModel{
                Albums = repo_.Albums.Where(a => genre == "Catalogue"  || a.Genre.Replace("/", "-") == genre). 
                OrderBy(a => a.Id).Skip((prodPage - 1) * pageSize).Take(pageSize),
                PageInfo = new PageInfo{
                    CurrentPage = prodPage,
                    ItemsPerPage = pageSize,
                    TotalItems = genre == "Catalogue" ? repo_.Albums.Count() : repo_.Albums.
                    Where(g => g.Genre.Replace("/", "-") == genre).Count()
                },
                CurrentGenre = genre
            });
        }

        // [HttpPost]
        // public IActionResult Index(){
        //     return PartialView("AlbumSummary", repo);
        // }

        public ViewResult Home(){
            return View();
        }
    }
}