using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverItem : MonoBehaviour
{
    private PlayerControls controls;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] private float heal, food, water, charges;
    // Start is called before the first frame update

    // Start is called before the first frame update
    private void Awake()
    {

        this.controls = new PlayerControls();
        this.controls.WorldActions.Enable();
    }

    void Start()
    {
        
        controls.WorldActions.Shoot.performed += context => Input();
        playerStats = GameObject.Find("FirstPersonPlayer").GetComponent<PlayerStats>();

    }

    new private void Input()
    {
        if (charges > 0)
        {
            playerStats.Heal(heal);
            playerStats.Eat(food);
            playerStats.Drink(water);
            charges--;

        }

    }


}
