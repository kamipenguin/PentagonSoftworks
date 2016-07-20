using UnityEngine;
using System.Collections;

// public enum PlayerEnum{Player1,Player2}
// public enum CharacterEnum{Left,Right}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private bool boostUsed = false;
    
    [SerializeField]
    private float speed;

    public void Move(Vector3 movement) {
        this.movement = movement * Time.deltaTime;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.AddForce(movement * speed);
    }

    public bool IsBoostUsed() {
        return boostUsed;
    }

    public void Boost() {
        Debug.Log("Boost");
        speed *= 1.5f;
        boostUsed = true;
    }

    void OnTriggerStay(Collider col) {
        if(col.tag == "ball") {
            Debug.Log("Shoot the ball");
        }

        /*
        if(Input.GetAxis("Player1LeftTrigger") > 0.0f || Input.GetAxis("Player1RightTrigger") > 0.0f || Input.GetAxis("Player2LeftTrigger") > 0.0f || Input.GetAxis("Player2RightTrigger") > 0.0f) {
            if(col.tag == "ball") {
                Debug.Log("Shoot the ball");
            }
        }*/
    }
}
