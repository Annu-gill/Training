namespace Day06
{
    public class Visitor:INonVegEatter, IVegEatter
    {
        public void NonVegEatter()
        {
            Console.WriteLine("I eat non veg food.");
        }
        public void VegEatter()
        {
            Console.WriteLine("I eat veg food.");
        }
        string INonVegEatter.GetTaste()
        {
            return "Non veg taste is rank 2.";
        }

        string IVegEatter.GetTaste()
        {
            return "Veg taste is rank 1.";
        }
    }
    
}


