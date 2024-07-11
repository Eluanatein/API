namespace BookreviewApi.Model
{
    public class USER
    {
        public int Id { get; set; }
        public  string Username { get; set; }
        public ICollection<RATING>? RATINGS { get; set; }
    }
}