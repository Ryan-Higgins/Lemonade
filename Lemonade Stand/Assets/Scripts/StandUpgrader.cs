using UnityEngine;
using UnityEngine.UI;

public class PriceHolder
{
    public static int priceCost = 10;
    public static int timesUpgraded = 1;
    public static int autoCost = 20;
    public static int GetCost()
    {
        return priceCost * timesUpgraded;
    }

}
public class StandUpgrader : MonoBehaviour
{
    public int upgradeMultiplier = 1;
    //public static int cost = 10;
    //public static int timesUpgraded  = 1;
    public static int autoCost = 20;
    public Text shownMoney;

    public bool automatic = false;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        //print(automatic);
        shownMoney.text = "$" + ((1 * LemonadeSystem.weatherMultiplier) * upgradeMultiplier).ToString();
        //cost *= timesUpgraded;
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
                        if (LemonadeSystem.HasMoney(PriceHolder.GetCost()))
                        {
                            LemonadeSystem.priceUpgrade = false;
                            hit.transform.gameObject.GetComponent<StandUpgrader>().upgradeMultiplier += 1;
                            
                            //LemonadeSystem.money -= PriceHolder.priceCost;

                            PriceHolder.timesUpgraded++;
                            PriceHolder.priceCost = PriceHolder.GetCost();
                        }
                    }

                    if (LemonadeSystem.autoUpgrade)
                    {
                        if (LemonadeSystem.money >= autoCost)
                        {
                            hit.transform.gameObject.GetComponent<StandUpgrader>().automatic = true;
                            LemonadeSystem.autoUpgrade = false;
                            LemonadeSystem.money -= autoCost;
                            autoCost *= (int)1.5f;
                        }
                    }
                }
            }
        }

    }
}
