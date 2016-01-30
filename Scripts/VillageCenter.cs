using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class VillageCenter : MonoBehaviour {
	//LINKS TO OTHER SCRIPTS
	public Biome[] biomes;
	public WitchHut witchLink;
	public Population population;

	//WORKING VARIABLES & INFORMATIVE VARIABLES
	public int populationLossThisCycle = 0;
	public int populationLossLastCycle = 0;
	public int houses;

	//RESOURCE STORAGE SYSTEM
	public Dictionary<Globals.product,int> resourceStorage;
	public void startStorage(){
		//should initialize the start state of the Resource Storage System
		resourceStorage.Add(Globals.product.Fish, 10);
		resourceStorage.Add(Globals.product.Carrot, 10);
		resourceStorage.Add (Globals.product.Wood, 50);
	}

	// Use this for initialization
	void Start () {
		//need to initialize the starting resources
		startStorage();
		//initialize population object
		population = new Population();
		//need to initialize population & houses
		houses = Globals.startHouses;
		//need to fill biome array
		biomes = new Biome[Globals.numberOfBiomes];
		for (int counter = 0; counter < biomes.Length; counter++) {
			biomes [counter] = new Biome();
			biomes [counter].biomeType = (Globals.biome)counter;
			biomes [counter].center = this;
		}
		witchLink = WitchHut.Instance;
		witchLink.linkToVillageCenter = this;
	}

	void Cycle(){
		//keep track of population loss for last turn, and reset population loss this cycle
		populationLossLastCycle = populationLossThisCycle;
		populationLossThisCycle = 0;
		//will proceed with next game cycle
		//calculating yeild for each biome in biomes[]
		foreach (Biome biome in biomes){
			biome.Cycle(); //this calculates the produce and adds it to village store
		}
		//calculate population consumption, and update working population variable in VillageCenter
		population.Cycle();
		//now we need to send the surplus to the witch's coffer
		giveResourcesToWitch();
	}

	public void addResourceToStorage(Globals.product resource, int amount){
		//check first if it is in the dictionary
			//if not, then add with amount = 0 then proceed to avoid error
		if (!resourceStorage.ContainsKey (resource)) {
			//then we need to initialize it first with amount we want to add!
			resourceStorage.Add (resource, amount);
		} else {
			//else, it exists in storage and we can add resource to resourceStorage, adding amount to add with current amount in storage
			resourceStorage[resource] = amount + resourceStorage[resource];
		}
	}

	public bool subtractResourceFromStorage(Globals.product resource, int amount){
		//check first if resource has amount in storage
		if (resourceStorage.ContainsKey (resource) && resourceStorage [resource] > amount) {
			//then we have enough to take the amount we want of said resource
			resourceStorage[resource] = resourceStorage[resource] - amount;
			return true;
		} else {
			//we either dont have enough of resource, or resource isn't contained (meaning we have 0 of said resource)...
			Debug.Log("Error: attempting to take resources from VillageCenter, when none of said resource is stored");
			return false;
		}
	}

	public void giveResourcesToWitch(){
		//for each loop which goes through each resources in storage and allocates a certain percent to the witch
		foreach(KeyValuePair<Globals.product, int> resourcesStored in resourceStorage){
			//global variable percentGivenToWitch is used to calculate amount given
			int amountToGive = Mathf.FloorToInt(resourcesStored.Value * Globals.percentGivenToWitch);
			//need to subtract amoulnt given from resourceStorage
			if(subtractResourceFromStorage(resourcesStored.Key, amountToGive)){
				//need to actually give amounts to witch
				witchLink.addToWitchsCoffer(resourcesStored.Key, amountToGive);
			}else{
				//we dont have enough to give, therefore do not take from storage or give to witch
				Debug.Log("Error: attempting to give resources from VillageCenter to WitchCoffer, when none of said resource is stored in VillageCenter.");
			}
		}
	}

	public int amountOfAvailableFood(){
		int totalFoodCount = 0;
		foreach (KeyValuePair<Globals.product, int> resource in resourceStorage) {
			//if the resource type is a type which appears in array foodTypeProduce, then it is a food and we will add the quantity of food to totalFoodCount
			if (Globals.foodTypeProduce.Contains((int) resource.Key)) {
				totalFoodCount += resource.Value;
			}
		}
		return totalFoodCount;
	}

	public void killPopulation(int amountToKill){
		//Transfer this into Listener Object??
		population.currentPopulation -= amountToKill;
		populationLossThisCycle += amountToKill;
	}
}
