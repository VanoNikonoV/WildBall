using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
