using UnityEngine;
using System.Collections;

public class Plague : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D coli)
    {
        Debug.Log("Someone got touched by plague!");
        if (coli.CompareTag("Villager"))
            coli.GetComponent<Villager>().TakePlagueDamage();

    }

    public void OnTriggerExit2D(Collider2D coli)
    {

    }
	
}
