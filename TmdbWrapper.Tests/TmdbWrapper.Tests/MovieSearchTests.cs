using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

namespace TmdbWrapper.Tests
{
    [TestClass]
    public class MovieSearchTests
    {
        [TestInitialize]
        public void Initialize()
        {
            TheMovieDb.Initialise("");
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public async Task SearchMovie_GetMoviePosterUrl_PosterPathContainsHttp()
        {
            var movieResults = await TheMovieDb.SearchMovieAsync("the big lebowski");
            var url = movieResults.Results[0].Uri(Utilities.PosterSize.w92);
            Assert.IsNotNull(url.AbsoluteUri);
        }

        [TestMethod]
        public async Task SearchMovie_RepeatedSearch_CacheIsUsed()
        {
            for (int i = 0; i < 2; i++)
            {
                var movie = await TheMovieDb.GetMovieAsync(550);
                Assert.IsNotNull(movie);
            }            
        }

        [TestMethod]
        public async Task SearchMovie_GetLatestMovieSummaries_ReturnsNotNull()
        {
            var latest = await TheMovieDb.GetUpcomingMoviesAsync();

            Assert.IsNotNull(latest);
        }

        [TestMethod]
        public async Task SearchMovie_GetNowPlayingMovieSummaries_ReturnsNotNull()
        {
            var latest = await TheMovieDb.GetNowPlayingMoviesAsync();

            Assert.IsNotNull(latest);
        }

        [TestMethod]
        public async Task SearchMovie_GetTopRatedMovieSummaries_ReturnsNotNull()
        {
            var latest = await TheMovieDb.GetTopRatedMoviesAsync();

            Assert.IsNotNull(latest);
        }
    }
}
