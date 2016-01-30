using UnityEngine;
using System.Collections;

public class Villager : MonoBehaviour {

    float hp; //range from 0 - 1 (is multiplied by Globals.maximumVillagerHealthPoints)
    float happiness; //range from 0 - 1
    float healthiness; //range from 0 - 

    public void Initialize(float _hp, float _happiness, float _healthiness)
    {
        hp = _hp + Random.Range(-Globals.PopulationMutationRate,Globals.PopulationMutationRate);
        happiness = _happiness + Random.Range(-Globals.PopulationMutationRate,Globals.PopulationMutationRate);
        healthiness = _healthiness + Random.Range(-Globals.PopulationMutationRate, Globals.PopulationMutationRate);
        if (hp <= 0)
            hp = .1f;
    }

    public void UpdateCycle()
    {
        UpdateHp();
        UpdateHappiness();
    }

    private void UpdateHappiness()
    {
        float hpBonus = (hp - hp * Globals.contentThreshold) * Globals.contentExcessMultiplier;
        float healthyBonus = (healthiness - healthiness * Globals.contentThreshold) * Globals.contentExcessMultiplier;
        happiness += hpBonus + healthyBonus;
    }

    private void UpdateHp()
    {
        hp += (healthiness - Globals.healthinessContent) * Globals.healthinessExcessMultiplier;
    }

    public void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.CompareTag("Event"))
        {
            Debug.Log("Is dealing with an event");
        }

    }
}
