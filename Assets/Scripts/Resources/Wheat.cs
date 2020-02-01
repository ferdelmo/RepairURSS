﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    public float regenerateTime = 5f;

    public float previousRegenerate;

    public bool live = true;

    public Color death;

    public Color alive;

    SpriteRenderer sr;

    public GameObject wheatLeft;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = alive;
        previousRegenerate = regenerateTime;
    }

    public void Cut()
    {
        live = false;
        StartCoroutine(Revive());
        Instantiate(wheatLeft, transform.position, transform.rotation);
    }

    private void Update()
    {
        /*if (live)
        {
            previousRegenerate = previousRegenerate + Time.deltaTime;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checkear la colision con la hoz
        if(collision.tag == "Sickle" && live )
        {
            live = false;
            StartCoroutine(Revive());
            Instantiate(wheatLeft, transform.position, transform.rotation);
            previousRegenerate = 0;
            Debug.Log("wheat left");
        }
    }

    IEnumerator Revive()
    {
        float time = 0;
        while (time < regenerateTime)
        {
            sr.color = Color.Lerp(death, alive, time / regenerateTime);
            time += Time.deltaTime;
            yield return null;
        }
        live = true;
    }


}
