using System.Text.Json;
using Tic_Tac_Toe_API.Data.Models;

namespace Tic_Tac_Toe_API.Data.Services
{
    public class GameFieldService
    {
        Random rand = new Random();

        public async Task AddMoveField(GameField gameField)
        {
            await Task.Run(() => DataSource.GetInstance()._gameField.field = gameField.field);

            DataSource.GetInstance()._gameField.gameState = GameOver(DataSource.GetInstance()._gameField.field);

            if (DataSource.GetInstance()._gameField.gameState == 2)
            {
                //компьютер ставит свой ход
                int first, second;
                do
                {
                    first = rand.Next(1, 4);
                    second = rand.Next(1, 4);
                } while (DataSource.GetInstance()._gameField.field[first - 1][second - 1] != 0);
                DataSource.GetInstance()._gameField.field[first - 1][second - 1] = -1;
            }
            DataSource.GetInstance()._gameField.gameState = GameOver(DataSource.GetInstance()._gameField.field);
        }


        public async Task AddMoveField(int first, int second)
        {
            await Task.Run(() => DataSource.GetInstance()._gameField.field[first - 1][second - 1] = 1);

            //компьютер ставит свой ход
            do {
                first = rand.Next(1, 4);
                second = rand.Next(1, 4);
            } while (DataSource.GetInstance()._gameField.field[first - 1][second - 1] != 0);
            DataSource.GetInstance()._gameField.field[first - 1][second - 1] = -1;

            DataSource.GetInstance()._gameField.gameState = GameOver(DataSource.GetInstance()._gameField.field);
        }

        //public async Task<string> GetGameField()
        //{
        //    string json = JsonSerializer.Serialize(DataSource.GetInstance()._gameField);
        //    return await Task.FromResult(json);
        //}


        public async Task<GameField> GetGameField()
        {
            //string json = JsonSerializer.Serialize(DataSource.GetInstance()._gameField);
            return await Task.FromResult(DataSource.GetInstance()._gameField);
        }


        //функция определения победы/поражения/ничьей
        int GameOver(int[][] arr)
        {
            //1 - победа
            //-1 - поражение
            //0 - ничья
            //2 - нихуя
            int sum = 0;
            for (int i = 0; i < 3; i++)
            { //проверка по горизонтали
                sum = 0;
                for (int j = 0; j < 3; j++)
                    sum += arr[i][j];

                if (sum == 3)
                    return 1;
                else if (sum == -3)
                    return -1;
            }
            for (int i = 0; i < 3; i++) //проверка по вертикали
            {
                sum = 0;
                for (int j = 0; j < 3; j++)
                    sum += arr[j][i];

                if (sum == 3)
                    return 1;
                else if (sum == -3)
                    return -1;
            }

            sum = 0;
            for (int i = 0; i < 3; i++) //проверка по главной диагонали
            {
                sum += arr[i][i];
                if (sum == 3)
                    return 1;
                else if (sum == -3)
                    return -1;
            }

            sum = 0;
            for (int i = 0; i < 3; i++) //проверка по побочной диагонали
            {
                sum += arr[i][2 - i];
                if (sum == 3)
                    return 1;
                else if (sum == -3)
                    return -1;
            }


            foreach (var i in arr) //если остался нулевой элемент, значит партия не окончена
                foreach (var j in i)
                    if (j == 0)
                        return 2;

            return 0;
        }


    }
}
