namespace ChatAPI.Services
{
    public class IdGenerator
    {
        private int lastUsedId;
        
        public IdGenerator(int initialId = 0)
        {
            lastUsedId = initialId;
        }
        
        public int GetNextId()
        { 
            lastUsedId++;
            return lastUsedId;
        }
    }
}