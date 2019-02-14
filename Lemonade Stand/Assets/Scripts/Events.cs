using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    [SerializeField] private Event[] events;
    [SerializeField] private UIElements uiElements;
    [HideInInspector] public static EventTypes type;
    public static bool DisplayingEvent;
    [Serializable]
    private struct Event
    {
        public EventTypes eventType;
        public string title;
        [TextArea] public string text;
    }
    [Serializable]
    private struct UIElements
    {
        public GameObject overlay;
        public Text title;
        public Text text;
    }

    void DisplayEvent(Event e)
    {
        Events.DisplayingEvent = true;
        uiElements.overlay.SetActive(true);
        uiElements.title.text = e.title;
        uiElements.text.text = e.text;
        type = e.eventType;
        Time.timeScale = 0;
    }
    public void HideEvent()
    {
        Events.DisplayingEvent = false;
        uiElements.overlay.SetActive(false);
        Time.timeScale = 1;
    }
    public void RandomEvent()
    {
        int index = (int) UnityEngine.Random.Range(0, events.Length - 1);
        DisplayEvent(events[index]);
        
    }
}
public enum EventTypes { AttackOfTheLimes, LemonThieves, WarOfTheWorlds, Lemonnado, }
