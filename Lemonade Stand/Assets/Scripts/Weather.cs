using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weather : MonoBehaviour
{

    public List<GameObject> weatherImage;
    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    public GameObject w4;
    public GameObject w5;
    [HideInInspector] public static WeatherType weatherType;
    [SerializeField] private Delay delayTime;
    public Events events;
    [Serializable]
    private struct Delay
    {
        public float min;
        public float max;
    }
    // Start is called before the first frame update
    void Start()
    {
        //today = (Today)Random.Range(0, 5);
        StartCoroutine(ChangeWeather());
        print(weatherType);
        weatherImage = new List<GameObject>();
        weatherImage.Add(w1);
        weatherImage.Add(w2);
        weatherImage.Add(w3);
        weatherImage.Add(w4);
        weatherImage.Add(w5);
    }

    IEnumerator ChangeWeather()
    {
        while (true)
        {
            weatherType = (WeatherType)UnityEngine.Random.Range(0, 5);
            events.RandomEvent();
            print(weatherType);
            yield return new WaitForSeconds(UnityEngine.Random.Range(delayTime.min, delayTime.max));
        }
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            weatherType = (WeatherType)UnityEngine.Random.Range(0, 5);
            print(weatherType);
        }
        
        if (weatherType == WeatherType.Rain)
        {
            weatherImage[0].SetActive(true);
            weatherImage[1].SetActive(false);
            weatherImage[2].SetActive(false);
            weatherImage[3].SetActive(false);
            weatherImage[4].SetActive(false);
            LemonadeSystem.weatherMultiplier = 0.5f;
        }
        else if (weatherType == WeatherType.Cold)
        {
            weatherImage[0].SetActive(false);
            weatherImage[1].SetActive(true);
            weatherImage[2].SetActive(false);
            weatherImage[3].SetActive(false);
            weatherImage[4].SetActive(false);
            LemonadeSystem.weatherMultiplier = 0.75f;
        }
        else if (weatherType == WeatherType.Clear)
        {
            weatherImage[0].SetActive(false);
            weatherImage[1].SetActive(false);
            weatherImage[2].SetActive(true);
            weatherImage[3].SetActive(false);
            weatherImage[4].SetActive(false);
            LemonadeSystem.weatherMultiplier = 1f;
        }
        else if (weatherType == WeatherType.Warm)
        {
            weatherImage[0].SetActive(false);
            weatherImage[1].SetActive(false);
            weatherImage[2].SetActive(false);
            weatherImage[3].SetActive(true);
            weatherImage[4].SetActive(false);
            LemonadeSystem.weatherMultiplier = 1.25f;
        }
        else if (weatherType == WeatherType.Sunny)
        {
            weatherImage[0].SetActive(false);
            weatherImage[1].SetActive(false);
            weatherImage[2].SetActive(false);
            weatherImage[3].SetActive(false);
            weatherImage[4].SetActive(true);
            LemonadeSystem.weatherMultiplier = 1.5f;
        }


    }
}
public enum WeatherType {Rain, Cold, Clear, Warm, Sunny};