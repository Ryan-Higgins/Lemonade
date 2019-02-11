using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsEvents : MonoBehaviour
{
    public List<GameObject> newsImage;
    Events currentEvent;
    public GameObject e1;
    public GameObject e2;
    public GameObject e3;

    void Start()
    {
        currentEvent = (Events)Random.Range(0, 2);
        newsImage.Add(e1);
        newsImage.Add(e2);
        newsImage.Add(e3);
    }

    void Update()
    {
        if (currentEvent == Events.Event0)
        {
            newsImage[0].SetActive(true);
            newsImage[1].SetActive(false);
            newsImage[2].SetActive(false);
        }
        else if (currentEvent == Events.Event1)
        {
            newsImage[0].SetActive(false);
            newsImage[1].SetActive(true);
            newsImage[2].SetActive(false);
        }
        else if (currentEvent == Events.Event2)
        {
            newsImage[0].SetActive(false);
            newsImage[1].SetActive(false);
            newsImage[2].SetActive(true);
        }
    }
}
enum Events { Event0, Event1, Event2};
