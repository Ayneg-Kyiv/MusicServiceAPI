using MusicService.Core.Models.Abstract;

namespace MusicService.Core.Models.Connective
{
    public class GenreAuthor : BaseModel
    {
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
