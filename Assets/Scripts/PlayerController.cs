using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Messaging;

// public enum PlayerEnum{Player1,Player2}
// public enum CharacterEnum{Left,Right}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb, rbBall;
    private Vector3 movement;

    private bool ballControl = false;

    [SerializeField]
    private float speed;

    private float boostTimerVal = 1F;
    private float boostTimer;

    private bool startBoost = false;

    private Vector3 movementSpeed;

    public void Move(Vector3 movement)
    {
        this.movement = movement * Time.deltaTime;
    }

    void Start()
    {
        boostTimer = boostTimerVal;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * speed);
        movementSpeed = movement*speed;
    }

    public bool IsBallInControl()
    {
        return ballControl;
    }

    public void Boost()
    {
        speed *= 2.0f;
    }

    public void BoostEnded()
    {
        speed /= 2.0f;
    }

    public void Shoot(Rigidbody ball)
    {
        ball.AddForce(transform.TransformDirection(Vector3.forward) * 50f);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Ball")
        {
            ballControl = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ball")
        {
            ballControl = false;
        }
    }

    public Vector3 MovementSpeed()
    {
        return movementSpeed;
    }

    public bool BoostStarted
    {
        set { startBoost = value; }
    }
}
