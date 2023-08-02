using TMPro;
using UnityEngine;

namespace ArcheroClone
{
    public class StartCountdownUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _tmp;

        public void Refresh(int value)
        {
            _tmp.text = value.ToString();
            if (value == 0)
                gameObject.SetActive(false);
        }
    }
}
