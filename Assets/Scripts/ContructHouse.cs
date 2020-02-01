using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContructHouse : MonoBehaviour
{

    public int timeToConstruct;
    public ProgressBar progress;
    private float startTime;
    private bool isOnTrigger;

    void Start()
    {
        isOnTrigger = false;
        progress.gameObject.SetActive(false);
    }

    void Update()
    {
         if (Input.GetButtonDown("hammer"))
         {
            startTime = Time.time;
         }
        if (Input.GetButton("Fire1"))
        {
            progress.gameObject.SetActive(true);
            float lapsedTime = Time.time - startTime;
            Debug.Log((lapsedTime  / timeToConstruct));
            //ProgressBar progress = GetComponent<ProgressBar>();
            progress.setCurrentFill(lapsedTime / timeToConstruct);
            //setCurrentFill(lapsedTime*100/ timeToConstruct);
            if (isOnTrigger && Time.time - startTime >= timeToConstruct)
            {
                Debug.Log("Constructed");
            }
        }

        if (Input.GetButtonUp("hammer"))
         {
            startTime = 0;
            progress.setCurrentFill(0);
            progress.gameObject.SetActive(false);
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
