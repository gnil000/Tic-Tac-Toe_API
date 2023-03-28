using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tic_Tac_Toe_API.Data.Models;
using Tic_Tac_Toe_API.Data.Services;

namespace Tic_Tac_Toe_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameFieldController : Controller
    {
        private readonly GameFieldService _context;

        public GameFieldController(GameFieldService context) {
            _context = context;
        }


        [Authorize]
        [HttpGet]
        public async Task<GameField> GetGameField() { 
            return await _context.GetGameField();
        }

        //[HttpPost("{first}/{second}")]
        //public async Task<IActionResult> AddMove(string first, string second) {
        //    int firstNum = Convert.ToInt16(first);
        //    int secondNum = Convert.ToInt16(second);
        //    await _context.AddMoveField(firstNum, secondNum);
        //    return Ok();
        //}


        [HttpPost("{first}/{second}")]
        public async Task<GameField> AddMove(string first, string second)
        {
            int firstNum = Convert.ToInt16(first);
            int secondNum = Convert.ToInt16(second);
            await _context.AddMoveField(firstNum, secondNum);
            return await _context.GetGameField();
        }

        [HttpPost]
        public async Task<GameField> AddMove(GameField gameField)
        {
            await _context.AddMoveField(gameField);
            return await _context.GetGameField();
        }


    }
}
