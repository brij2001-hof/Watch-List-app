using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMangukiyaBrijMukesh
{
    public class spByWatchList
    {

        public string? MediaId { get; set; }
        public int? ItemId { get; set; }
        public string? MediaType { get; set; }
        public string? Description { get; set; }
        public int? ListId { get; set; }
        public string? Title { get; set; }
        public string? Poster { get; set; }
    }
}
