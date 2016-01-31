using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DreamMainScript : MonoBehaviour {
    public Text dreamText;
    float counter = 9f;
	// Use this for initialization
	void Start () {
        dreamText.text = IngredientToElementDictionary.Instance.ReturnOneHint();
	}

    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("VillageMap");
            GameObject.FindObjectOfType<EventLauncher>().beginUnlock = true;
        }
    }
}
