using UnityEngine;

public class GanSetActive : MonoBehaviour
{
    [SerializeField] private GameObject gunCriator;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gunCriator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gunCriator.SetActive(false);
        }
    }
}
