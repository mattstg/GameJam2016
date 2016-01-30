using UnityEngine;
using System.Collections;

public class MainRitualScript : MonoBehaviour {
    public Transform circleCenter;
	// Use this for initialization, 

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
}
