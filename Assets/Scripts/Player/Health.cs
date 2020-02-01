using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Player's health
    public float health = 100;
    // Player's maxhealth
    public float maxHealth = 100;

    public ProgressBar healthProgressBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float amount)
    {
        if(health + amount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health = health + amount;
        }
        //Debug.Log("Healed: " + health + amount);
    }

    public void Damage(float damage)
    {
        //Debug.Log("Daños");
        if(health - damage < 0)
        {
            health = 0;  
            OnDeath();
        }
        else
        {
            health = health - damage;
        }
        if( this.gameObject.tag == "Player") //Not called for enemy
        {
            healthProgressBar.setCurrentFill(health / maxHealth);
        }
        
        //Debug.Log("damaged");
    }

    void OnDeath()
    {
        Debug.Log("Ha muerto");
    }
}
