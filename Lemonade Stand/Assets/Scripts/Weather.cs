using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    
    public GameObject[] WeatherImage;
    private Today today;
    // Start is called before the first frame update
    void Start()
    {
        today = (Today)Random.Range(0, 4);
    }

    void Update()
    {
        

        if(today == Today.Rain)
        {
            WeatherImage[0].SetActive(true);
        }
        else if (today == Today.Cold)
        {
            WeatherImage[1].SetActive(true);
        }
        else if (today == Today.Clear)
        {
            WeatherImage[2].SetActive(true);
        }
        else if (today == Today.Warm)
        {
            WeatherImage[3].SetActive(true);
        }
        else if (today == Today.Sunny)
        {
            WeatherImage[4].SetActive(true);
        }
    }
}
enum Today {Rain, Cold, Clear, Warm, Sunny};