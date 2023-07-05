using System.Collections.Generic;

namespace AI.GOAP
{
    public interface IFactState : IEnumerable<KeyValuePair<string, bool>>
    {
        bool GetFact(string id);
        
        bool TryGetFact(string id, out bool value);

        bool ContainsFact(string id);
    }
    
    public static class FactExtensions
    {
        public static bool EqualsTo(this IFactState target, IFactState other)
        {
            foreach (var (id, value) in target)
            {
                if (!other.TryGetFact(id, out var otherValue))
                {
                    return false;
                }

                if (value != otherValue)
                {
                    return false;
                }
            }

            return true;
        }
        
        public static bool IsNeighbourTo(this IFactState target, IFactState other)
        {
            foreach (var (id, _) in target)
            {
                if (other.ContainsFact(id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}