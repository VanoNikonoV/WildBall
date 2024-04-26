using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isOpen;

    public string GetDescription()
    {
        if (isOpen) return "Press [E] to <color=red>close</color> the door";
        return "Press [E] to <color=green>open</color> the door";
    }

    public void Interact()
    {
        isOpen = !isOpen;
        if (isOpen)
            animator.SetBool("isOpen", true);
        else
            animator.SetBool("isOpen", false);
    }

    void Start()
    {
        if (isOpen) animator.SetBool("isOpen", true);

    }

   
}
