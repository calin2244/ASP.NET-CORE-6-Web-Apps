namespace AlbumShop.Models {

    public class Cart {

        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem(Album product, int quantity) {
            CartLine? line = Lines
                .Where(a => a.Album.Id == product.Id)
                .FirstOrDefault();

            if (line == null) {
                Lines.Add(new CartLine {
                    Album = product,
                    Quantity = quantity
                });
            } else {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Album product) =>
            Lines.RemoveAll(l => l.Album.Id == product.Id);

        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Album.Price * e.Quantity);

        public void Clear() => Lines.Clear();
    }

    public class CartLine {
        public int CartLineID { get; set; }
        public Album Album { get; set; } = new();
        public int Quantity { get; set; }
    }
}