using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

namespace WildBall.Controller
{
    public class ActivateEffectDeathPlayer : MonoBehaviour
    {
        [SerializeField] private VisualEffect effect;

        private void OnEnable()
        {
            PlayerController.OnDeathPlayer += StartEffect;
        }

        private void OnDisable()
        {
            PlayerController.OnDeathPlayer -= StartEffect;
        }

        private async void StartEffect()
        {
             effect.SetBool("BurstActivate", true);

             await Task.Delay(3000);

             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}