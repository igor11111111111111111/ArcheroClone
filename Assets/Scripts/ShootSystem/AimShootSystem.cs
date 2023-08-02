using System.Threading.Tasks;
using UnityEngine;

namespace ArcheroClone
{

    public class AimShootSystem : ShootSystem
    {
        protected override async Task Update()
        {
            if (_moveDirection != Vector3.zero)
                return;
            if (_data.Target == null || 
                _data.Target != null && _data.Target.UnitData.IsAlive == false)
                _data.Target = _allUnits.GetNearEnemy(_unit);

            if (_transform == null ||
                _data.Target == null ||
                _data.Target.UnitData.IsAlive == false ||
                _data.IsAlive == false)
                return;

            _transform.LookAt(_data.Target.transform.position);
            Bullet bullet = _bulletPool.Get();
            bullet.ShootInit(_transform, _data.Target.transform.position, _particlePool, _unit);
            if (_data.IsAlive == false)
                return;
            OnShoot?.Invoke();

            await Task.Delay((int)(_data.ShootCD * 1000));
        }
    }
}