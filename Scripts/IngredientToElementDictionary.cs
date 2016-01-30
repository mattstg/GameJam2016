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
        IngToElemDict.Add(Biome.product.Bean,new List<Element>(){new Element(0,0,Events.Event.Blessing)});
    }

    public List<Element> ElementsFromIngredient(Biome.product ingredient)
    {
        return IngToElemDict[ingredient];
    }
}
