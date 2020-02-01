using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContructHouse : MonoBehaviour
{

    public int timeToConstruct;
    public ProgressBar progress;
    private float startTime;
    private bool isOnTrigger;
    private Camera cam;

    void Start()
    {
        isOnTrigger = false;
        progress.gameObject.SetActive(false);
        cam = Camera.main;
    }

    void Update()
    {
         if (Input.GetButtonDown("hammer"))
         {
            startTime = Time.time;
         }
        if (isOnTrigger && Input.GetButton("hammer"))
        {
            progress.gameObject.SetActive(true);

            Vector3 screenPos = cam.WorldToScreenPoint(this.gameObject.transform.position);
            progress.gameObject.transform.position = screenPos;
            float lapsedTime = Time.time - startTime;

            progress.setCurrentFill(lapsedTime / timeToConstruct);
            if (Time.time - startTime >= timeToConstruct)
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
            //progress.gameObject.transform.Rotate(new Vector3(0, 0, this.gameObject.transform.rotation.z-180 ));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isOnTrigger = false;
            //progress.gameObject.transform.rotation = this.gameObject.transform.rotation;
        }
    }
}
