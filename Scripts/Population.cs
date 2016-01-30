using UnityEngine;
using System.Collections;

public class Population : MonoBehaviour {
	public VillageCenter center;

	public int currentPopulation;
	public int mostRecentDesiredFoodConsumption;
	public int foodWantedAfterEating;
	// Use this for initialization
	void Start () {
		currentPopulation = Globals.startPopulation;
	}
	
	public void Cycle () {
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
			currentPopulation -= Mathf.FloorToInt(foodStillWanted * Globals.foodConsumptionPerPerson * Globals.percentOfStarvingWhoDie);
			foodWantedAfterEating = foodStillWanted;
		}
	}
}
