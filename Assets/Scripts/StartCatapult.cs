using UnityEngine;

public class StartCatapult : MonoBehaviour
{
    [SerializeField] private HingeJoint hinge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hinge.useSpring = true;
        }
    }
}
