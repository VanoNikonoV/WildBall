using UnityEngine;

public class EnablingGameObject : MonoBehaviour
{
    [SerializeField, Header("Object")] private GameObject objectToBeIncluded;
    [Header("Sprite")]
    [SerializeField] private Sprite nextSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private bool isActive = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isActive) 
        { 
            objectToBeIncluded.SetActive(true);

            spriteRenderer.sprite = nextSprite;

            audioSource.Play();

            isActive = false;
        }
    }
}
