using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
	void Update() {

		transform.LookAt(Camera.main.transform);
	}
}