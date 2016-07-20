using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform playerLeft;
    public Transform playerRight;

    public Transform ball;
    
    public void pushLeft()
    {
        print("pushleft");
    }

    public void pushRight()
    {
        print("pushright");
    }

    public void pullLeft()
    {
        print("pullleft");
    }

    public void pullRight()
    {
        print("pullright");
    }

    public void moveLeft(Vector3 direction)
    {
        Rigidbody body = playerLeft.GetComponent<Rigidbody>();
        body.position += direction;
    }

    public void moveRight(Vector3 direction)
    {
        Rigidbody body = playerRight.GetComponent<Rigidbody>();
        body.position += direction;
    }
}
