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
        totalHouses = USSRManager.Instance.houses2generate;
        houseText = GetComponent<Text>();
        Debug.Log("house TEXT: " + houseText);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateText()
    {
        houseText.text = "houseText: " + currentHouses + "/" + totalHouses;
    }
}
