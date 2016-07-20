using UnityEngine;
using System.Collections;

public class CharacterAController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("joystick button 0")) {
			Debug.Log("joystick button 0 pressed | A");
		}
		else if(Input.GetKeyDown("joystick button 1")) {
			Debug.Log("joystick button 1 pressed | B");
		}
		else if(Input.GetKeyDown("joystick button 2")) {
			Debug.Log("joystick button 2 pressed | X");
		}
		else if(Input.GetKeyDown("joystick button 3")) {
			Debug.Log("joystick button 3 pressed | Y");
		}
		else if(Input.GetKeyDown("joystick button 4")) {
			Debug.Log("joystick button 4 pressed | L");
		}
		else if(Input.GetKeyDown("joystick button 5")) {
			Debug.Log("joystick button 5 pressed | R");
		}
		else if(Input.GetKeyDown("joystick button 6")) {
			Debug.Log("joystick button 6 pressed | Back");
		}
		else if(Input.GetKeyDown("joystick button 7")) {
			Debug.Log("joystick button 7 pressed | Home");
		}
		else if(Input.GetKeyDown("joystick button 8")) {
			Debug.Log("joystick button 8 pressed | Left");
		}
		else if(Input.GetKeyDown("joystick button 9")) {
			Debug.Log("joystick button 9 pressed | Right");
		}/*
		else if(Input.GetKeyDown("X axis")) {
			Debug.Log("X axis pressed | Left analog x");
		}
		else if(Input.GetKeyDown("Y axis")) {
			Debug.Log("Y axis pressed | Left analog y");
		}
		else if(Input.GetKeyDown("3rd axis")) {
			Debug.Log("3rd axis | LT/RT");
		}
		else if(Input.GetKeyDown("4th axis")) {
			Debug.Log("4th axis | Right analog X");
		}
		else if(Input.GetKeyDown("5th axis")) {
			Debug.Log("5th axis | Right analog Y");
		}
		else if(Input.GetKeyDown("6th axis")) {
			Debug.Log("6th axis | Dpad X");
		}
		else if(Input.GetKeyDown("7th axis")) {
			Debug.Log("7th axis | Dpad Y");
		}*/
	}
}
