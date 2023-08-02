using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ArcheroClone
{
    public class CoinDropper
    {
        private Coin _prefab;
        private CoinsCounterUI _ui;
        private int _count;

        public CoinDropper(Coin prefab, CoinsCounterUI ui)
        {
            _prefab = prefab;
            _ui = ui;
        }

        public async void Drop(Transform transform)
        {
            var pos = new Vector3(transform.position.x, 0.15f, transform.position.z);
            var coin = Object.Instantiate(_prefab, pos, Quaternion.identity);
            await Task.Delay(3000);

            if (coin == null)
                return;
            Object.Destroy(coin.gameObject);
            _count++;
            _ui.Refresh(_count);
        }
    }
}