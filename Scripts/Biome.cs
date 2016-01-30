using UnityEngine;
using System.Collections;

public class Biome : MonoBehaviour {
	public VillageCenter center;
	public Globals.biome biomeType;

	//has some stuff it produces
	public Globals.product[] resources = new Globals.product[3];

	//A productivity for each of the three resources
	public float[] productivityOfResources = new float[3];
	//between 0 - 1 usually
	//is function of population in town and the effects

	public void Start(){
		resources = Globals.retBiomeResources(biomeType);
	}
	//should initialize the enum for reasources for each biome.

	public void Cycle(){
		produceResources();
	}
	//will produce resource based on productivity of resource and type of resource
	//will send to village center

	public void produceResources(){
		//uses productivity to calulate yeild
		//sends goods to resource storage
		for(int counter = 0; counter < 3; counter++) {
			giveResourceToVillage (resources [counter], grossProduce(productivityOfResources[counter]));
		}
	}
		
	public int grossProduce(float productivity){
		return Mathf.FloorToInt(center.population.currentPopulation * Globals.populationProductivityBonus * productivity * Globals.biomeProductivityCoefficient);
	}
		
	public void giveResourceToVillage(Globals.product resource, int amount){
		center.addResourceToStorage (resource, amount);
	}

	virtual public void isCollidedWith(){ 
		//nothing yet	
	}
	//inputs event type and somehow interprets 
}