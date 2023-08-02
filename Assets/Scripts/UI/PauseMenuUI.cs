using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ArcheroClone
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _openClosebutton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _body;

        private void Awake()
        {
            Time.timeScale = 1;
            _body.SetActive(false);

            _openClosebutton.onClick.AddListener(Show);
            _restartButton.onClick.AddListener(Restart);
        }

        private void Show()
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0; 
            _body.SetActive(!_body.activeInHierarchy);
        }

        private void Restart()
        {
            SceneManager.LoadScene("Battlefield");
        }
    }
}
