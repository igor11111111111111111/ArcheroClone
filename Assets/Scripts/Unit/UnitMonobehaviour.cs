using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ArcheroClone
{
    public class UnitMonobehaviour : MonoBehaviour, IUnit
    {
        public UnitData UnitData => _unitData;
        private UnitData _unitData;

        [Inject]
        public void Init(UnitData unitData, CoinDropper coinDropper, AllUnitsInfo allUnitsInfo)
        {
            _unitData = unitData;
            if (this as PlayerMonobehaviour == true)
                return;

            _unitData.OnDeath += () =>
            {
                allUnitsInfo.Remove(this);
                coinDropper.Drop(transform);
            };
        }

        public async void TakeDamage(int damage)
        {
            if (_unitData.UnderImmune)
                return;
            _unitData.HealthData.Current -= damage;

            _unitData.UnderImmune = true;
            await Task.Delay((int)(_unitData.ImmuneTime * 1000));
            _unitData.UnderImmune = false;
        }
    }
}
