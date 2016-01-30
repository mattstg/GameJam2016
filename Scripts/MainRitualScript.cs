using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainRitualScript : MonoBehaviour {
    public Transform circleCenter;
	// Use this for initialization, 

    public void Start()
    {
        CreateChoirCircles(8);
        CreateItemPiles();
    }

    void CreateChoirCircles(float pop)
    {
        for (int i = 0; i < Globals.PeoplePerCircleLevel.Length; ++i)
        {
            if (pop >= Globals.PeoplePerCircleLevel[i])
            {
                pop -= Globals.PeoplePerCircleLevel[i];
                CreateCircle(i);
            }
            else
            {
                break;
            }
        }
    }

    void CreateCircle(int circleLevel)
    {
        GameObject circle = Instantiate(Resources.Load("PrayerCircle"), circleCenter.position, Quaternion.identity) as GameObject;
        circle.GetComponent<PrayerCircle>().Initialize(circleLevel);
    }

    void CreateItemPiles()
    {
        //Due to the nature of trying to find a place continously using a loop, need to try to catch worse case, or over clog by adding more items
        //Acceptable range placement will grow if placement errors continously occur, as well in worse case, stacking will simply be allowed.
        int errorCatcher = 0;
        int totalErrorsCaught = 0;
        float range = Globals.ItemPlacementRange;
        bool success = false;
        foreach (KeyValuePair<Globals.product, int> kv in WitchHut.Instance.GetWitchesCoffer())
        {
            if (kv.Value > 0)
            {
                while (!success)
                {
                    Debug.Log("1");
                    float xSpot = Random.RandomRange(-range, range);
                    float ySpot = Random.RandomRange(-range, range);
                    RaycastHit2D[] allHit = Physics2D.RaycastAll(new Vector2(xSpot,ySpot), -Vector2.up);
                    if (allHit.Length == 0)
                    {
                        Debug.Log("2");
                        success = true;
                        CreateItemPile(new Vector2(xSpot,ySpot),kv.Key, kv.Value);
                    }
                    else
                    {
                        Debug.Log("3: " + allHit.Length);
                        errorCatcher++;
                        if (errorCatcher > 10)
                        {
                            Debug.Log("Error catcher forced to grow");
                            errorCatcher = 0;
                            range += Globals.ItemPlacementRangeGrowth;
                        }
                        if (totalErrorsCaught > 4)
                        {
                            Debug.Log("Total errors caught exceeded limits, allowing stacking of different items");
                            CreateItemPile(new Vector2(xSpot,ySpot),kv.Key, kv.Value);
                            success = true;
                        }
                    }
                }
                success = false;
            }
            //assuming success, remove from witches inventory, cant do it in loop or will kill the foreach iterator
        }
    }

    //This is not a very optimal way of handling the witchhut inventory...
    void CreateItemPile(Vector2 location,Globals.product itemtype, int amount)
    {
        amount = (amount > 12)?12:amount;
        for (int i = 0; i < amount; ++i)
        {
            Debug.Log("creating a " + itemtype);
            GameObject go = Instantiate(Resources.Load("PhysIngredient"), new Vector2(location.x + Random.Range(-.6f,.3f),location.y + Random.Range(-.3f,.3f)), Quaternion.identity) as GameObject;
            go.GetComponent<PhysicalIngredient>().InitializeIngredient(itemtype);
        }
    }
}

