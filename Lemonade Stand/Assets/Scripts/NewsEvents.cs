using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsEvents : MonoBehaviour
{
    public GameObject[] newsImage;
    Events currentEvent;
    // Start is called before the first frame update
    void Start()
    {
        currentEvent = (Events)Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEvent == Events.Event0)
        {
            newsImage[0].SetActive(true);
        }
        else if (currentEvent == Events.Event1)
        {
            newsImage[1].SetActive(true);
        }
        else if (currentEvent == Events.Event2)
        {
            newsImage[2].SetActive(true);
        }
    }
}
enum Events { Event0, Event1, Event2};
