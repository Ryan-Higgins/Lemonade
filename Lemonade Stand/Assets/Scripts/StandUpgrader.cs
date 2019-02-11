using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpgrader : MonoBehaviour
{
    public static int upgradeMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(upgradeMultiplier);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButton(0))
        {
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.CompareTag("Stand"))
                {
                    if (LemonadeSystem.money >= 10 * upgradeMultiplier)
                    {
                        upgradeMultiplier += 1;
                        LemonadeSystem.money -= 10 * upgradeMultiplier;
                    }
                }
            }
        }
    }
}
