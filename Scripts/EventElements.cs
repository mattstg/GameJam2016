using UnityEngine;
using System.Collections;
using System.Linq;

public class EventElements{

	//public float[] elements = new float[4];
	//elements will define the effectiveness against each biome and humans/animals/buildings
	//public string[] elementQualifiers = {"ether", "air", "fire", "water", "light", "dark", "critter/insect", "beast"};
	//each series of two strings indicate the element and its opposite.


	//note as power decreases from index 0 to 3. Need 3 adjectives for each.
	public string[] etherAdjectives = {"volotile", "strangly powerful", "etherreal"};
	public string[] airAdjectives = {"gale force", "howling", "windy" };
	public string[] fireAdjectives = { "infernal", "ardent", "heated" };
	public string[] waterAdjectives = { "drenching", "moist", "damp" };
	public string[] lightAdjectives = {"blinding", "holy", "bright"};
	public string[] darkAdjectives = {"jet black", "unholy" ,"dim"};
	public string[] critterAdjectives = { "teaming", "crawling", "pesky"};
	public string[] beastAdjectives = { "rampaging", "stampeding", "beastial" };

	public string[] etherMainDescriber = { "Thick black fog", "Lake of smoke" };
	public string[] airMainDescriber = { "Hurricane", "Squall" };
	public string[] fireMainDescriber = { "Fire Storm", "Wild fire"};
	public string[] waterMainDescriber = { "Torrential downpour", "Thunderstrom" };
	public string[] lightMainDescriber = { "Devine presence", "Brilliant aura" };
	public string[] darkMainDescriber = { "Diabolical presence", "Unholy aura" };
	public string[] critterMainDescriber = { "Plague of Locusts", "Swarm of Rats" };
	public string[] beastMainDescriber = {"Pack of hungry Wolves", "Roaming herd of Buffalo"};

	//public EventComponents workingEvent = new EventComponents ();
}
