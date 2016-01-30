using UnityEngine;
using System.Collections;

public class Element {

    public int power;
    public int attributeNumber; //there are three
    public Events.Event activeEvent;

    public Element(int _power, int _attributeNumber, Events.Event _activeEvent)
    {
        power = _power;
        attributeNumber = _attributeNumber;
        activeEvent = _activeEvent;
    }

   

}
