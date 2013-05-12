using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

namespace TmdbWrapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
            TheMovieDb.Initialise("TODO");
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
    }
}
