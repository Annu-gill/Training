

namespace Day9_LearningCSharp
{
    public static class GeneralUses
    {
        // static contructor will work with static variables only.
        public static int ROllNo;
        static GeneralUses()
        {
            ROllNo=1;
        }
        public static int GetRollNo()
        {
            return ROllNo;
        }
    }
}




