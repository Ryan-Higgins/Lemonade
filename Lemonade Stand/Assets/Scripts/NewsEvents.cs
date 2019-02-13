using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsEvents : MonoBehaviour
{
    public List<GameObject> newsImage;
    Event currentEvent;
    public GameObject e1;
    public GameObject e2;
    public GameObject e3;

    void Start()
    {
        currentEvent = (Event)Random.Range(0, 2);
        newsImage.Add(e1);
        newsImage.Add(e2);
        newsImage.Add(e3);
    }

    void Update()
    {
        if (currentEvent == Event.Event0)
        {
            newsImage[0].SetActive(true);
            newsImage[1].SetActive(false);
            newsImage[2].SetActive(false);
        }
        else if (currentEvent == Event.Event1)
        {
            newsImage[0].SetActive(false);
            newsImage[1].SetActive(true);
            newsImage[2].SetActive(false);
        }
        else if (currentEvent == Event.Event2)
        {
            newsImage[0].SetActive(false);
            newsImage[1].SetActive(false);
            newsImage[2].SetActive(true);
        }
    }
}
enum Event { Event0, Event1, Event2};
