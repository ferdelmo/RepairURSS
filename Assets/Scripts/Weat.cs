using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weat : MonoBehaviour
{
    public float regenerateTime = 5f;

    public bool live = true;

    public Color death;

    public Color alive;

    SpriteRenderer sr;

    public GameObject weatLeft;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = alive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checkear la colision con la hoz
        if(collision.tag == "Player" && live)
        {
            live = false;
            StartCoroutine(Revive());
            Instantiate(weatLeft, transform.position, transform.rotation);
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
