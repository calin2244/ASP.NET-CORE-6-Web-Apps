namespace AlbumShop.Models{
    public interface IShopRepository{
        IQueryable<Album> Albums{get;}
    }
}