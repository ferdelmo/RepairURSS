﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Player's health
    public float health = 100;
    // Player's maxhealth
    public float maxHealth = 100;

    public ProgressBar healthProgressBar;

    public AudioSource hitSound;

    public GameObject particleEffects;

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
        hitSound.Play();
        //Debug.Log("Daños");
        if (gameObject.tag == "Player") //Not called for enemy
        {
            healthProgressBar.setCurrentFill(health / maxHealth);
        }
        else
        {
              this.gameObject.SetActive(false); 
        }
        if (health - damage <= 0)
        {
            health = 0;  
            OnDeath();
        }
        else
        {
            health = health - damage;
        }
        
        //Debug.Log("damaged");
    }

    void OnDeath()
    {
        Debug.Log("BICHO MUERTOOO");
        GameObject chispitas = Instantiate(particleEffects, gameObject.transform.position, Quaternion.identity) as GameObject;
        chispitas.GetComponent<ParticleSystem>().Emit(1);
        Destroy(chispitas, 0.5f);
        //gameObject.transform.forward, new Vector3( 1.0f, 1.0f, 0.0f), 5.0f, 2.0f, Color.red
        //particleEffects.
        if ( gameObject.tag == "Player")
        {
            USSRManager.Instance.numWheats = 0;
            USSRManager.Instance.numHouses = 0;
            Debug.Log("Ha muerto: " + this.gameObject.tag);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if( gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        
    }

}
