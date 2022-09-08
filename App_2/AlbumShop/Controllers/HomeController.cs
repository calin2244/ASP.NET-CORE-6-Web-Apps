using AlbumShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlbumShop.Controllers{
    public class HomeController : Controller{
        private IShopRepository repo;
        
        public HomeController(IShopRepository repo_){
            repo = repo_;
        }
        public int pageSize = 3;
        public ViewResult Index(string? genre, int prodPage = 1){
            if(genre == null)
                genre = "Catalogue";
            
            return View(new AlbumsListViewModel{
                Albums = repo.Albums.Where(a => genre == "Catalogue"  || a.Genre.Replace("/", "-") == genre). 
                OrderBy(a => a.Id).Skip((prodPage - 1) * pageSize).Take(pageSize),
                PageInfo = new PageInfo{
                    CurrentPage = prodPage,
                    ItemsPerPage = pageSize,
                    TotalItems = repo.Albums.Count()
                },
                CurrentGenre = genre
            });
        }

        public ViewResult Home(){
            return View();
        }
    }
}