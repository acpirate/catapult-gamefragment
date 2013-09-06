using UnityEngine;
using System.Collections;

public enum GAMESTATE { TITLE, PLAY, GAMEOVER, SETTINGS, AIM };

public class MainGameCode : MonoBehaviour {
	
	static GameObject king=null;
	static GameObject puck=null;
	static Camera mainCamera=Camera.main;
	
	public static GAMESTATE gamestate=GAMESTATE.TITLE;

	// Use this for initialization
	void Awake() {
		if (king==null) king=GameObject.Find("King");
		if (puck==null) puck=GameObject.Find("Puck");
	}	
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public static void QuitGame() {
		ResetKing();
		ResetPuck();
		gamestate=GAMESTATE.GAMEOVER;
	}
	
	public static void ResetGame() {

		gamestate=GAMESTATE.TITLE;	
	}	
	
	
	
	public static void PlayGame() {
		gamestate=GAMESTATE.PLAY;	
	}
	
	public static void GameOver() {
		gamestate=GAMESTATE.GAMEOVER;	
	}	
	
	public static void AimMode() {
		mainCamera.enabled=false;
		puck.GetComponent<LineRenderer>().enabled=true;
		gamestate=GAMESTATE.AIM;	
	}
	
	public static void EndAim() {
		mainCamera.enabled=true;
		puck.GetComponent<LineRenderer>().enabled=false;
		gamestate=GAMESTATE.PLAY;
	}	
	
	public static void ResetKing() {
		king.transform.position=new Vector3(0,23,450);
		king.transform.eulerAngles=new Vector3(0,0,0);			
	}	
	
	public static void ResetPuck() {
		puck.transform.position=new Vector3(0,1.5f,-450);
		puck.transform.eulerAngles=new Vector3(0,0,0);
	}	
}
