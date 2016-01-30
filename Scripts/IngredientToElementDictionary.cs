using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IngredientToElementDictionary  {

	 #region singleton
    private static IngredientToElementDictionary instance;

    private IngredientToElementDictionary() { RandomizeDictionary(); }

    public static IngredientToElementDictionary Instance
   {
      get 
      {
         if (instance == null)
         {
             instance = new IngredientToElementDictionary();
         }
         return instance;
      }
   }
    #endregion

    Dictionary<Globals.product, List<Element>> IngToElemDict = new Dictionary<Globals.product, List<Element>>();

    public void RandomizeDictionary()
    {
        foreach (Globals.product suit in System.Enum.GetValues(typeof(Globals.product)))
        {
            
        }
        IngToElemDict.Add(Globals.product.Bean,new List<Element>(){new Element(0,0,Events.Event.Blessing)});
    }

    public List<Element> ElementsFromIngredient(Globals.product ingredient)
    {
        return IngToElemDict[ingredient];
    }

    private List<Element> CreateElementList()
    {
        return null;
    }

    private Element CreateRandomElement()
    {
        return new Element(Random.Range(0, Globals.MaxElementPower), Random.Range(0, 3), (Events.Event)Random.Range(0, 3));
    }
}
