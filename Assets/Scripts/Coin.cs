using UnityEngine;
using UnityEngine.VFX;


    public class Coin : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private VisualEffect effect;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        /// <summary>
        /// Активирует интерактивные компоненты бонуса (анимация, эффекты и т.п.) а так же уничтожает обект после активации
        /// </summary>
        public void InteractiveActivation()
        {
            audioSource.Play();

            animator.SetTrigger("Collect");

            effect.SetBool("BurstActivate", true);

            Destroy(this.gameObject, 0.7f);

            Destroy(this.transform.parent.gameObject, 2f);
        }
    }

