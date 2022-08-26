namespace BookLibValidatorUnitTest
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return Id + " " + Title + " " + Price;
        }

        public void ValidatePrice()
        {
            if (Price < 0)
                throw new ArgumentOutOfRangeException("price must be non-negative: " + Price);
        }

        public void ValidateTitle()
        {
            if (Title == null)
                throw new ArgumentNullException("title is null");
            if (Title.Length < 1)
                throw new ArgumentException("title must be at least 1 character: " + Title);
        }

        public void Validate()
        {
            ValidatePrice();
            ValidateTitle();
        }
    }
}