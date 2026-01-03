

namespace Day10_CodingPractice
{
    public class GenericsCustomization
    {
        public GenericsCustomization()
        {
            
        }
        public void ExampleOfList()
        {
            List<string> names=[];
        }
    }
    
    public class MyCollection : IList
    {
        public void Add()
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(object? value)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        
        
    }

    public interface IList
    {
        void Add()
        {
            
        }
        void Clear()
        {
            
        }
        void Contains()
        {
            
        }
        void CopyTo()
        {
            
        }
    }
}