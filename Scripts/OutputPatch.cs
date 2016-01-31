using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutputPatch : MonoBehaviour {

    public Text textLink;

    public void WriteSpell(string s)
    {
        textLink.text = s;
    }
}
