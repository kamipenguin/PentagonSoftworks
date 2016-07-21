using UnityEngine;
using System.Collections;

// public enum PlayerEnum{Player1,Player2}
// public enum CharacterEnum{Left,Right}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb, rbBall;
    private Vector3 movement;
    private bool boostUsed = false;

    private bool ballControl = false;

    [SerializeField]
    private float speed;

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
    }

    public bool IsBoostUsed()
    {
        return boostUsed;
    }

    public bool IsBallInControl()
    {
        return ballControl;
    }

    public void Boost()
    {
        Debug.Log("Boost");
        speed *= 1.5f;
        boostUsed = true;
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
}
