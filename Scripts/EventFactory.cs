using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventFactory : MonoBehaviour
{
    #region singleton
    private static EventFactory instance;

   private EventFactory() { }

   public static EventFactory Instance
   {
      get 
      {
         if (instance == null)
         {
             instance = new EventFactory();
         }
         return instance;
      }
   }
    #endregion


   public void CreateEvent(Vector2 mousePos,Dictionary<Globals.energyTypes, float> _temp)
   {
       Dictionary<Globals.energyTypes, float>  energyStored = new Dictionary<Globals.energyTypes, float>();
       foreach (KeyValuePair<Globals.energyTypes, float> kv in _temp)
       {
           energyStored.Add(kv.Key, kv.Value);
       }
       Dictionary<Globals.energySubTypes, float> subtypeEnergy = SeperateIntoSubtypes(energyStored);
       
       //Now make event!
       EventBrain evBrain = (Instantiate(Resources.Load("EventPrefab"), mousePos, Quaternion.identity) as GameObject).GetComponent<EventBrain>();
       evBrain.Initialize(subtypeEnergy);

   }

   private Dictionary<Globals.energySubTypes, float> SeperateIntoSubtypes(Dictionary<Globals.energyTypes, float> energyDict)
   {
       Dictionary<Globals.energySubTypes, float> toReturn = new Dictionary<Globals.energySubTypes,float>();
       List<KeyValuePair<Globals.energySubTypes, float>> result;
       foreach(KeyValuePair<Globals.energyTypes,float> kv in energyDict)
       {
           result = Globals.SplitIntoEnergySubTypes(kv);
           toReturn.Add(result[0].Key,Mathf.Abs(result[0].Value));
           toReturn.Add(result[1].Key,Mathf.Abs(result[1].Value));
       }
       return toReturn;
   }

}
