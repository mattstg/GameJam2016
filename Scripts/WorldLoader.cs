using UnityEngine;
using System.Collections;

public class WorldLoader : MonoBehaviour {


    public void Start()
    {
        LoadAll();
    }

    private void LoadAll()
    {
        LoadAllHouses();
        LoadAllPeople();
        LoadAllBiomes();

    }

    private void LoadAllHouses()
    {

    }

    private void LoadAllPeople()
    {
        //Population pop = GameObject.FindObjectOfType<VillageCenter>().population; //could be a const so not allowed to change it, but 48hr
        Population pop = DEBUG_CreatePopulation();

        float errorCounter = 0;
        float totalError = 0;
        bool recklessPlacement = false;
        
        for (int i = 0; i < pop.currentPopulation; ++i)
        {
            Vector2 creationSpot = new Vector2(Random.Range(-Globals.mapRadiusX, Globals.mapRadiusX), Random.Range(-Globals.mapRadiusY, Globals.mapRadiusY));
            RaycastHit2D[] allHit = Physics2D.RaycastAll(creationSpot, -Vector2.up,0);
            if (allHit.Length == 0 || recklessPlacement)
            {
                GameObject go = Instantiate(Resources.Load("Villager"), creationSpot, Quaternion.identity) as GameObject;
                go.GetComponent<Villager>().Initialize(pop.averagePercentLifePoints, pop.averageHappiness, pop.averageHealthiness);
            } else {
                errorCounter++;
                totalError++;
                if (errorCounter > 10) //too much wait, that vilagers toast, next one
                {
                    errorCounter = 0;
                    ++i;
                }
                if (totalError > 40)  //too much thrashing, just place them ontop other objects and hope unity forces them out
                {
                    recklessPlacement = true;
                }                
            }            
        }        
    }

    private void LoadAllBiomes()
    {

    }

    private void CreateHuman()
    {

    }

    private Population DEBUG_CreatePopulation()
    {
        Population pop = new Population();
        pop.averageHappiness = .8f;
        pop.averageHealthiness = .8f;
        pop.averagePercentLifePoints = .8f;
        return pop;

    }
}
