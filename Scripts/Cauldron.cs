using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Cauldron : MonoBehaviour {

    public Dictionary<Globals.product, int> itemsAdded = new Dictionary<Globals.product, int>();

    float[] attributePower = new float[] { 0, 0, 0 };
    float[] eventCount = new float[] { 0, 0, 0 }; //highest event count will summon that event

    //could do it one one burst with items added, but then wouldn't have the proper colors tells.
    public void AddIngredient(Globals.product addedIngredient)
    {
        foreach (Element e in IngredientToElementDictionary.Instance.ElementsFromIngredient(addedIngredient))
        {
            Debug.Log("Element added " + e);
            attributePower[e.attributeNumber] += e.power;
            eventCount[(int)e.activeEvent]++;
        }
    }

    public void CreateEvent()
    {
        int maxIndex = eventCount.ToList().IndexOf(eventCount.Max());                             //NEED TO TEST VALUES THAT MATCH
        EventFactory.Instance.CreateEvent((Events.Event)maxIndex,attributePower);
        WitchHut.Instance.RemoveFromWitchesCoffer(itemsAdded);
        itemsAdded = new Dictionary<Globals.product, int>();
        attributePower = new float[] { 0, 0, 0 };
        eventCount = new float[] { 0, 0, 0 };
    }
    
}
