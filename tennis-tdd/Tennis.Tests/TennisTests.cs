using Xunit;
using Tennis;

namespace Tennis.UnitTests
{
    public class TennisTests
    {
        private Tennis _tennis = new Tennis();

        [Theory]

        [InlineData(0, 0, "0-0")]
        [InlineData(0, 1, "0-15")]
        [InlineData(0, 2, "0-30")]
        [InlineData(0, 3, "0-40")]
        [InlineData(0, 4, "Jeu")]

        [InlineData(1, 0, "15-0")]
        [InlineData(1, 1, "15-15")]
        [InlineData(1, 2, "15-30")]
        [InlineData(1, 3, "15-40")]
        [InlineData(1, 4, "Jeu")]

        [InlineData(2, 0, "30-0")]
        [InlineData(2, 1, "30-15")]
        [InlineData(2, 2, "30-30")]
        [InlineData(2, 3, "30-40")]
        [InlineData(2, 4, "Jeu")]

        [InlineData(3, 0, "40-0")]
        [InlineData(3, 1, "40-15")]
        [InlineData(3, 2, "40-30")]
        [InlineData(3, 3, "40A")]
        [InlineData(3, 4, "Avantage")]
        [InlineData(3, 5, "Jeu")]

        [InlineData(4, 0, "Jeu")]
        [InlineData(4, 1, "Jeu")]
        [InlineData(4, 2, "Jeu")]
        [InlineData(4, 3, "Avantage")]
        [InlineData(4, 4, "40A")]
        [InlineData(4, 5, "Avantage")]
        [InlineData(4, 6, "Jeu")]
        public void CalculatePoints_ShouldWork(int player1Points, int player2Points, string expectedString)
        {
            var score = _tennis.getScore(player1Points, player2Points);

            Assert.Equal(expectedString, score);
        }
    }
}