namespace ConsoleApp2
{
    public class Basket : ThingsList
    {
        // CountableThings[] store;
        internal Basket(CountableThings[] store) //:base(store)
        
        {
          //  this.store = store;
        }
        internal override int Count(CountableThings[] store, byte position, int amount)
       {
            amount = (amount > store[position].amount) ? store[position].amount : amount;
            return amount;
            
       }

    }
}


