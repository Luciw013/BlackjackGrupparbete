using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BlackJackGrupp
{

    public class ToplistManager            //hanterar topplistan
    {
        private readonly string filePath = "Toplist.json";
        private List<Highscore> results = new List<Highscore>();

        public void Load()                  // läser in json-fil vid start av program
        {
            if (!File.Exists(filePath))
            {
                results = new List<Highscore>();
                Save();
                return;
            }

            try
            {
                string json = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    results = new List<Highscore>();
                }
                else
                {
                    results = JsonSerializer.Deserialize<List<Highscore>>(json)
                                ?? new List<Highscore>();
                }
            }
            catch (JsonException)
            {
                results = new List<Highscore>();
            }

            Save();
        }

        public void AddResult(string name, decimal balance, int rounds)     // Sparar + sorterar resultat
        {
            Highscore newResult = new Highscore
            {
                Name = name,
                FinalBalance = balance,
                RoundsPlayed = rounds
            };

            results.Add(newResult);
            results = results
                .OrderByDescending(r => r.FinalBalance)
                .Take(5)        //tar endast med de 5 hittills bästa resultaten
                .ToList();

            Save();
        }
        private void Save()             // Lagrar i json-fil
        {
           string json = JsonSerializer.Serialize(results, new JsonSerializerOptions
           { WriteIndented = true });
               
            File.WriteAllText(filePath, json);
        }
        public void DisplayToplist()        //metod för att visa topplista
        {
            Console.WriteLine("\n===== TOPPLISTA =====");

            if (results.Count == 0)
            {
                Console.WriteLine(" ");
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
