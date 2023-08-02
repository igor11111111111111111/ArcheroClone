using System.Threading.Tasks;
using UnityEngine;

namespace ArcheroClone
{
    public class TurrelShootSystem : ShootSystem
    {
        protected override async Task Update()
        {
            if (_moveDirection != Vector3.zero)
                return;
            _data.Target = _allUnits.GetNearEnemy(_unit);
            if (_transform == null ||
                _data.Target == null ||
                _data.Target.UnitData.IsAlive == false ||
                _data.IsAlive == false)
                return;

            _transform.LookAt(_data.Target.transform.position);

            SpawnBullet(Vector3.zero);
            SpawnBullet(Vector3.left);
            SpawnBullet(Vector3.right);

            if (_data.IsAlive == false)
                return;
            OnShoot?.Invoke();

            await Task.Delay((int)(_data.ShootCD * 1000));
        }

        private void SpawnBullet(Vector3 direction)
        {
            var bullet = _bulletPool.Get();
            bullet.ShootInit(_transform, _data.Target.transform.position + direction, _particlePool, _unit);
        }
    }
}