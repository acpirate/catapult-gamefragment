using UnityEngine;
using System.Collections;

public class KingCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if the king gets knocked off pedestal then its gameover
		if (transform.position.y<20) MainGameCode.GameOver();
	
	}
}
