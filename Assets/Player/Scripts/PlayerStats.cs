using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] public float health,hunger,thirst,stamina; // Show in UI
    [SerializeField] private float maxHealth, maxHunger, maxThirst,maxStamina,SprintStaminaCost,JumpStaminaCost,timer,staminaRegenValue,staminaRegenDelay, hungerDt =0.02f, thirstDt=0.02f;
    [SerializeField] private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
        }
    }

    public void Heal(float heal)
    {
        health += heal;
        if (health >maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Eat(float food)
    {
        hunger += food;
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
    }

    public void Drink(float water)
    {
        thirst += water;
        if (thirst > maxThirst)
        {
            thirst = maxThirst;
        }
    }

    private void TakeStamina()
    {
        if (movement.isRunning)
        {
            stamina = stamina - SprintStaminaCost * Time.deltaTime;
            timer = staminaRegenDelay;
        }
        if (movement.isJumping)
        {
            stamina = stamina - JumpStaminaCost;
            timer = staminaRegenDelay;
            movement.isJumping = false;
        }
    }

    private void replenishStamina()
    {
        if (timer <= 0)
        {
            stamina += staminaRegenValue*Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hunger = hunger - hungerDt * Time.deltaTime;
        thirst = thirst - thirstDt * Time.deltaTime;
        if (stamina < 0) stamina = 0;
        if (stamina > maxStamina) stamina = maxStamina;
        TakeStamina();
        replenishStamina();
        timer -= Time.deltaTime;
        if (stamina <= 0)
        {
            movement.hasStamina = false;
        }
        else
        {
            movement.hasStamina = true;
        }
    }
}
