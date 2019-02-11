using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LemonadeSystem : MonoBehaviour
{
    public static int customers = 0;
    public static float money = 10;
    public static bool atRightEvent = false;
    public static float eventMultiplier = 2f;
    public static float weatherMultiplier = 0;
    public Text moneyUI;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyUI.text = money.ToString();
        //print(money);
        //print(customers);
    }
}
