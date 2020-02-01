﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{


    public Image flag;

    public Text title;

    public AudioSource audioSource;

    public GameObject menu;

    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartUp(5f, 1f));
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float Accelerated(float t)
    {
        return Mathf.Pow(t, 2);
    }

    IEnumerator StartUp(float delay, float duration)
    {
        float time = 0;
        Color fin = flag.color;
        Color ini = fin;
        fin.a = 1;
        ini.a = 0;

        //TODOS LOS ALPHA
        flag.color = ini;

        Color c = title.color;
        c.a = ini.a;
        title.color = c;

        yield return new WaitForSeconds(delay);
        while (time < duration)
        {
            time += Time.deltaTime;

            ini.a = Accelerated(time / duration);

            //SETEAR LOS COLORES
            flag.color = ini;
            c.a = ini.a;
            title.color = c;

            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        menu.SetActive(true);
    }

    public void loadPlayScene() 
    {
        SceneManager.LoadScene("SelectCountry");
    }

    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }
}
