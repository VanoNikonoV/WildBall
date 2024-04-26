using UnityEngine;

public class ChangedAnimation : MonoBehaviour
{
    private Animator _anim;

    /// <summary>
    /// ћассив анимици€ дл€ из ротаций
    /// </summary>
    [SerializeField] private AnimationClip[] animations;

    /// <summary>
    /// ”станавливает случайную анимацию из массива animations
    /// </summary>
    private void SetAnimation()
    {
        int x = Random.Range(0, animations.Length);

        string name = "Base Layer." + animations[x].name;

        if (_anim != null)
        {
            _anim.Play(name, 0);
        }
    }
    
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
}
