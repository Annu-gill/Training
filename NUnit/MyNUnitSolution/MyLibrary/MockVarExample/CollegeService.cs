namespace MyNUnitSolution.MockVarExample
{
    public class CollegeService : ICollegeService
    {
        public string GetFarewellNote(string name)
        {
            return $"All the best, {name}!";
        }
        public string GetWelcomeNote(string name)
        {
            return $"Welcome, {name}!";
        }
    }

    public interface ICollegeService
    {
    }
}