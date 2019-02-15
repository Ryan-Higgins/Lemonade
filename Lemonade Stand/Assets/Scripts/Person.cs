using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Person : MonoBehaviour
{
    public GameObject serveIcon;
    public Color enemyColor;
    public Color unServedColor;
    private Color ogColor;

    public bool atStand;
    public bool beenServed;
    public int thisMod;
    public bool AlwaysShowIcon = false;
    public GameObject served;
    
    // Start is called before the first frame update
    void Start()
    {
        beenServed = false;
        atStand = false;
        ogColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //if (Input.GetMouseButtonUp(0))
        //{
        //    foreach (var hit in hits)
        //    {
        //        if (hit.transform.gameObject.CompareTag("Customer"))
        //        {
        //            if (!beenServed)
        //            {
        //                serveIcon.gameObject.SetActive(false);
                        

        //                LemonadeSystem.money += (1 * LemonadeSystem.weatherMultiplier) * thisMod;
        //                LemonadeSystem.customers += 1;
        //                hit.transform.gameObject.GetComponent<Person>().beenServed = true;
        //                print(LemonadeSystem.money);
        //            }
        //        }
        //    }
        //}
        //if (!beenServed && atStand)
        //{
        //    serveIcon.gameObject.SetActive(true);
        //}
        //else if (beenServed && atStand)
        //{
        //    serveIcon.gameObject.SetActive(false);
        //}
    }
    public void NotServed()
    {
        //serveIcon.gameObject.GetComponent<SpriteRenderer>().color = unServedColor;
        serveIcon.gameObject.SetActive(true);
    }
    public void Served(bool byPlayer = false)
    {
      //serveIcon.gameObject.GetComponent<SpriteRenderer>().color = enemyColor;
        //served.gameObject.SetActive(true);
        if (!byPlayer)
        {
            serveIcon.gameObject.GetComponent<SpriteRenderer>().color = enemyColor;
        }
        else
        {
            //serveIcon.gameObject.GetComponent<SpriteRenderer>().color = ogColor;
            serveIcon.gameObject.SetActive(false);
            served.gameObject.SetActive(true);
        }
        
        //serveIcon.gameObject.SetActive(true);
        //served.gameObject.SetActive(true);
        beenServed = true;
    }
    public void HideIcon()
    {
        if (!AlwaysShowIcon || !beenServed)
        serveIcon.gameObject.SetActive(false);
        served.gameObject.SetActive(false);
    }
}
