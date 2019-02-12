using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Person : MonoBehaviour
{
    public GameObject serveIcon;


    public bool atStand;
    public bool beenServed;
    public int thisMod;
    
    // Start is called before the first frame update
    void Start()
    {
        beenServed = false;
        atStand = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.CompareTag("Customer"))
                {
                    if (!beenServed)
                    {
                        serveIcon.gameObject.SetActive(false);
                        

                        LemonadeSystem.money += (1 * LemonadeSystem.weatherMultiplier) * thisMod;
                        LemonadeSystem.customers += 1;
                        hit.transform.gameObject.GetComponent<Person>().beenServed = true;
                        print(LemonadeSystem.money);
                    }
                }
            }
        }
        if (!beenServed && atStand)
        {
            serveIcon.gameObject.SetActive(true);
        } else if (beenServed && atStand)
        {
            serveIcon.gameObject.SetActive(false);
        }
    }
}
