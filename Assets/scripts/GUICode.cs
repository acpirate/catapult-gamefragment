using UnityEngine;
using System.Collections;

public class GUICode : MonoBehaviour {
	
	
	public GUIStyle titleStyle;
	public GUIStyle instructionStyle;
	
	//settings button
	int settingsButtonSize=60;
	int settingsButtonOffset=20;
	
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
				if (Input.GetMouseButton(0))  {
					MainGameCode.gamestate=GAMESTATE.PLAY;
				}			
			break;			
		}	
		
	}
	
	
	void OnGUI() {
		switch (MainGameCode.gamestate) {
			case GAMESTATE.TITLE:	
				DrawTitle();
			break;
			case GAMESTATE.PLAY:
				DrawSettingsButton();
			break;
		}	
	}	
	
	void DrawTitle() {
		ShadowAndOutline.DrawOutline(new Rect(0,Screen.height*.25f,Screen.width,Screen.height*.5f),"Catapult!",titleStyle,Color.black,Color.white,2f);
		if ((float.Parse(Time.time.ToString("0.0"))) % 3<2.5f)
		ShadowAndOutline.DrawOutline(new Rect(0,Screen.height*.75f,Screen.width,Screen.height*.25f),"Click anywhere to play",instructionStyle,Color.black,Color.white,2f);
	}	
	
	void DrawSettingsButton() {	
		if (GUI.Button(new Rect(settingsButtonOffset,Screen.height-settingsButtonOffset-settingsButtonSize,settingsButtonSize,settingsButtonSize),
			settingsTexture)) 
			MainGameCode.gamestate=GAMESTATE.SETTINGS;
		
	}	
	
}
