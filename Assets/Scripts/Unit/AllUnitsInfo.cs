using System.Collections.Generic;
using System.Linq;

namespace ArcheroClone
{
    public class AllUnitsInfo
    {
        public List<UnitMonobehaviour> List;

        public AllUnitsInfo()
        {
            List = new List<UnitMonobehaviour>();
        }

        public void Add(UnitMonobehaviour unit)
        {
            List.Add(unit);
        }

        public void Remove(UnitMonobehaviour unit)
        {
            List.Remove(unit);
        }

        public UnitMonobehaviour GetPlayer()
        {
            try
            {
                return List
                    .Where(u => u != null && u is PlayerMonobehaviour)
                    .First();
            }
            catch (System.Exception)
            {
                return null;
            }

        }

        public UnitMonobehaviour GetNearEnemy(UnitMonobehaviour myUnit)
        {
            try
            {
                if(myUnit is PlayerMonobehaviour)
                {
                    return List
                        .Where(u => u != null && !u.Equals(myUnit) && u.UnitData.IsAlive)
                        .OrderBy(u => (myUnit.transform.position - u.transform.position).magnitude)
                        .First();
                }
                else
                {
                    return GetPlayer();
                }
            }
            catch (System.Exception)
            {
                return null;
            }

        }
    }
}
