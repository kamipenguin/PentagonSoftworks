using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	[SerializeField]
	private Image circularArena, classicSoccer;

	private enum Map {
		CircularArena = 0,
		ClassicSoccer = 1
	}

	private enum System {
		Mac,
		Windows
	}

	[SerializeField]
	private System system;

	private Map map;

	void Start() {
		map = Map.CircularArena;
		classicSoccer.enabled = false;
	}

	void Update() {
		switch(system) {
			case System.Mac:
				Debug.Log("Mac");
				InputMac();
				break;
			case System.Windows:
				Debug.Log("Windows");
				InputWindows();
				break;
		}
	}

	void InputMac() {
		if(Input.GetButtonDown("D-PadLeftMac")) {
			Debug.Log("Toggle");
			ToggleGameModes();
		}
		else if(Input.GetButtonDown("D-PadRightMac")) {
			Debug.Log("Toggle");
			ToggleGameModes();
		}
		if(Input.GetButtonDown("Mac_A")) {
			SceneManager.LoadScene((int)map, LoadSceneMode.Additive);
		}


	}

	void InputWindows() {
        //
        if (Input.GetAxis("d-pad_windows_left") != 0)
        {
            Debug.Log("Toggle");
            ToggleGameModes();
        }

        //if(Input.GetKey(""))

        /*else if (Input.GetButtonDown("D-PadRightMac"))
        {
            Debug.Log("Toggle");
            ToggleGameModes();
        }*/
        if (Input.GetButtonDown("Mac_A"))
        {
            SceneManager.LoadScene((int)map, LoadSceneMode.Additive);
        }
    }

	void ToggleGameModes() {
		switch(map) {
			case Map.CircularArena:
				Debug.Log("CA");
				map = Map.ClassicSoccer;
				circularArena.enabled = false;
				classicSoccer.enabled = true;
				break;
			case Map.ClassicSoccer:
				Debug.Log("CS");
				map = Map.CircularArena;
				circularArena.enabled = true;
				classicSoccer.enabled = false;
				break;
		}
	}
}
