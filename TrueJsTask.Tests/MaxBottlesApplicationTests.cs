using System;
using Xunit;

namespace TrueJsTask.Tests
{
    public class MaxBottlesApplicationTests
    {
        [Theory]
        [InlineData("5 4", 6)]
        [InlineData("15 4", 19)]
        [InlineData("35 4", 46)]
        [InlineData("15 6", 17)]
        [InlineData("45 7", 52)]
        [InlineData("120 10", 133)]
        [InlineData("120 7", 139)]
        public void RunWithValidArgs(string args, int result)
        {
            var app = new MaxBottlesApplication();
            var appResult = app.Run(args);

            Assert.Equal(appResult, result);

        }

        [Fact]
        public void RunWithInvalidArg()
        {
            Assert.ThrowsAny<Exception>(() =>
            {
                var app = new MaxBottlesApplication();
                var appResult = app.Run(string.Empty);
            });
        }
    }
}