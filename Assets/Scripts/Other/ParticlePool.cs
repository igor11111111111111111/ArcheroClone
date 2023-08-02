using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ArcheroClone
{
    public class ParticlePool
    {
        private List<ParticleSystem> _particles;
        private ParticleSystem _prefab;

        public ParticlePool(ParticleSystem prefab, int size)
        {
            _prefab = prefab;
            _particles = new List<ParticleSystem>();
            for (int i = 0; i < size; i++)
            {
                Create();
            }
        }

        public void Play(Transform transform)
        {
            ParticleSystem particle = null;
            try
            {
                particle = _particles
                .Where(b => b != null && b.gameObject.activeInHierarchy == false)
                .First();
                if (particle == null)
                    particle = Create();
                LiveCycle(particle, transform);
            }
            catch (System.Exception)
            {

            }
        }

        private async void LiveCycle(ParticleSystem particle, Transform transform)
        {
            particle.transform.position = transform.position;
            particle.gameObject.SetActive(true);
            particle.Play();
            await Task.Delay(1500);
            if(particle != null)
                particle.gameObject.SetActive(false);
        }

        private ParticleSystem Create()
        {
            var particle = Object.Instantiate(_prefab);
            particle.gameObject.SetActive(false);
            _particles.Add(particle);
            return particle;
        }
    }
}
