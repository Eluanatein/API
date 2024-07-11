namespace BookreviewApi.Model
{
    public class RATING
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public DateTime DatePublished { get; set; }
        public int BookId { get; set; }
        public  BOOK Book { get; set; }

        public int UserId { get; set; }
        public USER User { get; set; } 
    }
}