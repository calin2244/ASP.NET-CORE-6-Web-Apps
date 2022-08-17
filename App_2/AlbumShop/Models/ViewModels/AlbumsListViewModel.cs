namespace AlbumShop.Models.ViewModels{
    public class AlbumsListViewModel{
        public IEnumerable<Album> Albums {get; set;} = Enumerable.Empty<Album>();
        public PageInfo PageInfo {get; set;} = new();
    }

}