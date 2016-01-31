using UnityEngine;
using System.Collections;
using System.Linq;

public class EventElements{

	//public float[] elements = new float[4];
	//elements will define the effectiveness against each biome and humans/animals/buildings
	//public string[] elementQualifiers = {"ether", "air", "fire", "water", "light", "dark", "critter/insect", "beast"};
	//each series of two strings indicate the element and its opposite.

	EventComponents linkToCalc;
	float[] absMax = new float[2];
	int[] absMaxIndexes = new int[2];

	public EventElements(float[] input){
		linkToCalc = new EventComponents (input);
		absMaxIndexes = linkToCalc.getIndexOfTwoAbsMax ();
		absMax = linkToCalc.getValueOfMaxes ();
	}
		
	//GetEnergySubType --> first need to get energy Type

	//public float getEnergyPowerFromIndex(int index){
	//
	//}

	public string[] getDescribers(){
		//Globals.energyTypes et = 0;
		string[] tempString = new string[2];
		tempString[0] = retMainDescriptors ((Globals.energyTypes) absMaxIndexes[0], absMax[0]);
		tempString[1] = retSecondaryDescriptors ((Globals.energyTypes) absMaxIndexes[1], absMax[1]);
		return tempString;
	}

	//note as power decreases from index 0 to 3. Need 3 adjectives for each.
	public static string[] etherAdjectives = {"volotile", "strangly powerful", "etherreal"};
	public static string[] airAdjectives = {"gale force", "howling", "windy" };
	public static string[] fireAdjectives = { "infernal", "ardent", "heated" };
	public static string[] waterAdjectives = { "drenching", "moist", "damp" };
	public static string[] lightAdjectives = {"blinding", "holy", "bright"};
	public static string[] darkAdjectives = {"jet black", "unholy" ,"dim"};
	public static string[] critterAdjectives = { "teaming", "crawling", "pesky"};
	public static string[] beastAdjectives = { "rampaging", "stampeding", "beastial" };

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

	public static string[] etherMainDescriber = { "Thick black fog", "Lake of smoke" };
	public static string[] airMainDescriber = { "Hurricane", "Squall" };
	public static string[] fireMainDescriber = { "Fire Storm", "Wild fire"};
	public static string[] waterMainDescriber = { "Torrential downpour", "Thunderstrom" };
	public static string[] lightMainDescriber = { "Devine presence", "Brilliant aura" };
	public static string[] darkMainDescriber = { "Diabolical presence", "Unholy aura" };
	public static string[] critterMainDescriber = { "Plague of Locusts", "Swarm of Rats" };
	public static string[] beastMainDescriber = {"Pack of hungry Wolves", "Roaming herd of Buffalo"};

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



	public string retMainDescriptors(Globals.energySubTypes type, float power){
		int intType = (int)type; 
		power = Mathf.Abs (power);
		if (power > 20) {
			power = 0;
		}else{
			power = 1;
		}
		return mainDescriptors[intType][(int)power];
	}

	public string retMainDescriptors(Globals.energyTypes eng, float power){
		return retMainDescriptors(Globals.GetEnergySubType(eng,power),power);
	}

	public string retSecondaryDescriptors(Globals.energySubTypes type, float power){
		int intType = (int)type; 
		power = Mathf.Abs (power);
		if (power > 20) {
			power = 0;
		}else if(power > 10){
			power = 1;
		}else{
			power = 2;
		}
		return secondaryAdjectives[intType][(int)power];
	}

	public string retSecondaryDescriptors(Globals.energyTypes eng, float power){
		return retSecondaryDescriptors (Globals.GetEnergySubType (eng, power),power);
	}


	//(1) when player summon a storm(thing) have it described
	//(2) have npc describe something to player in witch hut scene
	//(3) 

	//public EventComponents workingEvent = new EventComponents ();
}
