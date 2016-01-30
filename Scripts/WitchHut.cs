using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WitchHut : MonoBehaviour {
	public VillageCenter linkToVillageCenter;

	public Dictionary<Globals.product,int> witchsCoffer;
	public void startStorage(){
		//should initialize the start state of the Resource Storage System
		witchsCoffer.Add(Globals.product.Stone, 2);
		witchsCoffer.Add(Globals.product.Seaweed, 3);
		witchsCoffer.Add(Globals.product.Manure, 5);
		witchsCoffer.Add(Globals.product.Gold, 1);
		witchsCoffer.Add(Globals.product.Daisy, 5);
		witchsCoffer.Add(Globals.product.Wood, 5);
	}

	// Use this for initialization
	void Start () {
		startStorage ();
	}

	public void addToWitchsCoffer(Globals.product resource, int amount){
		//will add amount passed into witch's coffer
		if (!witchsCoffer.ContainsKey (resource)) {
			//then we need to initialize it first with amount we want to add!
			witchsCoffer.Add (resource, amount);
		} else {
			//else, it exists in storage and we can add resource to resourceStorage, adding amount to add with current amount in storage
			witchsCoffer[resource] = amount + witchsCoffer[resource];
		}
	}

	public bool removeFromWitchsCoffer(Globals.product resource, int amount){
		//check first if resource has amount in storage
		if (witchsCoffer.ContainsKey (resource) && witchsCoffer [resource] > amount) {
			//then we have enough to take the amount we want of said resource
			witchsCoffer[resource] = witchsCoffer[resource] - amount;
			if (witchsCoffer [resource] == 0)
				witchsCoffer.Remove (resource);
			return true;
		} else {
			//we either dont have enough of resource, or resource isn't contained (meaning we have 0 of said resource)...
			Debug.Log("Error: attempting to take resources from Witch's Coffer, when none of said resource is stored");
			return false;
		}
	}

	public void giveResourceBackToVillageCenter(Globals.product resource, int amount){
		//checking if we have enough of said resource to give
		if (removeFromWitchsCoffer (resource, amount)) {
			linkToVillageCenter.addResourceToStorage (resource, amount);
		} else {
			Debug.Log ("Warning: trying to remove more resources than are stored in Witch's Coffer, cannot give back to VillageCenter");
		}
	}
}
