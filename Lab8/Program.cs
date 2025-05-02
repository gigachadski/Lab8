using System;
using System.Collections.Generic;


namespace Lab8
{
    /// <summary>
    /// Абстрактний базовий клас для фізичної особи.
    /// </summary>
    public abstract class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                int age = DateTime.Today.Year - value.Year;
                if (value > DateTime.Today || age < 16 || age > 50)
                    throw new ArgumentOutOfRangeException(nameof(DateOfBirth), "Вік гравця має бути в межах 16–50 років.");
                _dateOfBirth = value;
            }
        }
    }

    /// <summary>
    /// Представляє гравця.
    /// </summary>
    public class Player : Person
    {
        public string Status { get; set; } = "Активний";
        public string HealthStatus { get; set; } = "Здоровий";

        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Salary), "Зарплатня не може бути від'ємною.");
                _salary = value;
            }
        }

        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Статус не може бути порожнім.");
            Status = newStatus;
        }

        public void UpdateHealth(string newHealthStatus)
        {
            if (string.IsNullOrWhiteSpace(newHealthStatus))
                throw new ArgumentException("Статус здоров’я не може бути порожнім.");
            HealthStatus = newHealthStatus;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Status})";
        }
    }
    /// <summary>
    /// Представляє футбольну гру між двома командами.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Назва домашньої команди.
        /// </summary>
        public string HomeTeamName { get; set; }

        /// <summary>
        /// Назва команди-суперника.
        /// </summary>
        public string AwayTeamName { get; set; }

        /// <summary>
        /// Список гравців домашньої команди.
        /// </summary>
        public List<Player> HomeTeamPlayers { get; } = new();

        /// <summary>
        /// Список гравців команди-суперника.
        /// </summary>
        public List<Player> AwayTeamPlayers { get; } = new();

        /// <summary>
        /// Дата та час проведення гри.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Місце проведення гри.
        /// </summary>
        public string StadiumName { get; set; }

        /// <summary>
        /// Кількість глядачів, присутніх на грі.
        /// </summary>
        public int Attendees { get; set; }

        /// <summary>
        /// Результат гри (наприклад, 2:1 або "ще не проведено").
        /// </summary>
        public string Result { get; private set; } = "Ще не проведено";

        /// <summary>
        /// Встановлює результат гри.
        /// </summary>
        /// <param name="result">Результат у вигляді "2:1"</param>
        public void SetResult(string result)
        {
            if (string.IsNullOrWhiteSpace(result))
                throw new ArgumentException("Результат не може бути порожнім.");
            Result = result;
        }
        public void AddPlayerToHomeTeam(Player player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (!HomeTeamPlayers.Contains(player))
                HomeTeamPlayers.Add(player);
        }

        public void AddPlayerToAwayTeam(Player player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (!AwayTeamPlayers.Contains(player))
                AwayTeamPlayers.Add(player);
        }

        public void RemovePlayerFromHomeTeam(Player player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            HomeTeamPlayers.Remove(player);
        }

        public void RemovePlayerFromAwayTeam(Player player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            AwayTeamPlayers.Remove(player);
        }

        /// <summary>
        /// Повертає коротку інформацію про гру.
        /// </summary>
        public override string ToString()
        {
            return $"{Date:dd.MM.yyyy} - {HomeTeamName} vs {AwayTeamName} at {StadiumName} | Результат: {Result}";
        }
    }
    /// <summary>
    /// Представляє футбольний стадіон.
    /// </summary>
    public class Stadium
    {
        /// <summary>
        /// Назва стадіону.
        /// </summary>
        public string Name { get; set; }

        private int _capacity;

        /// <summary>
        /// Кількість місць на стадіоні.
        /// </summary>
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Capacity), "Кількість місць не може бути від'ємною.");
                _capacity = value;
            }
        }

        private decimal _seatPrice;

        /// <summary>
        /// Ціна за одне місце на стадіоні.
        /// </summary>
        public decimal SeatPrice
        {
            get => _seatPrice;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(SeatPrice), "Ціна за місце не може бути від'ємною.");
                _seatPrice = value;
            }
        }

        /// <summary>
        /// Повертає коротку інформацію про стадіон.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} — {Capacity} місць, ціна: {SeatPrice:C}";
        }
    }
    /// <summary>
    /// Представляє футбольну команду.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Назва команди.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список гравців команди.
        /// </summary>
        public List<Player> Players { get; } = new();

        /// <summary>
        /// Додає нового гравця до команди.
        /// </summary>
        /// <param name="player">Гравець для додавання.</param>
        public void AddPlayer(Player player)
        {
            if (player == null) return;
            Players.Add(player);
        }

        /// <summary>
        /// Видаляє гравця з команди.
        /// </summary>
        /// <param name="player">Гравець для видалення.</param>
        public void RemovePlayer(Player player)
        {
            if (player == null) return;
            Players.Remove(player);
        }

        /// <summary>
        /// Повертає коротку інформацію про команду.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} ({Players.Count} гравців)";
        }
    }
 
/// <summary>
/// Менеджер для управління гравцями.
/// </summary>
public class PlayerManager
    {
        private readonly List<Player> _players = new();

        /// <summary>
        /// Додає нового гравця.
        /// </summary>
        public void Add(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (_players.Any(p => p.FirstName == player.FirstName && p.LastName == player.LastName))
                throw new InvalidOperationException("Гравець з таким ім’ям вже існує.");

            _players.Add(player);
        }

        /// <summary>
        /// Видаляє гравця.
        /// </summary>
        public void Remove(Player player)
        {
            if (player != null)
                _players.Remove(player);
        }

        /// <summary>
        /// Повертає список усіх гравців.
        /// </summary>
        public List<Player> GetAll()
        {
            return new List<Player>(_players);
        }
        /// <summary> 
        /// Знаходить гравців за ім’ям.
        /// </summary>
        public List<Player> FindByFirstName(string firstName)
        {
            return _players.Where(p => p.FirstName == firstName).ToList();
        }

        /// <summary>
        /// Знаходить гравців за прізвищем.
        /// </summary>
        public List<Player> FindByLastName(string lastName)
        {
            return _players.Where(p => p.LastName == lastName).ToList();
        }
    }
    /// <summary>
    /// Менеджер для управління командами.
    /// </summary>
    public class TeamManager
    {
        private readonly List<Team> _teams = new();

        /// <summary>
        /// Додає команду.
        /// </summary>
        public void Add(Team team)
        {
            if (team == null)
                throw new ArgumentNullException(nameof(team));

            if (_teams.Any(t => t.Name == team.Name))
                throw new InvalidOperationException("Команда з такою назвою вже існує.");

            _teams.Add(team);
        }

        /// <summary>
        /// Видаляє команду.
        /// </summary>
        public void Remove(Team team)
        {
            if (team != null)
                _teams.Remove(team);
        }

        /// <summary>
        /// Повертає всі команди.
        /// </summary>
        public List<Team> GetAll()
        {
            return new List<Team>(_teams);
        }

        /// <summary>
        /// Знаходить команду за назвою.
        /// </summary>
        public Team? FindByName(string name)
        {
            return _teams.FirstOrDefault(t => t.Name == name);
        }
    }
    /// <summary>
    /// Менеджер для управління іграми.
    /// </summary>
    public class GameManager
    {
        private readonly List<Game> _games = new();

        /// <summary>
        /// Додає гру.
        /// </summary>
        public void Add(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game));

            _games.Add(game);
        }

        /// <summary>
        /// Видаляє гру.
        /// </summary>
        public void Remove(Game game)
        {
            if (game != null)
                _games.Remove(game);
        }

        /// <summary>
        /// Повертає всі ігри.
        /// </summary>
        public List<Game> GetAll()
        {
            return new List<Game>(_games);
        }

        /// <summary>
        /// Знаходить ігри за датою.
        /// </summary>
        public List<Game> FindByDate(DateTime date)
        {
            return _games.Where(g => g.Date.Date == date.Date).ToList();
        }

        /// <summary>
        /// Сортує ігри за датою.
        /// </summary>
        public List<Game> GetSortedByDate()
        {
            return _games.OrderBy(g => g.Date).ToList();
        }
        public List<Game> GetByResultCategory(string category)
        {
            return category switch
            {
                "Виграні" => _games.Where(g => IsWin(g.Result)).ToList(),
                "Програні" => _games.Where(g => IsLoss(g.Result)).ToList(),
                "Нічиї" => _games.Where(g => IsDraw(g.Result)).ToList(),
                "Ще не проведені" => _games.Where(g => g.Result == "Ще не проведено").ToList(),
                _ => new List<Game>()
            };
        }

        private bool IsWin(string result) => TryParseResult(result, out var home, out var away) && home > away;
        private bool IsLoss(string result) => TryParseResult(result, out var home, out var away) && home < away;
        private bool IsDraw(string result) => TryParseResult(result, out var home, out var away) && home == away;

        private bool TryParseResult(string result, out int home, out int away)
        {
            home = away = 0;
            var parts = result.Split(':');
            return parts.Length == 2 && int.TryParse(parts[0], out home) && int.TryParse(parts[1], out away);
        }
        public List<Game> FindByOpponent(string opponentName)
        {
            return _games.Where(g => g.HomeTeamName == opponentName || g.AwayTeamName == opponentName).ToList();
        }
        public Game? FindByDateAndOpponent(DateTime date, string opponentName)
        {
            return _games.FirstOrDefault(game =>
                game.Date.Date == date.Date &&
                (game.HomeTeamName.Equals(opponentName, StringComparison.OrdinalIgnoreCase) ||
                 game.AwayTeamName.Equals(opponentName, StringComparison.OrdinalIgnoreCase)));
        }


    }
    /// <summary>
    /// Менеджер для управління стадіонами.
    /// </summary>
    public class StadiumManager
    {
        private readonly List<Stadium> _stadiums = new();

        /// <summary>
        /// Додає стадіон.
        /// </summary>
        public void Add(Stadium stadium)
        {
            if (stadium == null)
                throw new ArgumentNullException(nameof(stadium));

            if (_stadiums.Any(s => s.Name == stadium.Name))
                throw new InvalidOperationException("Стадіон з такою назвою вже існує.");

            _stadiums.Add(stadium);
        }

        /// <summary>
        /// Видаляє стадіон.
        /// </summary>
        public void Remove(Stadium stadium)
        {
            if (stadium != null)
                _stadiums.Remove(stadium);
        }

        /// <summary>
        /// Повертає всі стадіони.
        /// </summary>
        public List<Stadium> GetAll()
        {
            return new List<Stadium>(_stadiums);
        }

        /// <summary>
        /// Знаходить стадіон за назвою.
        /// </summary>
        public Stadium? FindByName(string name)
        {
            return _stadiums.FirstOrDefault(s => s.Name == name);
        }
    }

}