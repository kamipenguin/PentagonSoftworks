using UnityEngine;
using System.Collections;

// public enum PlayerEnum{Player1,Player2}
// public enum CharacterEnum{Left,Right}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    
    [SerializeField]
    private float speed = 10000000.0f;

    public void Move(Vector3 movement) {
        //Debug.Log(movement);
        this.movement = movement;
        //transform.Translate(movement * Time.deltaTime * speed);
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.AddForce(movement * speed);
    }
}
