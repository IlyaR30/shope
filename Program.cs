// See https://aka.ms/new-console-template for more information
using ConsoleApp2;


CountableThings snikers = new("snikers", 10, 100);
CountableThings mars = new("mars", 10, 50);
CountableThings nuts = new("bull nuts(бычьи яица)", 100, 500);

CountableThings [] goods = { snikers, mars, nuts };//

CountableThings rub50 = new("полтиник", 10, 50);
CountableThings rub100 = new("сотка", 10, 100);
CountableThings rub500 = new("пятихатка", 10, 500);
CountableThings rub1000 = new("косарь", 1, 1000);

CountableThings[] cash = { rub50, rub100, rub500, rub1000 };
ThingsList CashState = new (cash); 
ThingsList GoodState = new(goods);
CashState.Print();
GoodState.Print();
//CashState.MakeList (CashState).Print();
ThingsList choseengoods = clist(GoodState);
Console.WriteLine($"Внесите купюры на сумму не меньше: {choseengoods.total} руб");
ThingsList choseenCash=clist(CashState, false);// false если что-то вносят 
if (choseenCash.total<choseengoods.total)
{ Console.WriteLine("не достаточно средств"); }
else
{
    choseengoods.Print();
    choseenCash.Print();
    int change = (choseenCash.total > choseengoods.total) ? (choseenCash.total - choseengoods.total) : 0;
  //  Console.WriteLine($"Ваша сдача {change}");
    
    ThingsList chs=MakeChangeList(change);
    Console.WriteLine("ваша сдача");
    chs.Print();
    Remove(chs, CashState);
    Remove(choseengoods, GoodState);
    Add(choseenCash, CashState);
}
CashState.Print();
GoodState.Print();

ThingsList clist(ThingsList store, bool a=true)
{
        ThingsList c = new ThingsList();
        bool answer = true;
        byte position = 0;
        int amount;
        int total = 0;
        Dictionary<int, CountableThings> listof = new();      
        while (answer)
        {
            string m = a ? "товар" : "купюры";
            Console.WriteLine($"добавить позицию {m} -введите \"y\"");
            string? str = Console.ReadLine();
            if (str == "y")
            {
                answer = true;
                Ask(out position, out amount);
                int id = position;
                string name = store.list[position].Name;
                int price = store.list[position].Price;

                amount = (a && (amount > store.list[position].amount)) ? store.list[position].amount : amount;

                CountableThings value = new(name, amount, price);
                listof.Add(id, value);
                total += (price * amount);

            }
            else
            {
                answer = false;
            }

        }


        c.total = total;
        c.list = listof;

        return c;

    }

void Ask(out byte position, out int amount)
    {
        position = 0;
        amount = 0;
        Console.Write("Введите номер позиции:");
        position = Convert.ToByte(Console.ReadLine());
        Console.Write("Введите количество:");
        amount = Convert.ToInt32(Console.ReadLine());
    }

ThingsList MakeChangeList(int change)
{
     ThingsList changeList = new();    
    int lenght = CashState.list.Count;
        int total = 0;
    if (change > 0)
    { for (int i = lenght-1; i > 0; i--)
        {
            int rest=change/CashState.list[i].Price;
            int amount=(rest<CashState.list[i].amount)?rest:CashState.list[i].amount;
            if (amount > 0) 
            {
                total += (CashState.list[i].Price) * amount;
                string name = CashState.list[i].Name;
                int price = CashState.list[i].Price;
                change = change - price * amount;
                CountableThings things = new(name, amount, price);
                changeList.list.Add(i, things);
            }
            
        }
              changeList.total = total;
    }
    return changeList;

}


void Remove(ThingsList a, ThingsList b)
{ 
    b.total -= a.total;
    foreach (var i in a.list)
    {
        int key = i.Key;
        b.list[key].amount -= i.Value.amount;

    }
}
void Add(ThingsList a, ThingsList b)
{
    b.total += a.total;
    foreach (var i in a.list)
    {
        int key = i.Key;
        if (b.list.ContainsKey(key))
        {
            b.list[key].amount += i.Value.amount;
        }
       

    }
}