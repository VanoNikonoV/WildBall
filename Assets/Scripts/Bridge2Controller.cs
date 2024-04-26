using UnityEngine;

public class Bridge2Controller : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            _animator.SetTrigger("OnTriggerBridge");
    }
}
