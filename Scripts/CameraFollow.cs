using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform linkToWitch;
	public Transform linkToCamera;
	private float posx;
	private float posy;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//set camera x, y to that of witch
		//linkToCamera.position.x = posx;
		//linkToWitch.position.x = posx;
		//linkToCamera.position.y = posy;
		//linkToWitch.position.y = posy;
	}
}
