using Lab8;
using System;

namespace FootballApp
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Створення менеджерів
            var playerManager = new PlayerManager();
            var teamManager = new TeamManager();
            var gameManager = new GameManager();
            var stadiumManager = new StadiumManager();

            // Додати гравців
            var messi = new Player { FirstName = "Lionel", LastName = "Messi", DateOfBirth = new DateTime(1987, 6, 24), Salary = 500000m };
            var ronaldo = new Player { FirstName = "Cristiano", LastName = "Ronaldo", DateOfBirth = new DateTime(1985, 2, 5), Salary = 480000m };

            playerManager.Add(messi);
            playerManager.Add(ronaldo);

            // Змінити статус і здоров’я
            messi.UpdateStatus("Активний");
            messi.UpdateHealth("Здоровий");

            // Створити команди
            var teamPSG = new Team { Name = "PSG" };
            var teamAlNassr = new Team { Name = "Al Nassr" };

            teamPSG.AddPlayer(messi);
            teamAlNassr.AddPlayer(ronaldo);

            teamManager.Add(teamPSG);
            teamManager.Add(teamAlNassr);

            // Додати стадіон
            var stadium = new Stadium { Name = "Lusail Stadium", Capacity = 88000, SeatPrice = 150.00m };
            stadiumManager.Add(stadium);

            // Створити гру
            var game = new Game
            {
                HomeTeamName = "PSG",
                AwayTeamName = "Al Nassr",
                Date = new DateTime(2025, 6, 1),
                StadiumName = "Lusail Stadium"
            };

            game.AddPlayerToHomeTeam(messi);
            game.AddPlayerToAwayTeam(ronaldo);
            game.Attendees = 70000;
            game.SetResult("2:2");

            gameManager.Add(game);

            // Вивід інформації
            Console.WriteLine(" Список гравців:");
            foreach (var p in playerManager.GetAll())
                Console.WriteLine($"- {p.FirstName} {p.LastName}, зарплатня: {p.Salary}");

            Console.WriteLine("\nСписок команд:");
            foreach (var t in teamManager.GetAll())
                Console.WriteLine($"- {t}");

            Console.WriteLine("\nІнформація про стадіон:");
            foreach (var s in stadiumManager.GetAll())
                Console.WriteLine($"- {s}");

            Console.WriteLine("\nСписок ігор:");
            foreach (var g in gameManager.GetAll())
                Console.WriteLine($"- {g}");

            Console.WriteLine("\n Сортування ігор за датою:");
            foreach (var g in gameManager.GetSortedByDate())
                Console.WriteLine($"- {g}");

            Console.WriteLine("\n Ігри з результатом «Нічиї»:");
            foreach (var g in gameManager.GetByResultCategory("Нічиї"))
                Console.WriteLine($"- {g}");

            Console.WriteLine("\n Пошук гравця за ім’ям Lionel:");
            foreach (var p in playerManager.FindByFirstName("Lionel"))
                Console.WriteLine($"- {p}");

            var foundGame = gameManager.FindByDateAndOpponent(new DateTime(2025, 6, 1), "Al Nassr");
            if (foundGame != null)
                Console.WriteLine($"- {foundGame}");


            Console.WriteLine("\n Пошук стадіону за назвою 'Lusail Stadium':");
            var foundStadium = stadiumManager.FindByName("Lusail Stadium");
            if (foundStadium != null)
                Console.WriteLine($"- {foundStadium}");
        }
    }
}
