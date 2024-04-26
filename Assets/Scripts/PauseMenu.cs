using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame;

    [SerializeField] public GameObject buttonPuase;
    [SerializeField] public GameObject buttonPuaseCenter;
    [SerializeField] public GameObject buttonSetting;
    [SerializeField] public GameObject canvasSetting;

    private PlayerInput actions;

    private void Awake()
    {
        actions = new PlayerInput();

        actions.UI.Pause.performed += PauseResume;
    }

    void PauseResume(InputAction.CallbackContext context)
    {
        if (PauseGame)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        buttonPuase.SetActive(true);
        buttonPuaseCenter.SetActive(false);
        buttonSetting.SetActive(false);
        canvasSetting.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        buttonPuase.SetActive(false);
        buttonPuaseCenter.SetActive(true);
        buttonSetting.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    private void OnEnable() { actions.UI.Enable(); }
    private void OnDisable() { actions.UI.Disable(); }
}
