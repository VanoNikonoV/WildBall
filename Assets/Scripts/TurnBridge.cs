using UnityEngine;

public class TurnBridge : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private AudioSource audioSource;

    private bool isActive = true;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            animator.SetTrigger("Turn");

            audioSource.Play();

            isActive = false;
        }
    }
}
