using System;
using System.Runtime.InteropServices;
using Xunit;

namespace TacoParser.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638,-84.677017,Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        // Test for parsing longitude
        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...",-84.683302)]
        public void ShouldParseLongitude(string line, double expected)
        {

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line);
            
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //Test for parsing latitude
        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", 34.073638)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...",34.035985)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();
            
            //Act
            var actual = tacoParser.Parse(line);
            
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }
        


    }
}
