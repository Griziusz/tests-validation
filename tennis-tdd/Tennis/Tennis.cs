using System;

namespace Tennis
{
    public class Tennis()
    {
        public string getScore(int player1Points, int player2Points)
        {
            if (player1Points < 0 || player2Points < 0)
                throw new ArgumentException("Les points doivent êtres positifs");

            if ((player1Points < 3 && player2Points < 3)
                || (player1Points == 3 && player2Points < 3)
                || (player1Points < 3 && player2Points == 3))
            {
                return $"{PointsToScore(player1Points)}-{PointsToScore(player2Points)}";
            }
            if (player1Points == 4 && player2Points < 3)
            {
                return "Jeu";
            }
            if (player1Points < 3 && player2Points == 4)
            {
                return "Jeu";
            }
            if (player1Points == player2Points)
            {
                return "40A";
            }
            if (player1Points == player2Points + 1
                || player1Points + 1 == player2Points)
            {
                return "Avantage";
            }
            if (player1Points == player2Points + 2
                || player1Points + 2 == player2Points)
            {
                return "Jeu";
            }
            throw new ArgumentException("Combinaison impossible");
        }

        private int PointsToScore(int points)
        {
            return points switch
            {
                0 => 0,
                1 => 15,
                2 => 30,
                3 => 40,
                _ => throw new Exception("Points should be between 0 and 3")
            };
        }
    }
}