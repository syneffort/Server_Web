using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RankingApp.Data.Services
{
    // [C <-> S] <-> [S(Api) <-> DB]
    public class RankService
    {
        HttpClient _httpClient;

        public RankService(HttpClient client)
        {
            _httpClient = client;
        }

        // Create
        public async Task<GameResult> AddGameResult(GameResult gameResult)
        {
            string jsonStr = JsonConvert.SerializeObject(gameResult);
            StringContent convert = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await _httpClient.PostAsync("api/ranking", convert);

            if (result.IsSuccessStatusCode == false)
                throw new Exception("AddGameResult Failed");

            string resultContent = await result.Content.ReadAsStringAsync();
            GameResult resultGameResult = JsonConvert.DeserializeObject<GameResult>(resultContent);

            return resultGameResult;
        }

        // Read
        public async Task<List<GameResult>> GetGameResultsAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync("api/ranking");

            if (result.IsSuccessStatusCode == false)
                throw new Exception("GetGameReulst Failed");

            string resultContent = await result.Content.ReadAsStringAsync();
            List<GameResult> resultGameResults = JsonConvert.DeserializeObject<List<GameResult>>(resultContent);

            return resultGameResults;
        }

        // Update
        public async Task<bool> UpdateGameResult(GameResult gameResult)
        {
            string jsonStr = JsonConvert.SerializeObject(gameResult);
            StringContent convert = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await _httpClient.PutAsync("api/ranking", convert);

            if (result.IsSuccessStatusCode == false)
                throw new Exception("UpdateGameResult Failed");

            return true;
        }

        // Delete
        public async Task<bool> DeleteGameResult(GameResult gameResult)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync($"api/ranking/{gameResult.Id}");

            if (result.IsSuccessStatusCode == false)
                throw new Exception("DeleteGameResult Failed");

            return true;
        }
    }
}
