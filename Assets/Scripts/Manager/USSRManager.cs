using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class USSRManager : MonoBehaviour
{
    public Country country;

    private static USSRManager _instance;

    public float level = 1;

    public int numHouses = 0;

    public int numWheats = 0;

    public int banks2generate = 2;

    public int wheats2generate = 5;

    public int houses2generate = 5;

    public string nextScene;

    private bool newLevelLoaded = false;

    public static USSRManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else{
            _instance = this;
        }

        numHouses = 0;
        numWheats = 0;

        banks2generate *= (int) level;

        houses2generate *= (int) level;

        wheats2generate *= (int) level;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (( !newLevelLoaded && numHouses == houses2generate && numWheats == wheats2generate))
        {
            newLevelLoaded = true;
            WonLevel();
        }
    }

    public void IncrementNumWheats()
    {
        numWheats++;
    }

    public void IncrementNumHouses()
    {
        numHouses++;
    }

    public void OnPlayerDeath()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    public void WonLevel()
    {
        nextScene = "SelectCountry";
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        level++;
        newLevelLoaded = false;
    }

    public void LoadNewLevel()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
