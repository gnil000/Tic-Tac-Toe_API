using Tic_Tac_Toe_API.Data.Models;

namespace Tic_Tac_Toe_API.Data
{
    public class DataSource
    {
        private static DataSource _instance;

        private DataSource() { }

        public static DataSource GetInstance()
        {
            if (_instance == null)
                return _instance = new DataSource();
            return _instance;
        }

        public GameField _gameField = new GameField();

    }
}
