﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Velocidad del personaje
    public float velocity = 10.0f;

    Vector2 direction;
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

        direction = directionMov;

        Vector2 pos = transform.position;

        //Mover al personaje
        transform.position = pos + directionMov * velocity * Time.deltaTime;

        Vector2 newPos = transform.position;

        //Orientar al personaje
        if(directionAim != Vector2.zero)
        {
            float rot_z = OrientDirection(directionAim);
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
    }

    public Vector2 GetVelocity()
    {

        return direction * velocity;
    }

    //Return the angle to use as Quaternion.Euler(0,0,rot_z).
    public static float OrientDirection(Vector2 dir)
    {
        dir.Normalize();
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return rot_z - 90f;
    }

}
