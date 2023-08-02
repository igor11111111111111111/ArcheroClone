using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ArcheroClone
{
    public abstract class ShootSystem : IShootSystem
    {
        public Action OnShoot { get; set; }

        protected BulletPool _bulletPool;
        protected ParticlePool _particlePool;
        protected UnitData _data;
        protected AllUnitsInfo _allUnits;
        protected Transform _transform;
        protected UnitMonobehaviour _unit;
        protected Vector3 _moveDirection;

        [Inject]
        private void Init(UnitData data, BulletPool bulletPool, AllUnitsInfo allUnits, Transform transform, ParticlePool particlePool, IController controller, UnitMonobehaviour unit)
        {
            _data = data;
            _bulletPool = bulletPool;
            _allUnits = allUnits;
            _transform = transform;
            _particlePool = particlePool;
            _unit = unit;

            controller.OnMove += (direction) => _moveDirection = direction;
            Loop();
        }

        protected async void Loop()
        {
            while (this != null && _data != null && _data.IsAlive)
            {
                await Update();
                await Task.Delay(100);
            }
        }

        protected virtual Task Update()
        {
            return null;
        }
    }
}