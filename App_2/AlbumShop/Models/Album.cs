using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumShop.Models{
    public class Album{
        public long? Id{get; set;}
        public string AlbumName{get; set;} = String.Empty;
        public string ArtistName{get; set;} = String.Empty;
        public string Description{get; set;} = String.Empty;
        public string RecordType{get; set;} = String.Empty;

        //[Column(TypeName = "double(8,2)")] //decimal of precision 8 and a scale of 2
        public double? Rating{get; set;}

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price{get; set;}
        
    }
}