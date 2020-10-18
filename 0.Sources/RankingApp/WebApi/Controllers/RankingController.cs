using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    // REST (REpresentational State Transfer)
    // 공식 표준 사양은 아니나,
    // 원래 있던 HTTP 통신에서 기능을 '재사용'해서 데이터 송수신 규칙을 만든 것

    // CRUD에 대한 규칙을 지정함
    // VERB (GET, POST, PUT, DELETE 등 ...)

    // Create
    // POST /api/ranking
    // => 아이템 생성 요청 (Body에 실제 정보)

    // Read
    // GET /api/ranking
    // => 모든 아이템 읽기
    // GET /api/ranking/1
    // => id=1 인 아이템을 읽기

    // Update
    // PUT /api/ranking (※참고 : PUT 보안 문제로 웬에서는 활용되지 않음)
    // => 아이템 갱신 요청 (Body에 실제 정보)

    // Delete
    // DELETE /api/ranking/1 (※참고 : DELETE 보안 문제로 웬에서는 활용되지 않음)
    // => id=1 인 아이템 삭제

    // ApiController 특징
    // 그냥 c# 객체로 반환해도 됨
    // null 반환 => 204 Response (not content)
    // string => text/plain
    // 나머지 (int, bool 등 ...) => appication/json

    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create
        [HttpPost]
        public GameResult AddGameResult([FromBody] GameResult gameResult)
        {
            gameResult.Date = DateTime.Now;

            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return gameResult;
        }

        // Read
        [HttpGet]
        public List<GameResult> GetGameResults()
        {
            List<GameResult> results = _context.GameResults.OrderByDescending(x => x.Score).ToList();
            
            return results;
        }

        [HttpGet("{id}")]
        public GameResult GetGameResult(int id)
        {
            GameResult result = _context.GameResults.Where(x => x.Id == id).FirstOrDefault();
            
            return result;
        }

        // Update
        [HttpPut]
        public bool UpdateGameResult([FromBody] GameResult gameResult)
        {
            GameResult findResult = _context.GameResults.Where(x => x.Id == gameResult.Id).FirstOrDefault();
            if (findResult == null)
                return false;

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            findResult.Date = DateTime.Now;
            _context.SaveChanges();

            return true;
        }

        // Delete
        [HttpDelete("{id}")]
        public bool DeleteGameResult(int id)
        {
            GameResult findResult = _context.GameResults.Where(x => x.Id == id).FirstOrDefault();
            if (findResult == null)
                return false;

            _context.GameResults.Remove(findResult);
            _context.SaveChanges();

            return true;
        }
    }
}
