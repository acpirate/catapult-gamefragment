using UnityEngine;
using System.Collections;

public enum GAMESTATE { TITLE, PLAY, GAMEOVER, SETTINGS };

public class MainGameCode : MonoBehaviour {
	
	static GameObject king=null;
	
	public static GAMESTATE gamestate=GAMESTATE.TITLE;

	// Use this for initialization
	void Awake() {
		if (king==null) king=GameObject.Find("King");
	}	
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public static void QuitGame() {
		gamestate=GAMESTATE.GAMEOVER;
	}
	
	public static void ResetGame() {
		king.transform.position=new Vector3(0,23,450);
		king.transform.eulerAngles=new Vector3(0,0,0);
		gamestate=GAMESTATE.TITLE;	
	}	
	
	public static void PlayGame() {
		gamestate=GAMESTATE.PLAY;	
	}
	
	public static void GameOver() {
		gamestate=GAMESTATE.GAMEOVER;	
	}	
}
