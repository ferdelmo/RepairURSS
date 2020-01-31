using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContructHouse : MonoBehaviour
{

    public int timeToConstruct;
    private float startTime;
    private bool isOnTrigger;

    void Start()
    {
        isOnTrigger = false;
    }

    void Update()
    {
         if (Input.GetButtonDown("hammer"))
         {
            startTime = Time.time;
         }
        if (Input.GetButton("Fire1"))
        {
            if (isOnTrigger && Time.time - startTime >= timeToConstruct)
            {
                Debug.Log("Constructed");
            }
        }

        if (Input.GetButtonUp("hammer"))
         {
            startTime = 0;
         }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isOnTrigger = false;
        }
    }
}
