using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeAttack : MonoBehaviour
{

    // Min distance to attack to player 
    public float distance = 1.0f;

    // Damage inflicted by this enemy
    public float damage = 20.0f;

    // Position of the player
    GameObject player;

    Health health;
    // Start is called before the first frame update

    float cadence = 1.0f;

    // Time since last hit
    float lastHitTime = 0;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            health = player.GetComponent<Health>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = player.transform.position - transform.position;
        if (distance >= dir.magnitude)
        {
            Debug.DrawLine(transform.position, dir, Color.green, 2.5f);
            if(lastHitTime > cadence)
            {
                health.Damage(damage);
                lastHitTime = 0;
            }

            lastHitTime += Time.deltaTime;
        }
    }

}
