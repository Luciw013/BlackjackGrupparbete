using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BlackJackGrupp
{

    public class ToplistManager            //hanterar Topplistan + json-filen
    {
        private readonly string filePath = "leaderboard.json";
        private List<PlayerResult> results = new List<PlayerResult>();

        public void Load()                  // läser in json-fil
        {
            if (!File.Exists(filePath))
            {
                results = new List<PlayerResult>();
                Save();
                return;
            }

            try
            {
                string json = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    results = new List<PlayerResult>();
                }
                else
                {
                    results = JsonSerializer.Deserialize<List<PlayerResult>>(json)
                                ?? new List<PlayerResult>();
                }
            }
            catch (JsonException)
            {
                results = new List<PlayerResult>();
            }

            Save();
        }

        public void AddResult(string name, decimal balance, int rounds)     // Sparar nytt resultat
        {
            PlayerResult newResult = new PlayerResult
            {
                Name = name,
                FinalBalance = balance,
                RoundsPlayed = rounds
            };

            results.Add(newResult);

            // Soreterar 
            results = results
                .OrderByDescending(r => r.FinalBalance)
                .Take(5)
                .ToList();

            Save();
        }

        // Spara topplistan till JSON
        private void Save()
        {
            string json = JsonSerializer.Serialize(
                results,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(filePath, json);
        }

        // Visa topplistan
        public void ShowLeaderboard()
        {
            Console.WriteLine("\n===== TOPPLISTAN =====");

            if (results.Count == 0)
            {
                Console.WriteLine("Det finns inga resultat ännu.");
                return;
            }

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. {results[i].Name} - " +
                    $"Saldo: {results[i].FinalBalance} kr - " +
                    $"Rundor: {results[i].RoundsPlayed}"
                );
            }

            Console.WriteLine("======================\n");
        }
    }
}
