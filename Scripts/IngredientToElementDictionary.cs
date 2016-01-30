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

    Dictionary<Biome.product, List<Element>> IngToElemDict = new Dictionary<Biome.product, List<Element>>();

    public void RandomizeDictionary()
    {
        foreach (Biome.product suit in System.Enum.GetValues(typeof(Biome.product)))
        {
            
        }
        IngToElemDict.Add(Biome.product.Bean,new List<Element>(){new Element(0,0,Events.Event.Blessing)});
    }

    public List<Element> ElementsFromIngredient(Biome.product ingredient)
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
