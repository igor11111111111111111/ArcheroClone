using System;
using UnityEngine;

namespace ArcheroClone
{
    public class BulletTrigger : MonoBehaviour
    {
        public Action<IObstacle> OnFindObstacle;
        private UnitMonobehaviour _unit;

        public void Init(UnitMonobehaviour unit)
        {
            _unit = unit;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IObstacle obstacle) && 
                !obstacle.Equals(_unit))
            {
                if ((obstacle is IUnit) && 
                    (obstacle as IUnit).UnitData.IsAlive == true || 
                    (obstacle is IUnit == false))
                {
                    OnFindObstacle?.Invoke(obstacle);
                }
            }
        }
    }
}
