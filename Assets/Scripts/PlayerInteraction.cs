using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private TextMeshProUGUI interactionText;
    private bool hitSomething = false;
    private IInteractable interactable;

    private PlayerInput actions;

    private void Awake()
    {
        actions = new PlayerInput();
        actions.UI.OpenDoore.performed += OpenAndCloseeDoore;
    }
    private void OpenAndCloseeDoore(InputAction.CallbackContext context)
    {
        interactable?.Interact();
    }
    private void OnTriggerStay(Collider other)
    {
        interactable = other.gameObject.GetComponent<IInteractable>();

        if (interactable != null) 
        {
            hitSomething = true;
            interactionText.text = interactable.GetDescription();
        }
        interactionUI.SetActive(hitSomething);
    }
    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.gameObject.GetComponent<IInteractable>();

        if (interactable != null)
        {
            hitSomething = false;
            interactionText.text = interactable.GetDescription();
        }
        interactionUI?.SetActive(hitSomething);
    }

    private void OnEnable() { actions.UI.Enable(); }
    private void OnDisable() { actions.UI.Disable(); }

    //InputManager

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        interactable?.Interact();
    //    }
    //}
}
