using UnityEngine;

namespace ArcheroClone
{
    public class PlayerMonobehaviour : UnitMonobehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out UnitMonobehaviour unit))
            {
                if(unit.UnitData.IsAlive)
                    TakeDamage(unit.UnitData.CollisionDamage);
            }
        }
    }
}
