using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    
    public List<GameObject> weatherImage;
    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    public GameObject w4;
    public GameObject w5;
    private Today today;
    // Start is called before the first frame update
    void Start()
    {
        today = (Today)Random.Range(0, 5);
        print(today);
        weatherImage = new List<GameObject>();
        weatherImage.Add(w1);
        weatherImage.Add(w2);
        weatherImage.Add(w3);
        weatherImage.Add(w4);
        weatherImage.Add(w5);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            today = (Today)Random.Range(0, 5);
        }
        if (today == Today.Rain)
        {
            weatherImage[0].SetActive(true);
            weatherImage[1].SetActive(false);
            weatherImage[2].SetActive(false);
            weatherImage[3].SetActive(false);
            weatherImage[4].SetActive(false);
            LemonadeSystem.weatherMultiplier = 0.5f;
        }
        else if (today == Today.Cold)
        {
            weatherImage[0].SetActive(false);
            weatherImage[1].SetActive(true);
            weatherImage[2].SetActive(false);
            weatherImage[3].SetActive(false);
            weatherImage[4].SetActive(false);
            LemonadeSystem.weatherMultiplier = 0.75f;
        }
        else if (today == Today.Clear)
        {
            weatherImage[0].SetActive(false);
            weatherImage[1].SetActive(false);
            weatherImage[2].SetActive(true);
            weatherImage[3].SetActive(false);
            weatherImage[4].SetActive(false);
            LemonadeSystem.weatherMultiplier = 1f;
        }
        else if (today == Today.Warm)
        {
            weatherImage[0].SetActive(false);
            weatherImage[1].SetActive(false);
            weatherImage[2].SetActive(false);
            weatherImage[3].SetActive(true);
            weatherImage[4].SetActive(false);
            LemonadeSystem.weatherMultiplier = 1.25f;
        }
        else if (today == Today.Sunny)
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
enum Today {Rain, Cold, Clear, Warm, Sunny};