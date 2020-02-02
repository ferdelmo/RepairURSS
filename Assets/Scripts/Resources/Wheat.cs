using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    public float regenerateTime = 5f;

    public float previousRegenerate;

    public bool live = true;

    SpriteRenderer sr;

    public Sprite normal;

    public Sprite death;

    public GameObject wheatLeft;

    public Collider2D coll;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normal;
        previousRegenerate = regenerateTime;
        coll = GetComponent<Collider2D>();
    }

    public void Cut()
    {
        live = false;
        //StartCoroutine(Revive());
        //Instantiate(wheatLeft, transform.position, transform.rotation);
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
            coll.enabled = false;
            live = false;
            coll = GetComponent<Collider2D>();
            StartCoroutine(Revive());
            Instantiate(wheatLeft, transform.position, transform.rotation);
            previousRegenerate = 0;
            Debug.Log("wheat left");
        }
    }

    IEnumerator Revive()
    {
        float time = 0;
        sr.sprite = death;
        while (time < regenerateTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        live = true;
        sr.sprite = normal;
        coll.enabled = true;
    }


}
