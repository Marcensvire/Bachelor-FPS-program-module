using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    private PlayerControls controls;

    private GameObject raycastedOBJ;

    RaycastHit hit;

    [SerializeField] private int rayLength = 10;
   // [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string TagInteract;
    //   [SerializeField] private Image uiCrosshair;
    [SerializeField] private bool onInteractable=false;
    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.WorldActions.Enable();
        controls.WorldActions.Interact.performed += context => ActInteract();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        // if (Physics.Raycast(transform.position, forward, out hit, rayLength, layerMaskInteract.value))
        
        if (Physics.Raycast(transform.position, forward, out hit, rayLength) && hit.collider.CompareTag(TagInteract))
        {
            onInteractable = true;

        }
        else
        {
            onInteractable = false;
        }


    }

    void ActInteract()
    {
        if (onInteractable)
        {
            raycastedOBJ = hit.collider.gameObject;
            raycastedOBJ.GetComponent<Interactable>().OnInteraction();
        }
    }
}
