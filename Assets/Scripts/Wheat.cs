using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    public float regenerateTime = 5f;

    public bool live = true;

    public Color death;

    public Color alive;

    SpriteRenderer sr;

    public GameObject wheatLeft;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = alive;
    }

    public void Cut()
    {
        live = false;
        StartCoroutine(Revive());
        Instantiate(wheatLeft, transform.position, transform.rotation);
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
