using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public GameObject serveIcon;

    public bool isServed = false;
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
        
        if (isServed && atStand)
        {
            if (!beenServed)
            {
                LemonadeSystem.money += 1;
                LemonadeSystem.customers += 1;
                isServed = false;
                beenServed = true;
            }
        } else if (!isServed && atStand)
        {
            serveIcon.gameObject.SetActive(true);
        }
    }
}
