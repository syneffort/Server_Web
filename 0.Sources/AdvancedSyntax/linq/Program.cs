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
                    Level = rand.Next(100, 1000),
                    Attack = rand.Next(5, 50)
                };

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
        }

        static public List<Player> GetHightLevelKnight()
        {
            List<Player> players = new List<Player>();

            foreach (Player player in _players)
            {
                if (player.ClassType != ClassType.Knight)
                    continue;

                if (player.Level < 50)
                    continue;

                players.Add(player);
            }

            players.Sort((lhs, rhs) => { return lhs.Level - rhs.Level; });
            return players;
        }
    }
}
