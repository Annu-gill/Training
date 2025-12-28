namespace Day07
{
    /// <summary>
    /// Multiple Inheritance for flybird and swimbirds.
    /// </summary>
    public class Birds:ISwimBirds, IFlyBirds
    {
        public void SwimBird()
        {
            Console.WriteLine("I am a swim bird.");
        }
        public void FlyBird()
        {
            Console.WriteLine("I am a fly bird.");
        }
        /// <summary>
        /// get rank for the swimbirds.
        /// </summary>
        /// <returns></returns>
        string ISwimBirds.GetRank()
        {
            return "Swimbird ranks 2.";
        }

        /// <summary>
        /// get rank for the flybirds.
        /// </summary>
        /// <returns></returns>
        string IFlyBirds.GetRank()
        {
            return "Flybird ranks 1.";
        }
    }
    
}


