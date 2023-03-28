using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tic_Tac_Toe_API.Data.Models
{
    public class GameField
    {
        [JsonPropertyName("field")]
        public int[][] field { get; set;}

        [JsonPropertyName("gameState")]
        public int gameState { get; set; }

        public GameField()
        {
            field = new int[][]
                {
                new int[] {0,0,0},
                new int[] {0,0,0},
                new int[] {0,0,0}
            };
            gameState = 2;  
        }


        //public async Task<string> FieldInString() {
        //    string json = JsonSerializer.Serialize(field);
        //    return await Task.FromResult(json);
        //}



        //public async Task AddMoveAsync(int first, int second)
        //{
        //    await Task.Run(() => field[first-1][second-1] = 1);
        //}

    }
}
