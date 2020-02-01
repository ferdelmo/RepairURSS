using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SickleMovement : MonoBehaviour
{
    public Slider slider;
    public GameObject player;
    public float maxTimeToReach = 5.0f;
    public float maxTimeToReturn = 5.0f;
    public float speed = 0.1f;
    private float strength = 1.0f;
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

    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.L) && !keyPressed)
        {
            InitializeSliderValue();
            downTime = Time.time;       
            keyPressed = true;
        }

        //Hacer que el slider se actualice con el tiempo hasta que llegue a 1
        if( keyPressed && !sickleShooted) {
            SetSliderValue();
        }

        if( Input.GetKeyUp( KeyCode.L) && !sickleShooted)
        {
            float tiempoPasado = Time.time - downTime;
            strength = tiempoPasado / maxTimeToReach;
            Mathf.Min(1, strength);
            currentDistance = 0.0f;
            realDistance = strength * maxDistance;
            //Debug.Log("realDistance: " + realDistance);
            timeTravelledToPlayer = 0.0f;
            HideSlider();
            sickleShooted = true;
            keyPressed = false;
        }

        if( sickleShooted)
        {    
            transform.position += player.transform.up * speed * Time.deltaTime;
            currentDistance += Time.deltaTime * speed;

            if ( currentDistance >= realDistance)
            {
                timeTravelledToPlayer += Time.deltaTime;
                playerReached = timeTravelledToPlayer / maxTimeToReturn;
                transform.position = Vector2.Lerp(transform.position, player.transform.position, playerReached);

                if (playerReached >= 1)
                {
                    sickleShooted = false;
                }
            }                        
        } else
        {
            timeTravelledToPlayer += Time.deltaTime;
            playerReached = timeTravelledToPlayer / maxTimeToReturn;
            transform.position = Vector2.Lerp(transform.position, player.transform.position /*transform.parent.position*/, playerReached);
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

    private void InitializeSliderValue()
    {
        slider.value = 0.0f;
    }

    private void SetSliderValue()
    {
        if( keyPressed)
        {
            slider.gameObject.SetActive( true);
            slider.value += 0.01f;
        }       
    }

    private void HideSlider()
    {
        slider.gameObject.SetActive( false);
    }

}
