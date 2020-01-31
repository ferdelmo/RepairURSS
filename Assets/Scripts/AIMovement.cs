using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeMovement : MonoBehaviour
{
    // Distance to player 
    public float distance = 5.0f;

    // Speed of the enemy
    public float speed = 7.0f;

    // Position of the player
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 dir = player.position - transform.position;
        if (dir.magnitude > distance) {
            dir.Normalize();
            Vector2 pos = transform.position;
            transform.position = pos + dir * speed * Time.deltaTime;
        }
    }
}
