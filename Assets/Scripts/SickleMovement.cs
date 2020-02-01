using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleMovement : MonoBehaviour
{
    public float maxTimeToReach = 5.0f;
    public float maxTimeToReturn = 5.0f;
    public float speed = 0.1f;
    public float strength = 1.0f;
    public Vector3 rotation;
    private bool sickleShooted = false;
    public Vector2 playerPosition;
    private float distanceTravelled;
    private bool dirRight = true;
    private float timeTravelledToObjective = 0.0f;
    private float timeTravelledToPlayer = 0.0f;

    private float destinationReached;
    private float playerReached;
    private Vector2 sicklePosition;
    private float range;
    private float downTime;
    private float pressTime;
    private float countDown = 1.0f;

    private bool keyPressed = false;


    private float currentDistance = 0.0f;
    private float realDistance;
    public float maxDistance = 20.0f;
    public const float maxPressedTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.parent.position;
        rotation = transform.forward;

    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.L) && !keyPressed)
        {
            downTime = Time.time;
            keyPressed = true;
        }

        if( Input.GetKeyUp( KeyCode.L))
        {
            float tiempoPasado = Time.time- downTime;
            strength = tiempoPasado / maxTimeToReach;
            Mathf.Min(1, strength);
            currentDistance = 0.0f;
            realDistance = strength * maxDistance;
            Debug.Log("realDistance: " + realDistance);
            timeTravelledToPlayer = 0.0f;
            sickleShooted = true;
            keyPressed = false;
        }

        if( sickleShooted)
        {    
            //transform.Translate( transform.parent.transform.forward * Time.deltaTime * speed);
            transform.position += transform.parent.up * speed * Time.deltaTime;

            currentDistance += Time.deltaTime * speed;
            Debug.Log("currentDistance" + currentDistance);

            //Debug.DrawRay(transform.position, transform.position + transform.parent.up * currentDistance, Color.black, 5f);
            //transform.parent.position = transform.position + transform.parent.forward * currentDistance;
            if ( currentDistance >= realDistance)
            {
                timeTravelledToPlayer += Time.deltaTime;
                playerReached = timeTravelledToPlayer / maxTimeToReturn;
                transform.position = Vector2.Lerp(transform.position, playerPosition, playerReached);

                if (playerReached >= 1)
                {
                    sickleShooted = false;
                }
            }                        
        } 


        

        /*if (dirRight)
            transform.Translate(Vector2.right * strength * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * strength * Time.deltaTime);


        if( sickleThrown)
        {
            while( transform.position != playerPosition)
            {
                
            }
        }
        
        if (transform.position.x >= 4.0f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -4)
        {
            dirRight = true;
        }*/
        /*
        Vector3 Destination = new Vector3(0, 0, 100);
        Vector3 Traveller = new Vector3(0, 0, 0);
        float step = 2.5f;
        while (Traveller != Destination)
        {
            Traveller = Vector3.MoveTowards(Traveller, Destination, step);
        }

        while( Tra)
        */
        //transform.Translate(Traveller * strength * Time.deltaTime);
        /*
        distanceTravelled += Vector3.Distance(initialPosition, transform.position);

        if (distanceTravelled < 100f)
            transform.Translate(rotation * strength * Time.deltaTime);


        if (distanceTravelled >= 100f)
        {
            transform.Translate(rotation * strength * Time.deltaTime);
        }
        */
        /*
        if ( timeToReturn < 0 && timeToReturn > -maxTimeToReturn)
        {
            transform.position += rotation * strength;
            --timeToReturn;
        } else if( timeToReturn <= -maxTimeToReturn)
        {
            timeToReturn = maxTimeToReturn;
        } else if( timeToReturn < 0 && timeToReturn <= maxTimeToReturn)
        {
            transform.position -= rotation * strength;
            ++timeToReturn;
        }*/

        /*
        if( timeToReturn >= maxTimeToReturn)
        {
            transform.Translate(Vector3.left * strength * Time.deltaTime);
        } else if( timeToReturn < maxTimeToReturn)
        {
            transform.Translate(Vector3.right * strength * Time.deltaTime);
        }

        if( timeToReturn > -maxTimeToReturn && )
        {
            transform.position -= rotation * strength;
            timeToReturn++;
        } else if( timeToReturn > maxTimeToReturn && timeToReturn < maxTimeToReturn * 100)
        {
            transform.position += rotation * strength;
            timeToReturn--;
        }*/


    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
