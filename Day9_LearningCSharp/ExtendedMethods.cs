namespace Day9_LearningCSharp
{
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Count(c => c.Equals(' '))+1;
        }
    }
}