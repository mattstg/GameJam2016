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
				Debug.Log ("MAKING VILLAIN.");
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
	public bool willSpawnEventToday;

	public Villain(){
		willSpawnEventToday = false;
		day = 0;
		power = Globals.basePower;
	}

	public void incrementDay(){
		day++;
		Debug.Log ("Day: " + day + ".");
		power += Globals.powerIncremenetPerDay;
		if (day % Globals.daysBetweenEventSpawn == 0) {
			Debug.Log ("Event tomorrow.");
			createEventBluePrint ();
			willSpawnEventToday = true;
			GameObject.FindObjectOfType<VillageCenter> ().TheListener.RecordString(eventDescription);
		} else {
			Debug.Log ("No Event tomorrow.");
			willSpawnEventToday = false;
			eventDescription = "";
		}
	}

	public string createEventBluePrint(){
        //return EventFactory.Instance.CreateEventFromFloat(bluePrintForEvent);
		for (int c = 0; c < 4; c++) {
			float tempFloat = Random.Range (-power, power);
			tempFloat = (tempFloat < 4)? 4 : tempFloat;
			bluePrintForEvent [c] = tempFloat;
		}
		EventDescriber eventManipulator = new EventDescriber (bluePrintForEvent);
		eventDescription = eventManipulator.OutputStringRepresentingEvent();
		Debug.Log ("New Event  Blue Print Description: " + eventDescription);
		return eventDescription;
	}

	public string createEventFromBluePrint(){
		//needs to call eventFactory and pass them a value
		return EventFactory.Instance.CreateEventFromFloat(bluePrintForEvent);
	}
}
