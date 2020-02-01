using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructHouse : MonoBehaviour
{

    public int timeToConstruct;
    public ProgressBar progress;
    public Sprite constructedHouse;
    public Sprite damagedHouse;
    public bool isConstructed = false;
    private float startTime;
    private bool isOnTrigger;
    private Camera cam;

    void Start()
    {
        isOnTrigger = false;
        if (isConstructed)
        {
            this.GetComponent<SpriteRenderer>().sprite = constructedHouse;
        }

        progress.gameObject.SetActive(false);
        cam = Camera.main;
    }

    void Update()
    {

        if (!isConstructed)
        {
            this.GetComponent<SpriteRenderer>().sprite = damagedHouse; 
        }

        if (Input.GetButtonDown("Hammer"))
         {
            startTime = Time.time;
        }
        if (isOnTrigger && Input.GetButton("Hammer") && !isConstructed)
        {
            Debug.Log("enter");
            progress.gameObject.SetActive(true);

            Vector3 screenPos = cam.WorldToScreenPoint(this.gameObject.transform.position);
            progress.gameObject.transform.position = screenPos;
            float lapsedTime = Time.time - startTime;

            progress.setCurrentFill(lapsedTime / timeToConstruct);
            if (Time.time - startTime >= timeToConstruct)
            {
                Debug.Log("Constructed");
                this.GetComponent<SpriteRenderer>().sprite = constructedHouse;
                isConstructed = true;
            }
        }

        if (Input.GetButtonUp("Hammer"))
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
