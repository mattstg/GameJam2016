using UnityEngine;
using System.Collections;

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

   public void CreateEvent(Events.Event eventToCreate, float[] attributePower)
   {
       //

   }

}
