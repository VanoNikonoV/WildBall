using UnityEngine;
using UnityEngine.SceneManagement;


public class ActiveScene : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void SetScene()
    {
        Debug.Log($"Открыта сцена = " + sceneIndex.ToString());
        SceneManager.LoadScene(sceneIndex);
    }
}
