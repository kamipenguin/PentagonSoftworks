using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Transform playerLeft;
    [SerializeField]
    private Transform playerRight;

    [SerializeField]
    private float speed;
    
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
        playerLeft.position  += direction;
    }

    public void moveRight(Vector3 direction)
    {
        playerRight.position += direction;
    }

    void Start() {

    }

    void Update() {
        // Player 1 moves forward with w or with the xbox controller by using the left analog stick
        if(Input.GetKey("w")) {
            playerLeft.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        // Player 1 moves left with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("a")) {
            playerLeft.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Player 1 moves backward with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("s")) {
            playerLeft.Translate(Vector3.back * Time.deltaTime * speed);
        }
        // Player 1 moves right with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("d")) {
            playerLeft.Translate(Vector3.right * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        if(Input.GetKey("up")) {
            playerRight.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("left")) {
            playerRight.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("down")) {
            playerRight.Translate(Vector3.back * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("right")) {
            playerRight.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
