using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LemonadeSystem : MonoBehaviour
{
    public static int customers = 0;
    public static float money = 0;
    public static bool atRightEvent = false;
    public static float eventMultiplier = 2f;
    public static float weatherMultiplier = 0;
    public Text moneyUI;
    public static bool priceUpgrade;
    public static bool autoUpgrade;
    public static bool buyStand;
    public GameObject upgradePanel;
    public Text upgradePrice;
    public Text purchasePrice;
    public Text autoPrice;

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

    public void PriceUpgrade()
    {
        priceUpgrade = true;
        print(priceUpgrade);
        Time.timeScale = 1;
    }

    public void AutoUpgrade()
    {
        autoUpgrade = true;
        print(autoUpgrade);
        Time.timeScale = 1;
    }

    public void BuyStand()
    {
        buyStand = true;
        Time.timeScale = 1;
    }
    public void ClosePopup()
    {
        Time.timeScale = 1;
        upgradePanel.SetActive(false);
    }

    public void OpenPopup()
    {
        upgradePrice.text = "€" + StandUpgrader.cost.ToString();
        purchasePrice.text = "€" + StandPlace.standCost.ToString();
        autoPrice.text = "€" + StandUpgrader.autoCost.ToString();
        Time.timeScale = 0;
        upgradePanel.SetActive(true);
    }
}
