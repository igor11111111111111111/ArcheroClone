using Zenject;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace ArcheroClone
{

    public class BattlefieldMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private Bullet _bulletPrefab;
        [SerializeField]
        private ParticleSystem _particlePrefab;
        [SerializeField]
        private PlayerController _moveController;
        [SerializeField]
        private CoinsCounterUI _coinsCounterUI;
        [SerializeField]
        private Coin _coinPrefab;


        public override void InstallBindings()
        {
            MoveController();
            ParticlePool();
            BulletPool();
            CoinDropper();
        }

        private void CoinDropper()
        {
            var dropper = new CoinDropper(_coinPrefab, _coinsCounterUI);
            Container
                .Bind<CoinDropper>()
                .FromInstance(dropper)
                .AsSingle();
        }

        private void ParticlePool()
        {
            var particlePool = new ParticlePool(_particlePrefab, 10);
            Container
                .Bind<ParticlePool>()
                .FromInstance(particlePool)
                .AsSingle();
        }

        private void BulletPool()
        {
            var bulletPool = new BulletPool(_bulletPrefab, 10);
            Container
                .Bind<BulletPool>()
                .FromInstance(bulletPool)
                .AsSingle();
            Container.QueueForInject(bulletPool);
        }

        private void MoveController()
        {
            Container
                .Bind<IController>()
                .FromInstance(_moveController)
                .AsSingle();
        }
    }
}
