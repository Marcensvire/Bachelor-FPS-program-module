using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AdsDisablerForDropping : MonoBehaviour
{
    private PlayerControls controls;

    [SerializeField] private IntPickUpAndDrop equipScript;
    [SerializeField] private AimDownSights aimingScript;

    private void OnEnable()
    {
        
        controls = new PlayerControls();
        controls.Enable();
        controls.WorldActions.Interact.performed += context => Pickup();
        controls.WorldActions.Drop.performed += context => DisableAds();
    }

    void Start()
    {
        equipScript = GetComponent<IntPickUpAndDrop>();
        aimingScript = GetComponent<AimDownSights>();
    }

    private void Pickup()
    {
        Invoke("EnableAds", 0.1f);
    }

    private void EnableAds()
    {
        if (equipScript.isWeapon==true && equipScript.equipped == true )
        {
            aimingScript.enabled = true;
        }
    }

    private void DisableAds()
    {
        if (equipScript.isWeapon == true && equipScript.equipped == true)
        {
            aimingScript.aiming = false;
            aimingScript.coordsHolder = new Vector3(0, 0, 0);
            transform.localPosition = new Vector3(0, 0, 0);
            aimingScript.enabled = false;
        }
    }
}
