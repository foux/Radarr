using System;
using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Core.Languages;
using NzbDrone.Core.Parser.Augmenters;
using NzbDrone.Core.Parser.Model;

namespace NzbDrone.Core.Test.ParserTests.ParsingServiceTests.AugmentersTests
{
    [TestFixture]
    public class AugmentWithOriginalLanguageFixture : AugmentMovieInfoFixture<AugmentWithOriginalLanguage>
    {
        [Test]
        public void should_add_movie_original_language()
        {
            var releaseInfo = new ParsedMovieInfo();
            var remoteMovie = new RemoteMovie
            {
                Movie = new Movies.Movie
                {
                    OriginalLanguage = Language.English
                }
            };
            var result = Subject.AugmentMovieInfo(releaseInfo, remoteMovie);
            result.ExtraInfo.Should().ContainKey("OriginalLanguage");
            result.ExtraInfo["OriginalLanguage"].Should().Be(Language.English);
        }
    }
}
