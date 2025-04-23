using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Блюда
{
    internal class Dish
    {
        public string dishName { get; set; }
        public int dishPrice { get; set; }

        public Dish(string dishName, int dishPrice)
        {
            this.dishName = dishName;
            this.dishPrice = dishPrice;
        }

        public string PrintDish()
        {
            return $"Блюдо: {dishName}, Цена: {dishPrice}";
        }
    }

    internal class Program
    {
        static Dish[] SortDishes(Dish[] dishes, int start, int end)
        {
            if (start >= end)
            {
                return dishes;
            }

            int left = start;
            int right = end;
            int center = dishes[(left + right) / 2].dishPrice;

            while (left <= right)
            {
                while (dishes[left].dishPrice < center)
                {
                    left += 1;
                }
                while (dishes[right].dishPrice > center)
                {
                    right -= 1;
                }
                if (left <= right)
                {
                    (dishes[left], dishes[right]) = (dishes[right], dishes[left]);
                    left += 1;
                    right -= 1;
                }
            }
            SortDishes(dishes, start, right);
            SortDishes(dishes, left, end);

            return dishes;
        }

        static void Main(string[] args)
        {
            Dish borsch = new Dish("Борщ", 35);
            Dish cutlet = new Dish("Котлета", 40);
            Dish kasha = new Dish("Каша", 20);
            Dish tea = new Dish("Чай", 3);

            Dish[] dishes = { borsch, cutlet, kasha, tea };

            int start = 0;
            int end = dishes.Length - 1;

            Dish[] sortedDishes = SortDishes(dishes, start, end);
            foreach (Dish dish in sortedDishes)
            {
                Console.WriteLine(dish.PrintDish());
            }
        }
    }
}
