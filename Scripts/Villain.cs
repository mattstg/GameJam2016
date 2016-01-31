using UnityEngine;
using System.Collections;

public class Villain{
	#region singleton
	private static Villain instance;

	public static Villain Instance
	{
		get 
		{
			if (instance == null)
			{
				//Debug.Log ("MAKING VILLAIN.");
				instance = new Villain();
			}
			return instance;
		}
	}
	#endregion

	/*createEvent(){

	}*/

	float[] bluePrintForEvent = new float[4];
	string eventDescription;
	int day;
	float power;
	public bool willSpawnEventTomorrow;

	public Villain(){
		willSpawnEventTomorrow = false;
		day = 0;
		power = Globals.basePower;
	}

	public void incrementDay(){
		day++;
		//Debug.Log ("Day: " + day + ".");
		power += Globals.powerIncremenetPerDay;
		if ((day % Globals.daysBetweenEventSpawn == 0) && (day != 0)) {
			//Debug.Log ("Event tomorrow.");
			willSpawnEventTomorrow = true;
		} else {
			//Debug.Log ("No Event tomorrow.");
			createEventBluePrint ();
			GameObject.FindObjectOfType<VillageCenter> ().TheListener.RecordString(eventDescription);
			willSpawnEventTomorrow = false;
			eventDescription = "";
		}
	}

	public string createEventBluePrint(){
		//Debug.Log ("Creating new blueprint...");
        //return EventFactory.Instance.CreateEventFromFloat(bluePrintForEvent);
		for (int c = 0; c < 4; c++) {
			float tempFloat = Random.Range (-power, power);
			//tempFloat = (Mathf.Abs(tempFloat) < 4)? (tempFloat/Mathf.Abs(tempFloat)) * 4 : tempFloat;
			bluePrintForEvent [c] = tempFloat;
			//Debug.Log ("Counter: " + c + " is equal to " + tempFloat);
		}
		EventDescriber eventManipulator = new EventDescriber (bluePrintForEvent);
		eventDescription = eventManipulator.OutputStringRepresentingEvent();
		//Debug.Log ("New Event Blue Print Description: " + eventDescription);
		//Debug.Log ("Event BluePrint:" + );
		return eventDescription;
	}

	public string createEventFromBluePrint(){
		//needs to call eventFactory and pass them a value
		return EventFactory.Instance.CreateEventFromFloat(bluePrintForEvent);
	}
}
