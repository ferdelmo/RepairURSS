using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerContruct : MonoBehaviour
{

    public int timeToConstruct;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("hammer"))
        {
            startTime = Time.time;
        }

        if (Input.GetButtonUp("hammer"))
        {
            startTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter trigger");
        if (Input.GetButton("hammer"))
        {
            if (Time.time - startTime >= timeToConstruct)
            {
                Debug.Log("time");
            }
        }

    }
}
