﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmdbWrapper.Utilities;
using Windows.Data.Json;

namespace TmdbWrapper.Persons
{
    /// <summary>
    /// Member of the crew.
    /// </summary>
    public class Crew : ITmdbObject
    {
        #region properties
        /// <summary>
        /// Id of the movie.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Title of the movie.
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// Name of the department.
        /// </summary>
        public string Department { get; private set; }
        /// <summary>
        /// Original title
        /// </summary>
        public string OriginalTitle { get; private set; }
        /// <summary>
        /// Name of the job.
        /// </summary>
        public string Job { get; private set; }
        /// <summary>
        /// Path of the poster of the movie.
        /// </summary>
        public string PosterPath { get; private set; }
        /// <summary>
        /// Date of the original release.
        /// </summary>
        public string ReleaseDate { get; private set; }
        /// <summary>
        /// Indictates if then movie is an adult title.
        /// </summary>
        public bool Adult { get; private set; }
        #endregion

        #region interface implementations
        void ITmdbObject.ProcessJson(JsonObject jsonObject)
        {
            Id = (int)jsonObject.GetSafeNumber("id");
            Title = jsonObject.GetSafeString("title");
            Department = jsonObject.GetSafeString("department");
            OriginalTitle = jsonObject.GetSafeString("original_title");
            Job = jsonObject.GetSafeString("job");
            PosterPath = jsonObject.GetSafeString("poster_path");
            ReleaseDate = jsonObject.GetSafeString("release_date");
            Adult = jsonObject.GetSafeBoolean("adult");
        }
        #endregion

        #region image uri's 
        /// <summary>
        /// Uri to the poster image.
        /// </summary>
        /// <param name="size">The size for the image as required</param>
        /// <returns>The uri to the sized image</returns>
        public Uri Uri(PosterSize size)
        {
            return Utilities.Extensions.MakeImageUri(size.ToString(), PosterPath);
        }
        #endregion

        #region navigation properties
        /// <summary>
        /// Retrieves the associated movie.
        /// </summary>
        public async Task<Movies.Movie> MovieAsync()
        {
            return await TheMovieDb.GetMovieAsync(Id);
        }
        #endregion
    }
}
