using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Transform leftPlayer;
    [SerializeField]
    private Transform rightPlayer;

    private Rigidbody rbLeftPlayer;
    private Rigidbody rbRightPlayer;

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

    public void moveLeftPlayer(Vector3 direction)
    {
        rbLeftPlayer.position += direction * Time.deltaTime * speed;
    }

    public void moveRightPlayer(Vector3 direction)
    {
        rbRightPlayer.position += direction * Time.deltaTime * speed;
    }

    void Start() {
        rbLeftPlayer = leftPlayer.GetComponent<Rigidbody>();
        rbRightPlayer = rightPlayer.GetComponent<Rigidbody>();
    }

    void Update() {

        // wasd & up, left, down and right key movement

        // Player 1 moves forward with w or with the xbox controller by using the left analog stick
        if(Input.GetKey("w")) {
            leftPlayer.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        // Player 1 moves left with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("a")) {
            leftPlayer.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Player 1 moves backward with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("s")) {
            leftPlayer.Translate(Vector3.back * Time.deltaTime * speed);
        }
        // Player 1 moves right with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("d")) {
            leftPlayer.Translate(Vector3.right * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        if(Input.GetKey("up")) {
            rightPlayer.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("left")) {
            rightPlayer.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("down")) {
            rightPlayer.Translate(Vector3.back * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("right")) {
            rightPlayer.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
