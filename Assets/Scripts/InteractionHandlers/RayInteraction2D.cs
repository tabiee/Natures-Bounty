using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RayInteraction2D : MonoBehaviour
{
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private float interactionRange = 12f;
    [SerializeField] private bool _isFromMouse;
    public bool isFromMouse
    {
        get { return _isFromMouse; }
        set
        {
            _isFromMouse = value;
            LoadInteractionOption();
        }
    }
    Vector2 mousePos;
    //private System.Func<Ray2D> rayProvider;
    private System.Func<Vector2> rayProvider;
    private PlayerInput input;
    private InputAction interactInput;
    void Start()
    {
        LoadInteractionOption();
        input = GetComponent<PlayerInput>();
        interactInput = input.actions["Interact"];
    }
    void Update()
    {
        RaycastForObject();
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        //call this method when the bool changes in the inspector
        LoadInteractionOption();
    }
#endif
    void LoadInteractionOption()
    {
        //delegate checks which option i chose and then uses that one.
        //whenever the bool is changed in Inspector it updates how it's doing the interaction

        Debug.Log("yes interaction ran");

        if (_isFromMouse)
        {
            //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //rayProvider = () => mousePos - (Vector2)transform.position;

        }
        else
        {
            rayProvider = () => transform.position - transform.right;
        }
    }
    void RaycastForObject()
    {
        //shoot a ray from either mouse position or object center (+1 above it) in the direction infront of it based on distance float, ignore specified layers
        //Ray2D ray = rayProvider.Invoke();
        Vector2 dir;
        //Vector2 dir = rayProvider.Invoke();
        RaycastHit2D hitData;


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - (Vector2)transform.position;
        Debug.DrawRay(transform.position, dir.normalized * interactionRange, _isFromMouse ? Color.green : Color.red, 0.1f, false);

        // hitData = Physics2D.Raycast(transform.position, ray.direction, interactionRange, interactionLayer);
        hitData = Physics2D.Raycast(transform.position, dir.normalized, interactionRange, interactionLayer);

        if (hitData.collider != null)
            {
            Debug.Log(hitData.collider.gameObject.name);

            //get the inherited interfaces from the hit object
            Component[] interactedObjects = hitData.transform.GetComponents(typeof(IInteractable));
            foreach (IInteractable interactableScripts in interactedObjects)
            {
                if (interactableScripts != null && interactInput.triggered)
                //if (interactableScripts != null && Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E pressed!");
                    //use the inherited method from the object, regardless of which script is using that method
                    interactableScripts.UseInteraction();
                }
            }
        }
    }
}
