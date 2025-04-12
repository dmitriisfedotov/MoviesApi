namespace MoviesApi.Shared
{
    public class Director
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required DateTime BirthDate { get; set; }
        public required Movie Filmography { get; set; }
        public required string Biography { get; set; }


    }
}
