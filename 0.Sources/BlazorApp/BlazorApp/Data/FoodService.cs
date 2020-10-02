using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public interface IFoodService
    {
        public IEnumerable<Food> GetFoods();
    }

    public class KoreanFoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food() { Name = "Kimbab", Price = 2 },
                new Food() { Name = "Bibimbab", Price = 7 },
                new Food() { Name = "Bossam", Price = 25 }
            };

            return foods;
        }
    }

    public class FastFoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food() { Name = "Hamburger", Price = 3 },
                new Food() { Name = "Fries", Price = 1 },
            };

            return foods;
        }
    }

    public class PaymentService
    {
        IFoodService _service;

        public PaymentService(IFoodService service)
        {
            _service = service;
        }

        // TODO
    }

    public class SingletonServie : IDisposable
    {
        public Guid ID { get; set; }

        public SingletonServie()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("SingletonService Disposed");
        }
    }

    public class TransientServie : IDisposable
    {
        public Guid ID { get; set; }

        public TransientServie()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("TransientServie Disposed");
        }
    }

    public class ScopedServie : IDisposable
    {
        public Guid ID { get; set; }

        public ScopedServie()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("ScopeServie Disposed");
        }
    }
}
