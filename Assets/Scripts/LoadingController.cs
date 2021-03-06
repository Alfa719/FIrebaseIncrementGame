using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Button _localButton, _cloudButton;
    private void Start()
    {
        _localButton.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            UserDataManager.LoadFromLocal();
            SceneManager.LoadScene(1);
        });

        _cloudButton.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            StartCoroutine(UserDataManager.LoadFromCloud(() => SceneManager.LoadScene(1)));
        });
    }

    // Mendisable button agar tidak bisa ditekan
    private void SetButtonInteractable(bool interactable)
    {
        _localButton.interactable = interactable;
        _cloudButton.interactable = interactable;
    }
}