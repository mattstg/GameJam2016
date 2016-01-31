using UnityEngine;
using System.Collections;

public class Plague : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.CompareTag("Villager"))
            coli.GetComponent<Villager>().TakePlagueDamage();

    }
	
}
