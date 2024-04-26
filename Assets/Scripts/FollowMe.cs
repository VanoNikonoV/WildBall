using UnityEngine;

public class FollowMe: MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + offset; 
    }
    
}
