using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Adapter

namespace Pp_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // продукт
            Product product = new Product();
            // фрукт
            Fruit fruit = new Fruit();
            // готовим блюдо
            product.Food(fruit);
            // появилась ягода
            Kryzhovnik kryzhovnik = new Kryzhovnik();
            // используем адаптер
            IFruit kryzhovnikFruit = new KryzhovnikToFruitAdapter(kryzhovnik);
            // продолжаем готовить с крыжовником
            product.Food(kryzhovnikFruit);

            Console.ReadLine();
        }
    }
    interface IFruit
    {
        void Gotovka();
    }
    // класс машины
    class Fruit : IFruit
    {
        public void Gotovka()
        {
            Console.WriteLine("Из фруктов получается варенье");
        }
    }
    class Product
    {
        public void Food(IFruit fruit)
        {
            fruit.Gotovka();
        }
    }
    // интерфейс ягоды
    interface IYagoda
    {
        void Varka();
    }
    // класс крыжовника
    class Kryzhovnik : IYagoda
    {
        public void Varka()
        {
            Console.WriteLine("Из крыжовника получается желе");
        }
    }
    // Адаптер от Kryzhovnik к IFruit
    class KryzhovnikToFruitAdapter : IFruit
    {
        Kryzhovnik kryzhovnik;
        public KryzhovnikToFruitAdapter(Kryzhovnik c)
        {
            kryzhovnik = c;
        }

        public void Gotovka()
        {
            kryzhovnik.Varka();
        }
    }

}
