using UnityEngine;
using System.Collections;

public class GUICode : MonoBehaviour {
	
	
	public GUIStyle titleStyle;
	public GUIStyle instructionStyle;
	
	//settings button
	int settingsButtonSize=60;
	int settingsButtonOffset=20;
	//settings window
	int settingsWindowWidth=20; //percent
	int settingsWindowHeight=50; //percent
	
	
	public Texture2D settingsTexture;
	
	void Awake() {
	}	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch (MainGameCode.gamestate) {
			case GAMESTATE.TITLE:
				if (Input.GetMouseButtonDown(0))  {
					MainGameCode.PlayGame();
				}			
			break;
			case GAMESTATE.GAMEOVER:
				if (Input.GetMouseButtonDown(0))  {
					MainGameCode.ResetGame();
				}			
			break;
			case GAMESTATE.AIM:
				if (Input.GetMouseButton(1)) {
					MainGameCode.EndAim();
				}
			break;
			
		}
		//cursor hide and show
		if (Input.GetKey(KeyCode.LeftControl) || (MainGameCode.gamestate!=GAMESTATE.PLAY && MainGameCode.gamestate!=GAMESTATE.AIM)) {
			Screen.showCursor=true;	
		}
		else  {
			Screen.showCursor=false;	
		}		
		
	}		
	
	void OnGUI() {
		switch (MainGameCode.gamestate) {
			case GAMESTATE.TITLE:	
				DrawTitle();
			break;
			case GAMESTATE.PLAY:
				GameSettings();
				PlayInstructions();
			break;
			case GAMESTATE.SETTINGS:
				DrawSettingsWindow();
			break;
			case GAMESTATE.GAMEOVER:
				DrawGameOver();
			break;
			case GAMESTATE.AIM:
				AimInstructions();
			break;			
		}	
	}	
	
	void DrawGameOver() {
		ShadowAndOutline.DrawOutline(new Rect(0,Screen.height*.25f,Screen.width,Screen.height*.5f),"Game Over",titleStyle,Color.black,Color.white,2f);
		if ((float.Parse(Time.time.ToString("0.0"))) % 3<2.5f)
		ShadowAndOutline.DrawOutline(new Rect(0,Screen.height*.75f,Screen.width,Screen.height*.25f),"Click anywhere to go back to title",instructionStyle,Color.black,Color.white,2f);	
	}	
	
	void DrawTitle() {
		ShadowAndOutline.DrawOutline(new Rect(0,Screen.height*.25f,Screen.width,Screen.height*.5f),"Catapult!",titleStyle,Color.black,Color.white,2f);
		if ((float.Parse(Time.time.ToString("0.0"))) % 3<2.5f)
		ShadowAndOutline.DrawOutline(new Rect(0,Screen.height*.75f,Screen.width,Screen.height*.25f),"Click anywhere to play",instructionStyle,Color.black,Color.white,2f);
	}	
	
	void GameSettings() {
		DrawSettingsButton();
	}	
	
	void PlayInstructions() {
		Rect instructionPosition=new Rect(0,Screen.height*.9f,Screen.width,Screen.height*.10f);
		ShadowAndOutline.DrawOutline(instructionPosition,"left ctrl to show mouse pointer, click your puck to aim",instructionStyle,Color.black,Color.white,2f);
	}	
	
	void AimInstructions() {
		Rect instructionPosition=new Rect(0,Screen.height*.8f,Screen.width,Screen.height*.10f);
		ShadowAndOutline.DrawOutline(instructionPosition,"move mouse to turn, right click to cancel\nhold left button to power up, release left button to fire",instructionStyle,Color.black,Color.white,2f);
	}	
	
	void DrawSettingsButton() {	
		if (GUI.Button(new Rect(settingsButtonOffset,Screen.height-settingsButtonOffset-settingsButtonSize,settingsButtonSize,settingsButtonSize),
			settingsTexture)) 
			MainGameCode.gamestate=GAMESTATE.SETTINGS;
		
	}	
	
	void DrawSettingsWindow() {
		/*GUI.Box(new Rect(Screen.width*.5f-Screen.width*.5f*.01f*settingsWindowWidth,
						 Screen.height*.5f-Screen.height*.5f*.01f*settingsWindowHeight,
						 Screen.width*.01f*settingsWindowWidth,
						 Screen.height*.01f*settingsWindowHeight),
				"");*/

		GUILayout.BeginArea(new Rect(Screen.width*.5f-Screen.width*.5f*.01f*settingsWindowWidth,
						 Screen.height*.5f-Screen.height*.5f*.01f*settingsWindowHeight,
						 Screen.width*.01f*settingsWindowWidth,
						 Screen.height*.01f*settingsWindowHeight));
		if (GUILayout.Button("Back To Game")) 
			MainGameCode.gamestate=GAMESTATE.PLAY;
		if (GUILayout.Button("Quit Game")) 
			MainGameCode.QuitGame();
		
		
		GUILayout.EndArea();
	}	
	
}
