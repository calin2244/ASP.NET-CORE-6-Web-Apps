namespace AlbumShop.Models{
    public class Album{
        public long? ProductID{get; set;}
        public string Description{get; set;} = String.Empty;
        public string AlbumName{get; set;} = String.Empty;
        public string ArtistName{get; set;} = String.Empty;
        public string RecordType{get; set;} = String.Empty;
        public decimal? Rating{get; set;}
    }
}