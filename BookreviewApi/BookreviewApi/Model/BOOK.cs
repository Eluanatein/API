using Microsoft.VisualBasic.FileIO;

namespace BookreviewApi.Model
{
    public class BOOK
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Datepublished { get; set; }

        public  ICollection<RATING> RATINGS { get; set; }
    }
}
