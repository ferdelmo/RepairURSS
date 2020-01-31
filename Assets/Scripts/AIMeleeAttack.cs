using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeAttack : MonoBehaviour
{

    // Min distance to attack to player 
    public float distance = 1.0f;

    // Position of the player
    GameObject player;

    Movement sn;
    // Start is called before the first frame update

    float cadence = 1.0f;

    // Time since last hit
    float lastHitTime = 0;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            sn = player.GetComponent<Movement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = player.transform.position - transform.position;
        if (distance < dir.magnitude)
        {
            if(lastHitTime > cadence)
            {
                sn.Message();
                lastHitTime = 0;
            }

            lastHitTime += Time.deltaTime;
        }
    }
}
