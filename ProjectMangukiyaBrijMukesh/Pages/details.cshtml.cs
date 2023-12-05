using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.TvShows;

namespace ProjectMangukiyaBrijMukesh
{
    public class detailsModel : PageModel
    {
        private readonly ProjectMangukiyaBrijMukesh.Bmangukiya1Context _context;
        public detailsModel(ProjectMangukiyaBrijMukesh.Bmangukiya1Context context)
        {
            _context = context;
        }
        public SelectList watchlists { get; set; } = default!;

        public async Task OnGetAsync(string type, string id)
        {
            var a = ApiAccess.ApiKey;
            TMDbClient client = new TMDbClient(a);
            TMDbConfig config = client.GetConfigAsync().Result;
            //System.Diagnostics.Debug.WriteLine(type + id);

            if (type == "tv")
            {
                int id1 = Convert.ToInt32(id);
                TvShow show = await client.GetTvShowAsync(id1, TvShowMethods.Images);
                ViewData["MediaId"] = show.Id;
                ViewData["Title"] = show.Name;
                ViewData["GenreId"] = show.Genres[0].Id;
                ViewData["Poster"] = client.GetImageUrl("original", show.Images.Posters[0].FilePath).ToString();
                ViewData["Overview"] = show.Overview;
                ViewData["ReleaseDate"] = show.FirstAirDate.Value.ToString("d");
                try { ViewData["Runtime"] = show.EpisodeRunTime[0]; }
                catch { ViewData["Runtime"] = "N/A"; }
                try
                {
                    ViewData["ImdbLink"] = "https://www.imdb.com/title/" + show.ExternalIds.ImdbId;
                }
                catch { ViewData["ImdbLink"] = "N/A"; }
                ViewData["Type"] = "TV Show";
            }
            else if (type == "movie")
            {
                Movie movie = await client.GetMovieAsync(id, MovieMethods.Images);
                ViewData["MediaId"] = movie.Id;
                ViewData["GenreId"] = movie.Genres[0].Id;
                ViewData["Title"] = movie.Title;
                ViewData["Poster"] = client.GetImageUrl("original", movie.Images.Posters[0].FilePath).ToString();
                ViewData["Overview"] = movie.Overview;
                ViewData["ReleaseDate"] = movie.ReleaseDate.Value.ToString("d");
                ViewData["Runtime"] = movie.Runtime;
                ViewData["ImdbLink"] = "https://www.imdb.com/title/" + movie.ImdbId;
                ViewData["Type"] = "Movie";
            }
            watchlists = new SelectList(_context.TblWatchLists, "ListId", "Name");

        }
        public TblWatchListItem TblWatchListItem { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            string Listid = Request.Form["selected"].ToString();
            TblWatchListItem = new TblWatchListItem();
            TblWatchListItem.ListId = Convert.ToInt32(Listid);
            TblWatchListItem.MediaId = Request.Form["id"].ToString();
            System.Diagnostics.Debug.WriteLine(Request.Form["genreid"]);
            TblWatchListItem.GenreId = Convert.ToInt32(Request.Form["genreid"]);
            TblWatchListItem.MediaType = Request.Form["mediaType"].ToString();
            TblWatchListItem.Description = Request.Form["overview"].ToString(); ;
            TblWatchListItem.AddedDate = DateOnly.FromDateTime(DateTime.Now);
            _context.TblWatchListItems.Add(TblWatchListItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("/watchlist");
        }
    }
}
