using System;

namespace Gladiator.Representation
{
    public static class SquareDistanceExtensions
    {
        private static readonly int[] manhattanDistancesToCenter = new int[] {
          6, 5, 4, 3, 3, 4, 5, 6,
          5, 4, 3, 2, 2, 3, 4, 5,
          4, 3, 2, 1, 1, 2, 3, 4,
          3, 2, 1, 0, 0, 1, 2, 3,
          3, 2, 1, 0, 0, 1, 2, 3,
          4, 3, 2, 1, 1, 2, 3, 4,
          5, 4, 3, 2, 2, 3, 4, 5,
          6, 5, 4, 3, 3, 4, 5, 6
        };

        public static int ManhattanDistanceToCenter(this Square square)
        {
            return manhattanDistancesToCenter[square.GetValue()];
        }
    }
}
