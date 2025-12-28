namespace Day06
{
    interface IVegEatter
    {
        public void VegEatter();
        string GetTaste();
    }

    interface INonVegEatter
    {
        public void NonVegEatter();
        string GetTaste();
    }
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


