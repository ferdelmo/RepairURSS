using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject weat;

    // Start is called before the first frame update
    void Start()
    {

        GenerateObjects go = this.gameObject.AddComponent<GenerateObjects>();

        go.obj = weat;

        go.center = transform;

        go.Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
