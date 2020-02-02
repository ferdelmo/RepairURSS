using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDamage : MonoBehaviour
{
    public float hammerDamage;
    public bool isPushedAttack;
    private Animator animPlayer;
    public Collider2D hammer;

    public delegate void OnDown();

    public OnDown onDown;
    public OnDown onUp;
    
    // Start is called before the first frame update
    void Start()
    {
        isPushedAttack = false;
        animPlayer = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hammer") && !isPushedAttack)
        {
            isPushedAttack = true;
            if (animPlayer.GetCurrentAnimatorStateInfo(0).IsName("End")
                || animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Idle")
                || animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Move"))
            {
                animPlayer.SetTrigger("attackhammer");
            }
            onDown();
        }

        if (Input.GetButtonUp("Hammer"))
        {
            isPushedAttack = false;
            onUp();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("bam");
            other.GetComponent<Health>().Damage(hammerDamage);
        }
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isOnTrigger = false;
        }
    }*/
}
