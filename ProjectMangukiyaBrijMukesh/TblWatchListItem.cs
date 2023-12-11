using System;
using System.Collections.Generic;

namespace ProjectMangukiyaBrijMukesh;

public partial class TblWatchListItem
{
    public string Title { get; set; }
    public string poster { get; set; }
    public int ItemId { get; set; }

    public int ListId { get; set; }

    public string MediaId { get; set; } = null!;

    public string MediaType { get; set; } = null!;

    public int? GenreId { get; set; }

    public DateOnly AddedDate { get; set; }

    public string? Description { get; set; }

    public virtual TblGenre? Genre { get; set; }

    public virtual TblWatchList List { get; set; } = null!;
}
