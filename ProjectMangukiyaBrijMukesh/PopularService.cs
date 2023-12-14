using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace ProjectMangukiyaBrijMukesh
{
    public class PopularService
    {
        public async Task<List<PopularModel>> GetPopular()
        {
            List<PopularModel> popular = new List<PopularModel>();
            var a = ApiAccess.ApiKey;
            TMDbClient client = new TMDbClient(a);
            TMDbConfig config = client.GetConfigAsync().Result;
            for(int page=1; page < 5; page++)
            {
                SearchContainer<SearchBase> results = client.GetTrendingAllAsync(TMDbLib.Objects.Trending.TimeWindow.Week, page).Result;

                for (int i = 0; i < 20; i++)
                {
                    if (results.Results[i].MediaType == MediaType.Movie)
                    {
                        Movie movie = await client.GetMovieAsync(results.Results[i].Id, MovieMethods.Images);
                        System.Diagnostics.Debug.WriteLine(i + $"{movie.Title}");

                        foreach (var item in movie.Images.Posters)
                        {
                            if (item.Iso_639_1 == "en")
                            {
                                popular.Add(new PopularModel { Title = movie.Title, Poster = client.GetImageUrl("w500", item.FilePath).ToString(), Id = movie.Id.ToString(), Type = "movie" });
                                break;
                            }
                        }

                    }
                    else if (results.Results[i].MediaType == MediaType.Tv)
                    {
                        TvShow show = await client.GetTvShowAsync(results.Results[i].Id, TvShowMethods.Images);
                        System.Diagnostics.Debug.WriteLine(i + $"{show.Name}");
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
            

            return await Task.FromResult(popular);
        }
    }
}
