using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button showBtn;
    [SerializeField] private KeyCode hideKey = KeyCode.Escape;

    private void Awake()
    {
        showBtn.onClick.AddListener(Show);
        Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(hideKey))
        {
            Hide();
        }
    }

    private void Show()
    {
        panel.SetActive(true);
    }

    private void Hide()
    {
        panel.SetActive(false);
    }
}
