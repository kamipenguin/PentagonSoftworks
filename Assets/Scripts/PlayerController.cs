using UnityEngine;
using System.Collections;

// public enum PlayerEnum{Player1,Player2}
// public enum CharacterEnum{Left,Right}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private bool boostUsed = false;
    private float rotation = 0;
    
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform mascot;

    private Animation anim;

    public bool canPush = false;

    private Rigidbody ball;

    public void Move(Vector3 movement, float rotation) {
        //Debug.Log(movement);
        this.movement = movement * Time.deltaTime;
        this.rotation += rotation * Time.deltaTime;
        //transform.Translate(movement * Time.deltaTime * speed);
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>();
        rotation = transform.eulerAngles.y;

        anim = mascot.GetComponent<Animation>();
    }

    void FixedUpdate() {
        rb.AddForce(movement * speed);
        transform.rotation = Quaternion.Euler(0, rotation, 0);

        if (movement == Vector3.zero)
            anim.CrossFade("Idle Cycle");
        else
            anim.CrossFade("Run Cycle");
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
