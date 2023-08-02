using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace ArcheroClone
{
    public class BulletPool
    {
        private List<Bullet> _bullets;
        private Bullet _prefab;
        private ParticlePool _particlePool;

        public BulletPool(Bullet prefab, int size)
        {
            _bullets = new List<Bullet>();
            _prefab = prefab;
            for (int i = 0; i < size; i++)
            {
                Create();
            }
        }

        public Bullet Get()
        {
            Bullet bullet = null;
            try
            {
                bullet = _bullets
                .Where(b => b != null && b.gameObject.activeInHierarchy == false)
                .First();
                if (bullet == null)
                    bullet = Create();
                bullet.gameObject.SetActive(true);
            }
            catch (System.Exception)
            {

            }

            return bullet;
        }

        private Bullet Create()
        {
            var bullet = Object.Instantiate(_prefab);
            bullet.gameObject.SetActive(false);
            bullet.CreateInit(new BulletData(10, 5, 1));
            _bullets.Add(bullet);
            return bullet;
        }
    }
}
