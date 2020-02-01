using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class USSRManager : MonoBehaviour
{
    public Country country;

    public Text houseText;
    public Text wheatText;

    private HousesHUD housesHUD;
    private WheatHUD wheatHUD;

    private static USSRManager _instance;

    public float level = 1;

    public int numHouses = 0;

    public int numWheats = 0;

    public int banks2generate = 5;

    public int wheats2generate = 5;

    public int houses2generate = 5;

    public string nextScene;

    public static USSRManager Instance { get { return _instance; } }

    private void Start()
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

        housesHUD = houseText.GetComponent<HousesHUD>();
        wheatHUD = wheatText.GetComponent<WheatHUD>();

        housesHUD.updateText();
        wheatHUD.updateText();

        DontDestroyOnLoad(this.gameObject);
    }

    public void IncrementNumWheats()
    {
        numWheats++;
        wheatHUD.updateText();
    }

    public void IncrementNumHouses()
    {
        numHouses++;
        housesHUD.updateText();
    }

    public void OnPlayerDeath()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

    public void WonLevel()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        level++;
    }

}
