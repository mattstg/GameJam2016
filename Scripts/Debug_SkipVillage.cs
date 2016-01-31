using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Debug_SkipVillage : MonoBehaviour {

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (SceneManager.GetActiveScene().name == "VillageMap")
                GameObject.FindObjectOfType<VillageCenter>().worldTime = Globals.lengthOfScenario - 1;
            else if (SceneManager.GetActiveScene().name == "RitualScene")
            {
                Element e = new Element(5, Globals.energyTypes.dark_light);
                new Element(-5, Globals.energyTypes.dark_light);
                GameObject.FindObjectOfType<Cauldron>().DEBUG_AddIngredient(e);
            }
        }
    }
}
