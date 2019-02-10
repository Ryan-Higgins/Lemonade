using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    
    public GameObject[] weatherImage;
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
            weatherImage[0].SetActive(true);
            LemonadeSystem.weatherMultiplier = 0.5f;
        }
        else if (today == Today.Cold)
        {
            weatherImage[1].SetActive(true);
            LemonadeSystem.weatherMultiplier = 0.75f;
        }
        else if (today == Today.Clear)
        {
            weatherImage[2].SetActive(true);
            LemonadeSystem.weatherMultiplier = 1f;
        }
        else if (today == Today.Warm)
        {
            weatherImage[3].SetActive(true);
            LemonadeSystem.weatherMultiplier = 1.25f;
        }
        else if (today == Today.Sunny)
        {
            weatherImage[4].SetActive(true);
            LemonadeSystem.weatherMultiplier = 1.5f;
        }
    }
}
enum Today {Rain, Cold, Clear, Warm, Sunny};