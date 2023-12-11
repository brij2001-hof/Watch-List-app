using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace ProjectMangukiyaBrijMukesh.Pages
{
    public class SearchModel : PageModel
    {

        public List<PopularModel> popular = new List<PopularModel>();
        public async Task OnGetAsync(string query)
        {


            var a = ApiAccess.ApiKey;
            TMDbClient client = new TMDbClient(a);
            TMDbConfig config = client.GetConfigAsync().Result;
            ViewData["query"] = query;
            SearchContainer<SearchMovie> search = client.SearchMovieAsync(query).Result;
            //int abc = 0;
            //foreach (var item in results.Results)
            //{
            //    abc++;
            //    System.Diagnostics.Debug.WriteLine(abc, item.MediaType.ToString());
            //}
            foreach(var results in search.Results)
            {
                if (results.MediaType == MediaType.Movie)
                {
                    Movie movie = await client.GetMovieAsync(results.Id, MovieMethods.Images);
                    System.Diagnostics.Debug.WriteLine(  $"{movie.Title}");

                    foreach (var item in movie.Images.Posters)
                    {
                        if (item.Iso_639_1 == "en")
                        {
                            popular.Add(new PopularModel { Title = movie.Title, Poster = client.GetImageUrl("w500", item.FilePath).ToString(), Id = movie.Id.ToString(), Type = "movie" });
                            break;
                        }
                    }
                }
                else if (results.MediaType == MediaType.Tv)
                {
                    TvShow show = await client.GetTvShowAsync(results.Id, TvShowMethods.Images);
                    System.Diagnostics.Debug.WriteLine($"{show.Name}");
                    foreach (var item in show.Images.Posters)
                    {
                        if (item.Iso_639_1 == "en")
                        {
                            popular.Add(new PopularModel { Title = show.Name, Poster = client.GetImageUrl("w500", item.FilePath).ToString(), Id = show.Id.ToString(), Type = "tv" });
                            break;
                        }
                    }
                }

            }
        }
    }
}
