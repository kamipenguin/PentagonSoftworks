using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)) {
			Debug.Log("w");
			this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		else if(Input.GetKey("a")) {
			Debug.Log("a");
			this.gameObject.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
		}
		else if(Input.GetKey("s")) {
			Debug.Log("s");
			this.gameObject.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
		}
		else if(Input.GetKey("d")) {
			Debug.Log("d");
			this.gameObject.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
		}
	}
}
