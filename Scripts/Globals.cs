using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

	public static float biomeProductivityCoefficient = 10f;
	public static float populationProductivityBonus = 1 / 10;
	public static float percentGivenToWitch = 0.1f;
	public static int startPopulation = 20;
	public static int populationCapPerHouse = 5;
	public static int startHouses = 5;
    public static int MaxElementPower = 5;
    public static int MaxElementsPerIngredient = 3;


	public enum product {Elk = 0, Wood = 1, Daisy = 2, Rot = 3, StinkWeed = 4, Frog = 5, Potatoe = 6, Carrot = 7, Bean = 8, Cow = 9, Chicken = 10, Manure = 11,
		Fish = 12, Seaweed = 13, WaterLilly = 14, MountainHerb = 15, Silver = 16, Gold = 17};

	public enum biome {Forest = 0, Bog = 1,  Farmland = 2, Ranch = 3, Lake = 4, Mountain = 5};
	public static int numberOfBiomes = 6;

	public static product[] retBiomeResources(biome biome){
		product[] toRet = new product[3];
		int startPosition = (int)biome * 3;
		for (int counter = startPosition; counter < startPosition + 3; counter++) {
			toRet [counter] = (product) startPosition + counter;
		}
		return toRet;
	}
}