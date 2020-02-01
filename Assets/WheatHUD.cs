using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheatHUD : MonoBehaviour
{
    private Text wheatText;

    private int currentWheats;
    private int totalWheats;

    // Start is called before the first frame update
    void Start()
    {
        currentWheats = USSRManager.Instance.numWheats;
        totalWheats = USSRManager.Instance.wheats2generate;

        wheatText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText()
    {
        wheatText.text = "Wheat: " + currentWheats + "/" + totalWheats;
    }
}
