using UnityEngine;
using System.Collections;
using System.Linq;

public class Cauldron : MonoBehaviour {

    float[] attributePower = new float[] { 0, 0, 0 };
    float[] eventCount = new float[] { 0, 0, 0 }; //highest event count will summon that event

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
        int maxIndex = eventCount.ToList().IndexOf(eventCount.Max());                                          //NEED TO TEST VALUES THAT MATCH
        EventFactory.Instance.CreateEvent((Events.Event)maxIndex,attributePower);

        attributePower = new float[] { 0, 0, 0 };
        eventCount = new float[] { 0, 0, 0 };
    }

    
}
