using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D customer)
    {
        if (customer.CompareTag("Customer"))
        {
            customer.gameObject.GetComponent<Person>().atStand = true;
        }
    }
}
