using UnityEngine;
using System.Collections;

public class Population : MonoBehaviour {
	//LINK TO VILLAGECENTER
	public VillageCenter center;

	//current working population & happiness for village
	public int currentPopulation;
	public float averageHealth;
	public float averageHappiness;
	public float averageIllness; 

	//informative variables
	public int mostRecentDesiredFoodConsumption = 0;
	public int foodStillWantedAfterEating = 0;
	public bool villageIsStarving;

	void Start () {
		//when initialized pull starting population from Global Variables
		currentPopulation = Globals.startPopulation;
		averageHappiness = Globals.startHappiness;
	}
	
	public void Cycle () {
		//people consume food, and if they dont eat, some starve.
		populationFoodConsumptionAndStarvation();

		//population now needs to be able to grow. If they were starving, then don't have births. 

	}

	public void populationFoodConsumptionAndStarvation(){
		villageIsStarving = false; //set to false, simply for start. If foodDemand > foodStores, then isStarving = true;
		//population should consume food
		mostRecentDesiredFoodConsumption = Mathf.FloorToInt(currentPopulation * Globals.foodConsumptionPerPerson);
		if (mostRecentDesiredFoodConsumption < center.amountOfAvailableFood ()) {
			//should have enough food to eat
			//will choose food at random until no more food is required.
			int workingFoodDesire = mostRecentDesiredFoodConsumption;
			//while workingFoodDesire is still above 0, ie. population is still hungry.
			while (workingFoodDesire > 0) {
				//at VillageCenter, subtract resource from storage, choosing randomly from all known foodTypes, one at a time.
				if (center.subtractResourceFromStorage ((Globals.product) Globals.foodTypeProduce[Random.Range (0, Globals.foodTypeProduce.Length)], 1)) {
					workingFoodDesire--;
				} else {
					//we were not able to subtract resource from storage due to quantity
					Debug.Log("Tried to take food type resource from storage, but we dont have that resource.");
				}
			}
		} else {
			//in event of food demand being less than actual food
			//population should starve, decrease happiness
			villageIsStarving = true;

			//so, mostRecentDesiredFoodConsumption > amountOfAvailableFood = foodStillWanted
			int tempAvailableFood = center.amountOfAvailableFood();
			int foodStillWanted = mostRecentDesiredFoodConsumption - tempAvailableFood;
			//therefore we can take safely amountOfAvaialeFood from VillageStorage
			//therefore, take what food is available in storage
			while (tempAvailableFood > 0) {
				//at VillageCenter, subtract resource from storage, choosing randomly from all known foodTypes, one at a time.
				if (center.subtractResourceFromStorage ((Globals.product) Globals.foodTypeProduce [Random.Range (0, Globals.foodTypeProduce.Length)], 1)) {
					tempAvailableFood--;
				} else {
					//we were not able to subtract resource from storage due to quantity
					Debug.Log("Tried to take food type resource from storage, but we dont have that resource.");
				}
			}
			//so, some percent of population went without food, and so some should die	
			//currentPopulation is culled by peopleWhoWentWithoutFood * %whoDieWhenStarving
			foodStillWantedAfterEating = foodStillWanted;
			currentPopulation -= Mathf.FloorToInt(foodStillWanted * Globals.foodConsumptionPerPerson * Globals.percentOfStarvingWhoDie);
		}
	}
}
