using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isActive = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive) return;

        isActive = false;

        GetComponent<Rigidbody>().useGravity = true;
    }
}
