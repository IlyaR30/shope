using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ThingsList // переименовать
    {
        //поля
        public int total;
        internal Dictionary<int, CountableThings> list;
        //internal CountableThings[] store;
        //конструктор
        internal ThingsList()
        {
            total = 0;
            list = new Dictionary<int,CountableThings>();
        }
        internal ThingsList(CountableThings thing)
        {
            total = 0;            
            list = new Dictionary<int, CountableThings>(){[0]=thing};
        }
        internal ThingsList(CountableThings[] store)
        {
            int id = 0;
            total = 0;
            list = new Dictionary<int, CountableThings>();
            foreach (var item in store)
            {
                total += item.Price* item.amount;
                list.Add(id, item);
                id++;
            }

}
public void Print()
        {
            Console.WriteLine($"Выбраны следующие позиции:"); //
            Console.WriteLine($"# id наименование количество цена стоимость:");
            byte counter = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"{counter}-{item.Key} - {item.Value.Name}-{ item.Value.amount} шт. * {item.Value.Price}" +
                    $" rub ={item.Value.Price * item.Value.amount} rub");
                counter++;
            }
            Console.WriteLine($"Итогоо: {total} rub");
         }

        
    }
}
