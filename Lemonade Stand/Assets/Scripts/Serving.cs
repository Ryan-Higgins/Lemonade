using UnityEngine;

public class Serving : MonoBehaviour
{
    private StandUpgrader thisStand;

    // Start is called before the first frame update
    private void Start()
    {
        thisStand = GetComponent<StandUpgrader>();
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.gameObject.CompareTag("Customer"))
                {
                    if (!hit.transform.gameObject.GetComponent<Person>().beenServed && hit.transform.gameObject.GetComponent<Person>().atStand)
                    {
                        //hit.transform.gameObject.GetComponent<Person>().serveIcon.gameObject.SetActive(false);

                        //hit.transform.gameObject.GetComponent<Person>().ServedColor();

                        //LemonadeSystem.money += (1 * LemonadeSystem.weatherMultiplier) * hit.transform.gameObject.GetComponent<Person>().thisMod;
                        //LemonadeSystem.customers += 1;
                        //hit.transform.gameObject.GetComponent<Person>().beenServed = true;

                        //print(LemonadeSystem.money);

                        Serve(hit.transform.gameObject.GetComponent<Person>());
                    }
                }
            }
        }
    }

    public void Serve(Person p)
    {
        p.Served(true);
        LemonadeSystem.money += (1 * LemonadeSystem.weatherMultiplier) * p.thisMod;
        LemonadeSystem.customers += 1;
    }

    private void OnTriggerEnter2D(Collider2D customer)
    {
        if (customer.CompareTag("Customer"))
        {
            if (customer.gameObject.GetComponent<Person>().beenServed)
            {
                return;
            }
            customer.gameObject.GetComponent<Person>().atStand = true;
            customer.gameObject.GetComponent<Person>().thisMod = thisStand.upgradeMultiplier;
            customer.gameObject.GetComponent<Person>().NotServed();

            if (thisStand.automatic)
            {
                //customer.transform.gameObject.GetComponent<Person>().ServedColor();
                //LemonadeSystem.money += (1 * LemonadeSystem.weatherMultiplier) * customer.transform.gameObject.GetComponent<Person>().thisMod;
                //LemonadeSystem.customers += 1;
                //customer.transform.gameObject.GetComponent<Person>().beenServed = true;
                Serve(customer.gameObject.GetComponent<Person>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D customer)
    {
        if (customer.CompareTag("Customer"))
        {
            customer.gameObject.GetComponent<Person>().HideIcon();
        }
    }
}
