using UnityEngine;
using System.Collections;
using System.Linq;

public class EventElements{

	//public float[] elements = new float[4];
	//elements will define the effectiveness against each biome and humans/animals/buildings
	//public string[] elementQualifiers = {"ether", "air", "fire", "water", "light", "dark", "critter/insect", "beast"};
	//each series of two strings indicate the element and its opposite.

	EventComponents linkToCalc;
	int[] absMax = new int[2];
	int[] absMaxIndexes = new int[2];
	public EventElements(float[] input){
		linkToCalc = new EventComponents (input);
		absMaxIndexes = linkToCalc.getIndexOfTwoAbsMax ();
		absMax = linkToCalc.getIndexOfTwoAbsMax ();
	}

	public string[] getDescribers(){
		string[] tempString = mainDescriptors ();
		tempString += secondaryAdjectives ();
		return tempString;
	}

	//note as power decreases from index 0 to 3. Need 3 adjectives for each.
	public string[] etherAdjectives = {"volotile", "strangly powerful", "etherreal"};
	public string[] airAdjectives = {"gale force", "howling", "windy" };
	public string[] fireAdjectives = { "infernal", "ardent", "heated" };
	public string[] waterAdjectives = { "drenching", "moist", "damp" };
	public string[] lightAdjectives = {"blinding", "holy", "bright"};
	public string[] darkAdjectives = {"jet black", "unholy" ,"dim"};
	public string[] critterAdjectives = { "teaming", "crawling", "pesky"};
	public string[] beastAdjectives = { "rampaging", "stampeding", "beastial" };

	public string[][] secondaryAdjectives = {
		etherAdjectives,
		airAdjectives,
		fireAdjectives,
		waterAdjectives,
		lightAdjectives,
		darkAdjectives,
		critterAdjectives,
		beastAdjectives
	};

	public string[] etherMainDescriber = { "Thick black fog", "Lake of smoke" };
	public string[] airMainDescriber = { "Hurricane", "Squall" };
	public string[] fireMainDescriber = { "Fire Storm", "Wild fire"};
	public string[] waterMainDescriber = { "Torrential downpour", "Thunderstrom" };
	public string[] lightMainDescriber = { "Devine presence", "Brilliant aura" };
	public string[] darkMainDescriber = { "Diabolical presence", "Unholy aura" };
	public string[] critterMainDescriber = { "Plague of Locusts", "Swarm of Rats" };
	public string[] beastMainDescriber = {"Pack of hungry Wolves", "Roaming herd of Buffalo"};

	public string[][] mainDescriptors = {
		etherMainDescriber,
		airMainDescriber,
		fireMainDescriber,
		waterMainDescriber,
		lightMainDescriber,
		darkMainDescriber,
		critterMainDescriber,
		beastMainDescriber
	};

	public string[] retMainDescriptors(Globals.energySubTypes type, float power){
		int intType = (int)type; 
		power = Mathf.Abs (power);
		if (power > 20) {
			power = 0;
		}else{
			power = 1;
		}
		return mainDescriptors[intType][power];
	}

	public string[] retSecondaryDescriptors(Globals.energySubTypes type, float power){
		int intType = (int)type; 
		power = Mathf.Abs (power);
		if (power > 20) {
			power = 0;
		}else if(power > 10){
			power = 1;
		}else{
			power = 2;
		}
		return secondaryAdjectives[intType][power];
	}


	//(1) when player summon a storm(thing) have it described
	//(2) have npc describe something to player in witch hut scene
	//(3) 

	//public EventComponents workingEvent = new EventComponents ();
}
