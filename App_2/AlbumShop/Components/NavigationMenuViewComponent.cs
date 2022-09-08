using Microsoft.AspNetCore.Mvc;

namespace AlbumShop.Components{
    public class NavigationMenuViewComponent : ViewComponent{
        private IShopRepository repository;

        public NavigationMenuViewComponent(IShopRepository repository_){
            repository = repository_;
        }

        public IViewComponentResult Invoke(){
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            ViewBag.SelectedPage = RouteData?.Values["prodPage"];
            ViewBag.SelectedAction = RouteData?.Values["action"];
            return View(repository.Albums.Select(a => a.Genre).Distinct().OrderBy(a => a));
        }
    }
}