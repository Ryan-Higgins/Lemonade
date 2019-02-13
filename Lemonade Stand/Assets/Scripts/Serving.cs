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
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var hit in hits)
            {
                if (hit.transform.gameObject.CompareTag("Customer"))
                {
                    if (!hit.transform.gameObject.GetComponent<Person>().beenServed)
                    {
                        hit.transform.gameObject.GetComponent<Person>().serveIcon.gameObject.SetActive(false);


                        LemonadeSystem.money += (1 * LemonadeSystem.weatherMultiplier) * hit.transform.gameObject.GetComponent<Person>().thisMod;
                        LemonadeSystem.customers += 1;
                        hit.transform.gameObject.GetComponent<Person>().beenServed = true;
                        print(LemonadeSystem.money);
                    }
                }
            }
        }
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
