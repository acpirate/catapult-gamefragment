using UnityEngine;
using System.Collections;

public enum GAMESTATE { TITLE, PLAY, GAMEOVER, SETTINGS };

public class MainGameCode : MonoBehaviour {
	
	public static GAMESTATE gamestate=GAMESTATE.TITLE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
