using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    public interface IBoard
    {
        void PutPiece(ColouredPiece piece, Square square);

        void RemovePiece(Square square);

        ColouredPiece GetPiece(Square square);
    }
}
