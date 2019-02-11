using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serving : MonoBehaviour
{
    StandUpgrader thisStand;
    // Start is called before the first frame update
    void Start()
    {
        thisStand = GetComponent<StandUpgrader>();
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
            customer.gameObject.GetComponent<Person>().thisMod = thisStand.upgradeMultiplier;
        }
    }
}
