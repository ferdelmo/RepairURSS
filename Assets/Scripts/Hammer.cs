using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerContruct : MonoBehaviour
{
    private bool isOnTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isOnTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("hammer") && isOnTrigger)
        {
            Debug.Log("Daño");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isOnTrigger = false;
        }
    }
}
