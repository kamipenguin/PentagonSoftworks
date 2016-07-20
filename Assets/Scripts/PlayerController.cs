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

    public bool canPush = false;

    private Rigidbody ball;

    public void Move(Vector3 movement) {
        //Debug.Log(movement);
        this.movement = movement * Time.deltaTime;
        //transform.Translate(movement * Time.deltaTime * speed);
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>();
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

    public void PushBall()
    {
        ball.AddForce(this.transform.TransformDirection(Vector3.forward) * Time.deltaTime * 200);
    }

    void OnTriggerStay(Collider col) {

        if (col.tag == "ball") {
            Debug.Log("Shoot the ball");
            canPush = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "ball")
            canPush = false;
    }
}
