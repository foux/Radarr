using System;
using NzbDrone.Core.Parser.Model;

namespace NzbDrone.Core.Parser.Augmenters
{
    public class AugmentWithOriginalLanguage : IAugmentParsedMovieInfo
    {
        public Type HelperType
        {
            get
            {
                return typeof(RemoteMovie);
            }
        }

        public ParsedMovieInfo AugmentMovieInfo(ParsedMovieInfo movieInfo, object helper)
        {
            if (helper is RemoteMovie remoteMovie && remoteMovie?.Movie?.OriginalLanguage != null)
            {
                movieInfo.ExtraInfo["OriginalLanguage"] = remoteMovie.Movie.OriginalLanguage;
            }

            return movieInfo;
        }
    }
}
