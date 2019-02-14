using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandUpgrader : MonoBehaviour
{
    public int upgradeMultiplier = 1;
    int cost;
    public Text shownMoney;

    public bool automatic = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(automatic);
        shownMoney.text = "$" + ((1 * LemonadeSystem.weatherMultiplier) * upgradeMultiplier).ToString();
        cost = 10 * upgradeMultiplier;
        //print(upgradeMultiplier);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
       
        
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    if (hit.transform.gameObject.CompareTag("Stand"))
                    {
                        if (LemonadeSystem.priceUpgrade)
                        {
                            if (LemonadeSystem.money >= cost)
                            {
                                hit.transform.gameObject.GetComponent<StandUpgrader>().upgradeMultiplier += 1;
                                LemonadeSystem.priceUpgrade = false;
                                LemonadeSystem.money -= cost;
                            }
                        }

                        if (LemonadeSystem.autoUpgrade)
                        {
                            if (LemonadeSystem.money >= 20)
                            {
                                hit.transform.gameObject.GetComponent<StandUpgrader>().automatic = true;
                                LemonadeSystem.autoUpgrade = false;
                                LemonadeSystem.money -= 20;
                            }
                        }
                    }
                }
            }
        
    }
}
