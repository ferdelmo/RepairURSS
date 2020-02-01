using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDamage : MonoBehaviour
{
    public float hammerDamage;
    private bool isPushedAttack;
    private Animator animPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isPushedAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hammer"))
        {
            isPushedAttack = true;
            animPlayer = this.GetComponent<Animator>();
            animPlayer.SetTrigger("attackhammer");
        }

        if (Input.GetButtonUp("Hammer"))
        {
            isPushedAttack = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPushedAttack && other.gameObject.CompareTag("Enemy"))
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
