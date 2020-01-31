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

        Debug.Log("Mov: " + directionMov);
        Debug.Log("Aim: " + directionAim);

        directionMov.Normalize();
        directionAim.Normalize();

        Vector2 pos = transform.position;

        //Mover al personaje
        transform.position = pos + directionMov * velocity * Time.deltaTime;

        Vector2 newPos = transform.position;

        //Orientar al personaje
        if(directionAim != Vector2.zero)
        {
            float rot_z = Mathf.Atan2(directionAim.y, directionAim.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
    }
}
