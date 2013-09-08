using UnityEngine;
using System.Collections;

public enum GAMESTATE { TITLE, PLAY, GAMEOVER, SETTINGS, AIM };
public enum DIRECTION { LEFT, RIGHT, NONE, UP, DOWN};

public class MainGameCode : MonoBehaviour {
	
	public static GameObject king=null;
	public static GameObject puck=null;
	public static GameObject aimCamera=null;
	static Camera mainCamera=null;
	static Vector3 mainCameraStart=new Vector3(0,30,-280);
	
	
	public GameObject brickPrefab;
	int wallWidth=30;
	int wallHeight=20;
	float brickWidth=5f;
	float brickHeight=2.5f;
	float brickHeightOffset=1.73f;
	float wallXStart=-25;
	float wallZStart=-100;
	
	
	
	
	static float powerChargeRate=50;
	public static float maxPower=100;
	public static float currentPower=0;
	public static float powerMultiplier=100f;
	public static float puckResetLocation=-245;
	
	public static GAMESTATE gamestate=GAMESTATE.TITLE;

	// Use this for initialization
	void Awake() {
		if (king==null) king=GameObject.Find("King");
		if (puck==null) puck=GameObject.Find("Puck");
		if (aimCamera==null) aimCamera=GameObject.Find("AimCamera");
		if (mainCamera==null) mainCamera=GameObject.Find("Main Camera").GetComponent<Camera>();
		
		BuildWall();
		
	}	
	
	void Start () {
		mainCamera.transform.LookAt(puck.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		//look at the puck while its flying
		if (puck.rigidbody.velocity.magnitude>0) mainCamera.transform.LookAt(puck.transform.position);
		//reset the puck if it falls off
		if (puck.transform.position.y<0) ResetPuck();
	}
	
	//instance methods
	void BuildWall() {
		for (int yCounter=0;yCounter<wallHeight;yCounter++) {
			for (int xCounter=0;xCounter<wallWidth;xCounter++) {
				float brickOffset=0;
				if (yCounter%2==1) brickOffset=brickWidth/2;
				Vector3 brickLocation=new Vector3(wallXStart+xCounter*brickWidth+brickOffset,brickHeight*yCounter+brickHeightOffset,wallZStart);
				Instantiate(brickPrefab,brickLocation,Quaternion.identity);
			}	
		}	
	}	
	
	
	//static methods
	
	public static void ShootPuck() {
		EndAim();
		puck.rigidbody.AddRelativeForce(new Vector3(0,currentPower*powerMultiplier,currentPower*powerMultiplier));
		puck.rigidbody.AddTorque(new Vector3(currentPower*powerMultiplier*10,0,0));
		
		currentPower=0;
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
		//if (gamestate==GAMESTATE.AIM) GUICode.testPositive=true;
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
		puck.transform.position=new Vector3(0,1.5f,puckResetLocation);
		puck.transform.rotation=Quaternion.Euler(0,0,0);
		puck.rigidbody.velocity=new Vector3(0,0,0);
		mainCamera.transform.position=mainCameraStart;
		mainCamera.transform.LookAt(puck.transform.position);
	}	
	
	public static void PowerCharge() {
		currentPower+=powerChargeRate*Time.deltaTime;
		if (currentPower>maxPower) currentPower=0;
		
	}	
}
