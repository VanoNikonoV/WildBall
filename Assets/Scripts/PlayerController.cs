using System;
using UnityEngine;

namespace WildBall.Controller
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour, IControllable
    {
        [SerializeField, Range(0, 20), Tooltip("�������� �������� ������")]
        private float speed = 2.0f;
        [SerializeField, Range(50, 300)]
        private float jumpPower = 1.0f;
        

        public static event Action OnDeathPlayer;


        private Rigidbody playerRigidbody;
        private bool isGrounded; //��������� �������� � ������

        void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.maxAngularVelocity = 10f;
        }

        public void Move(Vector3 direction)
        {
            playerRigidbody.AddTorque(direction * speed, ForceMode.Force);
        }

        public void Jump()
        {
            if (isGrounded)
            {
                isGrounded = false;
                playerRigidbody.AddForce(Vector3.up * jumpPower);
            }
        }


        /// <summary>
        /// ����������� ������ 
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            isGrounded = true;
        }

        /// <summary>
        /// ������ ������ ��������� ��� ������������ � ������� � ����� DeathTrigger
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("DeathTrigger"))
            {
                OnDeathPlayer?.Invoke();

                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                
                playerRigidbody.freezeRotation = true; //��� �� ��� �� �������� ����� ������������ � ��������

            }
        }

#if UNITY_EDITOR
        [ContextMenu("ResetValues")]
        public void ResetValues() { speed = 2.0f; }
#endif
    }
}
