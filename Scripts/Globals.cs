using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	public static float biomeProductivityCoefficient = 5f;
	public static float populationYeildBonus = .02f; //productivity boost per population, so at 50 popProdBonus = 1, 100 = 2, 150 = 3 (150 is max)
	public static int maxPopulation = 150;
	public static float percentGivenToWitch = 0.1f; 
	public static int startPopulation = 30; 
	public static float startAverageHappiness = 0.7f; //range from 0 - 1 (0 being very sad, 1 being very happy)
	public static float startAverageHealthiness = 0.7f; //range 0 - 1 (0 being very ill, 1 being very well)
	public static float startAverageLifePoints = 0.9f; //range 0 - 1 (0 being dead, 1 being full Life Points)
	public static int maximumVillagerHealthPoints = 10;
	public static float residentsPerHouse = 5; //can function with fractions
	public static int startHouses = 10; 
	public static int woodPerHouse = 5;
	public static int floatingHouses = 1; //amount of houses population will try to have excess
	public static float foodConsumptionPerPerson = 0.25f; //amount of food consumed per person, rounded down in formula
	public static float percentOfStarvingWhoDie = 0.5f; //percent of starving population who die
	public static float maxPercentPopulationIncrease = 0.2f; //20% increase in population maximum
    public static int MaxElementPower = 5;
    public static int MaxElementsPerIngredient = 3;
    public static int[] PeoplePerCircleLevel = { 6, 12, 16, 18 };
    public static float ItemPlacementRange = 6;
    public static float ItemPlacementRangeGrowth = 1;
	public static int minimumTaxableAmountOfProduce = 6;
    public static float PopulationMutationRate = .2f;
    public static float mapRadiusY = 4;
    public static float mapRadiusX = 7;
    public static float contentThreshold = .8f; //a villager at 80% happy is content
    public static float contentExcessMultiplier = 1f; //per point one, gain point one
    public static float healthinessExcessMultiplier = .5f; //per point over hp, lose
    public static float healthinessContent = 1f; //per point over hp, lose
    public static readonly float lengthOfScenario = 20f;
    private static readonly float villagerUpdateCyclesPerScenario = 5;
    public static float villageUpdateCounterMax =  lengthOfScenario / villagerUpdateCyclesPerScenario;

    

    public enum worshipperStates { Dance, Chant, COUNT };

	public enum product {Mushrooms = 0, Wood = 1, Daisy = 2, Rot = 3, StinkWeed = 4, Frog = 5, Potatoe = 6, Carrot = 7, Bean = 8, Cow = 9, Chicken = 10, Manure = 11,
		Fish = 12, Seaweed = 13, WaterLilly = 14, MountainHerb = 15, Stone = 16, Gold = 17};
	public static int numberOfProduct = 18;
	public static int[] foodTypeProduce = {6,7,8,9,10,12};
	public static int[] herbTypeProduce = {0,2,4,14,15};
	//public static int[] buildingTypeProduce = { 1, 16 }; 

	public enum biome {Forest = 0, Bog = 1,  Farmland = 2, Ranch = 3, Lake = 4, Mountain = 5};
	public static int numberOfBiomes = 6;
	public static product[] retBiomeResources(biome biome, int startPosition){
		product[] toRet = new product[3];
		//Debug.Log ("Biome being initialized: " + biome);
		//Debug.Log ("start position: " + startPosition);
		for (int counter = startPosition; counter < startPosition + 3; counter++) {
			//Debug.Log("counter = " + counter + "|||||| startPosition " + startPosition);
			toRet [counter - startPosition] = (product) counter;
		}
		return toRet;
	}

    public static Vector2 AddVec(Vector3 v1,Vector2 v2)
    {
        return new Vector2(v1.x + v2.x, v1.y + v2.y);
    }
}