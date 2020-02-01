using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatLeft : MonoBehaviour
{
    // Health amount the player will be heal
    public float healthAmount = 20;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().Heal(healthAmount);
            Destroy(this.gameObject);
        }
    }
}
