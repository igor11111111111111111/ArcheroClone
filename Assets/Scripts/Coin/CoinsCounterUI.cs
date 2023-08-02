using TMPro;
using UnityEngine;

namespace ArcheroClone
{
    public class CoinsCounterUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _tmp;

        public void Refresh(int count)
        {
            _tmp.text = "Coins: " + count;
        }
    }
}
