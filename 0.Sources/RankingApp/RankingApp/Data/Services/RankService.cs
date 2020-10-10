using RankingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingApp.Data.Services
{
    public class RankService
    {
        ApplicationDbContext _context;

        public RankService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create
        public Task<GameResult> AddGameResult(GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return Task.FromResult(gameResult);
        }

        // Read
        public Task<List<GameResult>> GetGameResultsAsync()
        {
            List<GameResult> results = _context.GameResults.OrderByDescending(x => x.Score).ToList();

            return Task.FromResult(results);
        }

        // Update
        public Task<bool> UpdateGameResult(GameResult gameResult)
        {
            GameResult findResult = _context.GameResults.Where(x => x.Id == gameResult.Id).FirstOrDefault();
            if (findResult == null)
                return Task.FromResult(false);

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            findResult.Date = DateTime.Now;

            _context.SaveChanges();

            return Task.FromResult(true);
        }

        // Delete
        public Task<bool> DeleteGameResult(GameResult gameResult)
        {
            GameResult findResult = _context.GameResults.Where(x => x.Id == gameResult.Id).FirstOrDefault();
            if (findResult == null)
                return Task.FromResult(false);

            _context.GameResults.Remove(gameResult);

            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
