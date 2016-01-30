using UnityEngine;
using System.Collections;

public class EventLauncher : MonoBehaviour {

    Events.Event eventType;
    float[] attrPower;

    public void LoadEvent(Events.Event _eventType,float[] _attrPower)
    {
        eventType = _eventType;
        attrPower = _attrPower;
    }

    public void LaunchEvent(Vector2 mousePos)
    {
        EventFactory.Instance.CreateEvent(eventType, attrPower);
        //then position it at the mouse
        Destroy(this.gameObject);

    }
}
