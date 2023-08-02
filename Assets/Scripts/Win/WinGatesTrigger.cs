using UnityEngine;

namespace ArcheroClone
{
    public class WinGatesTrigger : MonoBehaviour
    {
        private GameObject _panel;

        public void Init(GameObject panel)
        {
            _panel = panel;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerMonobehaviour player))
            {
                _panel.SetActive(true);
            }
        }
    }
}