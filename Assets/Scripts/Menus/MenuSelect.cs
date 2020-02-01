using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{

    public List<CountryController> countries;

    public CountryController selected;
    // Start is called before the first frame update
    void Start()
    {
        selected = countries[0];   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(CountryController c)
    {
        selected.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

        selected = c;

        selected.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
    }
}
