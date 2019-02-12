using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpgrader : MonoBehaviour
{
    public int upgradeMultiplier = 1;
    int cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cost = 10 * upgradeMultiplier;
        //print(upgradeMultiplier);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.CompareTag("Stand"))
                {
                    if (LemonadeSystem.money >= cost)
                    {
                        upgradeMultiplier += 1;
                        LemonadeSystem.money -= cost;
                    }
                }
            }
        }
    }
}
