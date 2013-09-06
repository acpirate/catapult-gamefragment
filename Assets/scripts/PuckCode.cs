using UnityEngine;
using System.Collections;

public class PuckCode : MonoBehaviour {
	
	public float RotationSpeed = 500;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (MainGameCode.gamestate==GAMESTATE.AIM) 
		 transform.Rotate(0, (Input.GetAxis("Mouse X") * RotationSpeed), 0, Space.World);
	}
	
	void OnMouseDown() {
		MainGameCode.AimMode();
	}		
}
