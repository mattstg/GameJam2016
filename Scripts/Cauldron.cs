﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Cauldron : MonoBehaviour {

    public Dictionary<Globals.product, int> itemsAdded = new Dictionary<Globals.product, int>();
    Dictionary<Globals.energyTypes, float> energyStored = new Dictionary<Globals.energyTypes, float>();

    //could do it one one burst with items added, but then wouldn't have the proper colors tells.
    public void AddIngredient(Globals.product addedIngredient)
    {
        foreach (Element e in IngredientToElementDictionary.Instance.ElementsFromIngredient(addedIngredient))
        {
            //Debug.Log("elem e consists of " + e.energyType + ", " + e.power);
            if (!energyStored.ContainsKey(e.energyType))
                energyStored.Add(e.energyType, e.power);
            else
                energyStored[e.energyType] += e.power;
        }
    }

    public void CreateEventLauncher()
    {
        GameObject launcher = new GameObject();
        EventLauncher el = launcher.AddComponent<EventLauncher>();
        el.LoadEvent(energyStored);
        DontDestroyOnLoad(launcher);
        WitchHut.Instance.RemoveFromWitchesCoffer(itemsAdded);
        itemsAdded = new Dictionary<Globals.product, int>();
    }
}
