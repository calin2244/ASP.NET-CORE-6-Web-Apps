namespace AlbumShop.Models{
    public class EFShopRepo : IShopRepository{
        private ShopDbContext context;
        public EFShopRepo(ShopDbContext context_){
            context = context_;
        }

        public IQueryable<Album> Albums => context.Albums;
        public int AlbumsCount(){
            return Albums.Count(); 
        }
    }
}