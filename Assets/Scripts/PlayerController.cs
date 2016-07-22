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

    private Vector3 movementSpeed;

    private float dashTime;
    private float dashTimeVal = 1f;

    private bool isDashing = false;

    private float damping = 2f;

    public void Move(Vector3 movement)
    {
        this.movement = movement * Time.deltaTime;
    }

    void Start()
    {
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
        isDashing = true;
        dashTime = dashTimeVal;
        if (dashTime > 0)
        {
            speed *= 2.0f;
            dashTime -= Time.deltaTime;
        }
        BoostEnded();
    }

    public void BoostEnded()
    {
        isDashing = false;
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

    public bool IsDashing
    {
        get { return isDashing; }
    }

    public void LookAt(Vector3 position) {
        Vector3 lookPos = position - this.transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * damping); 
    }
}
