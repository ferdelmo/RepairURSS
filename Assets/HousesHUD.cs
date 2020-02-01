using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HousesHUD : MonoBehaviour
{
    private Text houseText;

    private int currentHouses;
    private int totalHouses;

    // Start is called before the first frame update
    void Start()
    {
        currentHouses = USSRManager.Instance.numHouses;
                
        Debug.Log("house TEXT: " + houseText);
    }

    private void Awake()
    {
        houseText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalHouses = USSRManager.Instance.houses2generate;
        houseText.text = "houseText: " + currentHouses + "/" + totalHouses;
    }
}
