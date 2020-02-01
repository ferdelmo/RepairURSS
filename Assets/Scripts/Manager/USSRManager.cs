using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USSRManager : MonoBehaviour
{
    public Country country;

    private static USSRManager _instance;

    public float level = 1;

    public int numHouses = 0;

    public int numBanks = 0;

    public int numWheats = 0;

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

        DontDestroyOnLoad(this.gameObject);
    }

    public void IncrementNumWheats()
    {
        numWheats++;
    }

    public void IncrementNumBanks()
    {
        numBanks++;
    }

    public void IncrementNumHouses()
    {
        numHouses++;
    }

    public void OnPlayerDeath()
    {

    }

    public void WonLevel()
    {
        level++;
    }

}
