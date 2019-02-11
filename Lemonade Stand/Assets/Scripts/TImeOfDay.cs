using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TImeOfDay : MonoBehaviour
{ 

public GameObject minuteHand, hourHand;
    float delay = 25 / 12;



    private void Start()
    {

    }

    private void Update()
    {

        minuteHand.transform.Rotate(new Vector3(0, 0, -1), 25 * Time.deltaTime);
        hourHand.transform.Rotate(new Vector3(0, 0, -1), delay * Time.deltaTime);
    }
}
