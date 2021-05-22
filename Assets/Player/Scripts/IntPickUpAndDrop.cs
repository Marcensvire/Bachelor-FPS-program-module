using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntPickUpAndDrop : Interactable
{
    private PlayerControls controls;

    [SerializeField] private Projectile_weapon gun_script;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Collider collider;
    [SerializeField] private Transform player, gunContainer, camera;
    [SerializeField] private float dropForwardForce, dropUpwardForce;
    [SerializeField] public bool equipped, isWeapon = false;
    [SerializeField] private static bool slotFull; //static - changind this in one script will change in all otherscripts

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.WorldActions.Enable();
        controls.WorldActions.Drop.performed += context => Drop();
        player = GameObject.Find("FirstPersonPlayer").transform;
        camera = GameObject.Find("FirstPersonPlayer/Main Camera").transform;
        gunContainer = GameObject.Find("FirstPersonPlayer/Main Camera/GunContainer").transform;
        gun_script = GetComponent<Projectile_weapon>();

        if (!equipped)
        {
            if (isWeapon) gun_script.enabled = false; 
            rigidBody.isKinematic = false;
            collider.isTrigger = false;
        }
        if (equipped)
        {
            if (isWeapon) gun_script.enabled = true;
            rigidBody.isKinematic = true;
            collider.isTrigger = true;
            slotFull = true;
        }

    }

    private void Drop()
    {
        if (equipped)
        {

            equipped = false;
            slotFull = false;


            transform.SetParent(null); //Set parent to null


            rigidBody.isKinematic = false;//Make Rigidbody not kinematic and BoxCollider normal
            collider.isTrigger = false;

            //AddForce
            rigidBody.AddForce(camera.forward * dropForwardForce, ForceMode.Impulse);
            rigidBody.AddForce(camera.up * dropUpwardForce, ForceMode.Impulse);
            //Add random rotation
            float random = Random.Range(-1f, 1f);
            rigidBody.AddTorque(new Vector3(random, random, random) * 10);

            //Disable script
            if (isWeapon) gun_script.enabled = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInteraction()
    {
        Debug.Log("I have Interacted pick up and drop");
        if (!equipped &&  !slotFull)
        {
            equipped = true;
            slotFull = true; //So u cant pick up any other gun

            //Make a child of the gunContainer and move it to default position
            transform.SetParent(gunContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            //transform.localScale = Vector3.one;

            //Make Rigidbody kinematic and Collider a trigger
            rigidBody.isKinematic = true;
            collider.isTrigger = true;

            //Enable script
            if (isWeapon) gun_script.enabled = true;
        }
    }
}
