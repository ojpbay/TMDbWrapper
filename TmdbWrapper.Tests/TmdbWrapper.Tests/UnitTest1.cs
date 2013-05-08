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
        [TestMethod]
        public async Task TestMethod1()
        {
            TheMovieDb.Initialise("TODO");

            var results = await TheMovieDb.SearchMovieAsync("lebowski");

            if (results != null)
            {
            }
        }
    }
}
