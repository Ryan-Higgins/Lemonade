using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StandPlace : MonoBehaviour
{
    public static bool startOfDay = true;
    public GameObject stand;
    public Grid myTile;
    public static int standCost = 25;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Events.DisplayingEvent)
        {
            return;
        }
        if (startOfDay || LemonadeSystem.buyStand  && LemonadeSystem.money >= standCost)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = myTile.WorldToCell(worldPoint);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButton(0))
            {
                if (hit.collider != null)
                {
                    Vector3Int cellPosition = myTile.WorldToCell(hit.point);
                    Vector3 spawnPos = myTile.GetCellCenterWorld(cellPosition);
                    GameObject standCopy = Instantiate(stand, spawnPos, gameObject.transform.rotation);
                    standCopy.transform.position = new Vector3(standCopy.transform.position.x, standCopy.transform.position.y, -2);
                    if (startOfDay)
                    {
                        startOfDay = false;
                    }

                    if (LemonadeSystem.buyStand)
                    {
                        LemonadeSystem.money -= standCost;
                        LemonadeSystem.buyStand = false;
                    }
                }
            }
        }
        else
        {
            LemonadeSystem.buyStand = false;
        }
    }
}
