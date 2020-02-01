using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HousesHUD : MonoBehaviour
{
    private Text wheatText;

    // Start is called before the first frame update
    void Start()
    {
        wheatText = GetComponent<Text>();
        //totalWheat = levelManager.totalWheat;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateText()
    {
        //wheatText.text = "Wheat: " + actualWheat + "/" + totalWheat;
    }
}
