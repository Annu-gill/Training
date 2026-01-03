


using System.Collections;

namespace Day10_CodingPractice
{
    interface IDisposable
    {
        public void Dispose();
    }
    public class BigBoy : IDisposable
    {
        public BigBoy()
        {
            
        }
        public ArrayList Names {get; set;}
        public void Dispose()
        {
            // GC.Collect();
            Names= null;
        }

        ~BigBoy()
        {
            Names=null;
        }
    }
}

