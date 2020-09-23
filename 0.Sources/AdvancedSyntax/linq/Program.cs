using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    public enum ClassType
    {
        Knight,
        Archer,
        Mage,
    }

    public class Player
    {
        public ClassType ClassType { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public List<int> Items { get; set; } = new List<int>();
    }

    class Program
    {
        static List<Player> _players = new List<Player>();

        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                ClassType type = ClassType.Knight;
                switch (rand.Next(0, 3))
                {
                    case 0:
                        type = ClassType.Knight;
                        break;
                    case 1:
                        type = ClassType.Archer;
                        break;
                    case 2:
                        type = ClassType.Mage;
                        break;
                }

                Player player = new Player()
                {
                    ClassType = type,
                    Level = rand.Next(1, 11),
                    Hp = rand.Next(100, 1000),
                    Attack = rand.Next(5, 50)
                };

                for (int j = 0; j < 5; j++)
                    player.Items.Add(rand.Next(1, 101));

                _players.Add(player);


            }

            // Q) 레벨이 50 이상인 Knight만 선택해서 레벨 오름차순으로 정렬

            // Without LINQ
            List<Player> players = GetHightLevelKnight();
            foreach (Player p in players)
            {
                Console.WriteLine($"{p.Level} {p.Hp}");
            }

            Console.WriteLine("---------------------------------");

            // WITH LINQ
            var selected = from p in _players
                          where p.ClassType == ClassType.Knight && p.Level >= 50
                          orderby p.Level ascending
                          select p;

            foreach (Player p in selected)
            {
                Console.WriteLine($"{p.Level} {p.Hp}");
            }

            // 중첩 from
            // 아이템 id가 30 이하인 아이템 목록을 추출
            var playerItems = from p in _players
                              from i in p.Items
                              where i < 30
                              select new { p, i };

            var li = playerItems.ToList();

            // Grouping
            var playerByLevel = from p in _players
                                group p by p.Level into g
                                orderby g.Key
                                select new { g.Key, Players = g };

            // Join (inner) or Outer Join
            List<int> levels = new List<int>() { 1, 5, 10 };

            var joinPlayer = from p in _players
                             join l in levels
                             on p.Level equals 10
                             select p;

            // LINQ 표준 연산자
            {
                var players2 = from p in _players
                              where p.ClassType == ClassType.Knight && p.Level >= 5
                              orderby p.Level ascending
                              select p;

                var players3 =_players
                    .Where(p => p.ClassType == ClassType.Knight && p.Level >= 5)
                    .OrderBy(p => p.Level)
                    .Select(p => p);
            }
        }

        static public List<Player> GetHightLevelKnight()
        {
            List<Player> players = new List<Player>();

            foreach (Player player in _players)
            {
                if (player.ClassType != ClassType.Knight)
                    continue;

                if (player.Level < 5)
                    continue;

                players.Add(player);
            }

            players.Sort((lhs, rhs) => { return lhs.Level - rhs.Level; });
            return players;
        }
    }
}
