using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumShop.Models{
    public class Album{
        public long? ProductID{get; set;}
        public string Description{get; set;} = String.Empty;
        public string AlbumName{get; set;} = String.Empty;
        public string ArtistName{get; set;} = String.Empty;
        public string RecordType{get; set;} = String.Empty;

        [Column(TypeName = "decimal(8,2)")]
        public decimal? Rating{get; set;}
        
    }
}