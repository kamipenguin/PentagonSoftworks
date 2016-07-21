using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += Vector3.forward * Time.deltaTime * 10;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += Vector3.back * Time.deltaTime * 10;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * Time.deltaTime * 10;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * Time.deltaTime * 10;
        }

    }
}
