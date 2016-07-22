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
		if(Input.GetButtonDown("D-PadLeftWin")) {
			Debug.Log("Toggle");
			ToggleGameModes();
		}
		else if(Input.GetButtonDown("D-PadRightMac")) {
			Debug.Log("Toggle");
			ToggleGameModes();
		}
		if(Input.GetButtonDown("Mac_A")) {
			// SceneManager.LoadScene((int)map, LoadSceneMode.Additive);
			SceneManager.LoadScene((int)map);
		}
	}

    void InputWindows()
    {
        if (Input.GetAxis("D-PadLeftWindows") != 0f)
        {
            Debug.Log("Toggle");
            ToggleGameModes();
        }
        else if (Input.GetAxis("D-PadRightWinows") != 0f)
        {
            Debug.Log("Toggle");
            ToggleGameModes();
        }
        if (Input.GetButtonDown("Win_A"))
        {
            // SceneManager.LoadScene((int)map, LoadSceneMode.Additive);
            SceneManager.LoadScene((int)map);
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
