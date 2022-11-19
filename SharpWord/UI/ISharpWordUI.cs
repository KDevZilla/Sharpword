using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpWord.Game;
namespace SharpWord.UI
{
    public interface ISharpWordUI
    {
        void SetGame(SharpWordGame pGame);
        void CreateTiles();
        void CreateKeyBoard();
        void CreateBoard();
        void RenderWin();
        void RenderLost();
        void RenderIncorrectRow(int pRowIndexIncorrect);
        void RenderCurrentWord(String str);
        void RenderKeyBoard(Dictionary<Char, AlphaResult> pDicTriecChar);
        void RenderAttemptWord();
        void RemoveChar(int Row, int Col);
        void SetTheme(Theme pTheme);
        Boolean IsFinishProcessing();
        void BlockInput();
        void UnBlockInput();
        void ClearUI();
        void ShowStatistics(Statistics statis);
        Boolean IsInputBlocked();
    }
}
