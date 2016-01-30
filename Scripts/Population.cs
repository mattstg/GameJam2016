using UnityEngine;
using System.Collections;

public class Population : MonoBehaviour {
	//LINK TO VILLAGECENTER
	public VillageCenter center;

	//current working population & happiness for village
	public int currentPopulation;
	public float averagePercentLifePoints; //range from 0 - 1 (is multiplied by Globals.maximumVillagerHealthPoints)
	public float averageHappiness; //range from 0 - 1
	public float averageHealthiness; //range from 0 - 1

	//informative variables
	public int mostRecentDesiredFoodConsumption = 0;
	public int netFoodAfterEating = 0; //Can be values in the negatives or positives, indicating deficit or surplus food
	public bool villageIsStarving = false; //boolean used to govern growth of populations; no growth if starving.

	void Start () {
		//when initialized pull starting population from Global Variables
		currentPopulation = Globals.startPopulation;
		averageHappiness = Globals.startAverageHappiness;
		averagePercentLifePoints = Globals.startAverageLifePoints;
		averageHealthiness = Globals.startAverageHealthiness;
	}
	
	public void Cycle () {
		//people consume food, and if they dont eat, some starve.
		populationFoodConsumptionAndStarvation();

		//we need to alter average happiness of population

		//population now needs to be able to grow. Depends upon happiness and healthiness. If they were starving, then don't have births. 
		populationBirthController();

	}

	public void populationBirthController(){
		//surplus food & happiness effect population growth
		if (!villageIsStarving) {
			// if population is not starving, then population can grow
			// currently population can grow by a maximum of 20% each cycle, provided averageHappiness is perfect
			// if averageHappiness is 0.5f, then maxPercentPopulationIncrease is halved. 
			int projectedPopulationGrowth = Mathf.CeilToInt(Globals.maxPercentPopulationIncrease * currentPopulation * averageHappiness);
			currentPopulation += projectedPopulationGrowth;
		} else {
			//village is starving, therefore no one wants to reproduce
			Debug.Log("Population is starving, and dont feel like producing offspring");
		}
	}

	public void populationFoodConsumptionAndStarvation(){
		villageIsStarving = false; //set to false, simply for start. If foodDemand > foodStores, then isStarving = true;
		//population should consume food
		int currentAvailableFood = center.amountOfAvailableFood();
		mostRecentDesiredFoodConsumption = Mathf.FloorToInt(currentPopulation * Globals.foodConsumptionPerPerson);
		if (mostRecentDesiredFoodConsumption < currentAvailableFood) {
			//should have enough food to eat, so lets calculate the food left after we eat it (because we will need it for population growth)
			netFoodAfterEating = currentAvailableFood - mostRecentDesiredFoodConsumption;
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
					//int amountDesiredFood = mostRecentDesiredFoodConsumption - currentAvailableFood; //NOT SURE WHY I HAD THIS
			//therefore we can take safely amountOfAvaialeFood from VillageStorage
			//therefore, take what food is available in storage
			int tempAvailableFood = currentAvailableFood;
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
			int foodShortage = mostRecentDesiredFoodConsumption - currentAvailableFood;
			currentPopulation -= Mathf.FloorToInt(foodShortage * Globals.foodConsumptionPerPerson * Globals.percentOfStarvingWhoDie);
			///#### NOT USING VILLAGECENTER SCRIPT, SO DOSNT USE killPopulation(int amount) function
		}
	}
}
