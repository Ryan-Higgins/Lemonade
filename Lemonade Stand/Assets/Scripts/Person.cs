﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Person : MonoBehaviour
{
    public GameObject serveIcon;

    public  bool atStand = false;
    private bool beenServed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        serveIcon = gameObject.transform.Find("Serve Me Icon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,1*Time.deltaTime,0);
        }

        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButton(0))
        {
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.CompareTag("Customer"))
                {
                    if (!beenServed)
                    {
                        serveIcon.gameObject.SetActive(false);
                        beenServed = true;
                        if (LemonadeSystem.atRightEvent)
                        {
                            LemonadeSystem.money += (1 * LemonadeSystem.weatherMultiplier) * LemonadeSystem.eventMultiplier;
                        } else if (!LemonadeSystem.atRightEvent)
                        {
                            LemonadeSystem.money += 1 * LemonadeSystem.weatherMultiplier;
                        }

                        LemonadeSystem.customers += 1;
                    }
                }
            }
        }
        if (!beenServed && atStand)
        {
            serveIcon.gameObject.SetActive(true);
        }
    }
}
