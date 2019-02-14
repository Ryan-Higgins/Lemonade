using UnityEngine;

public class AILemonadeStand : MonoBehaviour
{
    private StandUpgrader thisStand;
    public bool isActive = true;

    // Start is called before the first frame update
    private void Start()
    {
        thisStand = GetComponent<StandUpgrader>();
    }

    private void OnTriggerEnter2D(Collider2D customer)
    {
        if (customer.CompareTag("Customer") && isActive)
        {
            if (customer.gameObject.GetComponent<Person>().beenServed)
            {
                return;
            }
            customer.gameObject.GetComponent<Person>().atStand = true;
            customer.gameObject.GetComponent<Person>().thisMod = thisStand.upgradeMultiplier;

            //customer.transform.gameObject.GetComponent<Person>().serveIcon.gameObject.SetActive(false);
            customer.transform.gameObject.GetComponent<Person>().Served();
            //LemonadeSystem.money += (1 * LemonadeSystem.weatherMultiplier) * customer.transform.gameObject.GetComponent<Person>().thisMod;
            LemonadeSystem.customers += 1;
            //customer.transform.gameObject.GetComponent<Person>().beenServed = true;

        }
    }
    private void OnTriggerExit2D(Collider2D customer)
    {
        if (customer.CompareTag("Customer") && isActive)
        {
            customer.gameObject.GetComponent<Person>().HideIcon();
        }
    }
}
