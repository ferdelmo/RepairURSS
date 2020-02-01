using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SickleMovement : MonoBehaviour
{
    public Slider slider;
    private bool meleeAttack = false;
    public GameObject player;
    public float maxTimeToReach = 5.0f;
    public float maxTimeToReturn = 5.0f;
    public float speed = 3.0f;
    private float strength = 1.0f;
    private bool sickleShooted = false;
    public Vector2 playerPosition;
    private float timeTravelledToPlayer = 0.0f;

    private float playerReached;
    private float downTime;

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
        if( Input.GetButtonDown( "Sickle") && !keyPressed)
        {
            InitializeSliderValue();
            downTime = Time.time;       
            keyPressed = true;
        }

        //Hacer que el slider se actualice con el tiempo hasta que llegue a 1
        if (keyPressed && !sickleShooted)
        {
            SetSliderValue();
        }

        if ( Input.GetButtonUp( "Sickle")  && !sickleShooted)
        {
            float tiempoPasado = Time.time - downTime;
            if( tiempoPasado < 0.25f)
            {
                meleeAttack = true;
                Debug.Log("Melee attack");
                realDistance = 0.0f;
            } else
            {
                meleeAttack = false;
                realDistance = strength * maxDistance;
            }
            strength = tiempoPasado / maxTimeToReach;
            Mathf.Min(1, strength);
            currentDistance = 0.0f;          
            //Debug.Log("realDistance: " + realDistance);
            timeTravelledToPlayer = 0.0f;
            HideSlider();
            sickleShooted = true;
            keyPressed = false;
        }

        if ( sickleShooted)
        {    
            if( realDistance != 0)
            {
                transform.position += player.transform.up * speed * Time.deltaTime;
            }
   
            currentDistance += Time.deltaTime * speed;

            if ( currentDistance >= realDistance)
            {
                timeTravelledToPlayer += Time.deltaTime;
                playerReached = timeTravelledToPlayer / maxTimeToReturn;
                transform.position = Vector2.Lerp(transform.position, player.transform.position, playerReached);

                if (playerReached >= 1.0f || ((player.transform.position - transform.position).magnitude < 1.0f))
                {
                    Debug.Log("jugador alcanzado!!");
                    sickleShooted = false;
                }
            }                        
        } else
        {
            timeTravelledToPlayer += Time.deltaTime;
            playerReached = timeTravelledToPlayer / maxTimeToReturn;
            transform.position = Vector2.Lerp(transform.position, player.transform.position /*transform.parent.position*/, playerReached);
        }
    }

    private void InitializeSliderValue()
    {
        slider.value = 0.0f;
    }

    private void SetSliderValue()
    {
        slider.gameObject.SetActive( true);
        slider.value += 0.02f;
    }

    private void HideSlider()
    {
        slider.gameObject.SetActive( false);
    }

}
