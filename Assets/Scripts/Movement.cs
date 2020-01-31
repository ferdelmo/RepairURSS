using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Velocidad del personaje
    public float velocity = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionMov = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 directionAim = new Vector2(Input.GetAxis("HorizontalAim"), Input.GetAxis("VerticalAim"));

        //Debug.Log("Mov: " + directionMov);
        //Debug.Log("Aim: " + directionAim);

        directionMov.Normalize();
        directionAim.Normalize();

        Vector2 pos = transform.position;

        transform.position = pos + directionMov * velocity * Time.deltaTime;

    }

}
