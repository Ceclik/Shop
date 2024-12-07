using System.Collections.Generic;

namespace Interfaces
{
    public interface IOrderCreator
    {
        public Dictionary<string, int> CreateOrder(int orderSize, int maxFoodAmount, List<int> usedNumbers);
    }
}