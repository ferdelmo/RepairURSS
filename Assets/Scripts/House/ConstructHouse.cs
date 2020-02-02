﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructHouse : MonoBehaviour
{

    public int timeToConstruct;
    public ProgressBar progress;
    public Sprite constructedHouse;
    public Sprite damagedHouse;
    public bool isConstructed = false;

    private Animator animPlayer;
    private float startTime;
    private bool isOnTrigger;
    private Camera cam;
    private Vector3 positionOutCanvas = new Vector3(1050, 0, 0 );

    bool pushed = false;

    void Start()
    {
        GameObject progressBars = GameObject.FindWithTag("ProgressBuilding");
        if (progressBars != null)
        {
            this.progress = progressBars.GetComponent<ProgressBar>();
        }
        isOnTrigger = false;
        if (isConstructed)
        {
            this.GetComponent<SpriteRenderer>().sprite = constructedHouse;
        }

        cam = Camera.main;
    }

    void Update()
    {
        if (!isConstructed)
        {
            this.GetComponent<SpriteRenderer>().sprite = damagedHouse; 
        }

        /*   

        if (isOnTrigger && Input.GetButton("Hammer") && !isConstructed)
        {
            progress.gameObject.SetActive(true);
            animPlayer.SetTrigger("attackhammer");

            Vector3 screenPos = cam.WorldToScreenPoint(this.gameObject.transform.position);
            progress.gameObject.transform.position = screenPos;
            float lapsedTime = Time.time - startTime;

            progress.setCurrentFill(lapsedTime / timeToConstruct);
            if (Time.time - startTime >= timeToConstruct)
            {
                this.GetComponent<SpriteRenderer>().sprite = constructedHouse;
                isConstructed = true;
                USSRManager.Instance.IncrementNumHouses();
                progress.gameObject.SetActive(false);
                //progress.gameObject.transform.position = positionOutCanvas;
            }
        }

        if (Input.GetButtonUp("Hammer"))
        {
            startTime = 0;
            progress.setCurrentFill(0);
            progress.gameObject.SetActive(false);
            //progress.gameObject.transform.position = positionOutCanvas;
        }
        */
        if (isOnTrigger && !isConstructed)
        {
            if (Input.GetButtonDown("Hammer") && !pushed)
            {
                startTime = Time.time;
                pushed = true;
            }
            else if (Input.GetButtonUp("Hammer"))
            {
                pushed = false;
                if (!isConstructed)
                {
                    progress.setCurrentFill(0);
                    progress.gameObject.SetActive(false);
                }
            }
            else if (pushed)
            {
                progress.gameObject.SetActive(true);
                if(animPlayer.GetCurrentAnimatorStateInfo(0).IsName("End")
                || animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Idle")
                || animPlayer.GetCurrentAnimatorStateInfo(0).IsName("Move"))
                {
                    animPlayer.SetTrigger("attackhammer");
                }

                Vector3 screenPos = cam.WorldToScreenPoint(this.gameObject.transform.position);
                progress.gameObject.transform.position = screenPos;
                float lapsedTime = Time.time - startTime;

                progress.setCurrentFill(lapsedTime / timeToConstruct);
                if (Time.time - startTime >= timeToConstruct)
                {
                    this.GetComponent<SpriteRenderer>().sprite = constructedHouse;
                    isConstructed = true;
                    USSRManager.Instance.IncrementNumHouses();
                    progress.gameObject.SetActive(false);
                    //progress.gameObject.transform.position = positionOutCanvas;
                }
            }
        }
        else if(!isConstructed)
        {
            if (pushed)
            {
                progress.setCurrentFill(0);
                progress.gameObject.SetActive(false);
                pushed = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOnTrigger = true;
            animPlayer = other.GetComponent<Animator>();
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
