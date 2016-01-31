using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform linkToWitch;


	// Update is called once per frame
	void Update () {
		transform.position = linkToWitch.position + new Vector3 (0, 0, -10);
	}
}
