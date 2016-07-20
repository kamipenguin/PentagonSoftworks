using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
<<<<<<< HEAD
    private Transform playerLeft;
    [SerializeField]
    private Transform playerRight;

    [SerializeField]
    private float speed;

    private Rigidbody ballBody;
    private Ball ball;

    private float distanceToBall = 0;

    private Rigidbody body;

    void Start()
    {
        ballBody = GameObject.FindWithTag("Ball").transform.GetComponent<Rigidbody>();
        ball = GameObject.FindWithTag("Ball").transform.GetComponent<Ball>();
        body = playerLeft.GetComponent<Rigidbody>();
    }
=======
    private Transform leftPlayer;
    [SerializeField]
    private Transform rightPlayer;

    private Rigidbody rbLeftPlayer;
    private Rigidbody rbRightPlayer;

    [SerializeField]
    private float speed;
>>>>>>> origin/PushPullMechanism
    
    public void pushLeft()
    {
        distanceToBall = Vector3.Distance(ballBody.position, body.position);

        if (distanceToBall < 10)
            ball.push(playerLeft);

        //print(distanceToBall.magnitude);
        print(Vector3.Distance(ballBody.position, body.position));
    }

    public void pushRight()
    {
        print("pushright");
        ball.pull = false;
    }

    /*public void pullLeft()
    {
        /*distanceToBall = ballBody.position + body.position;

        if (distanceToBall.magnitude <= 7)
        {
            
            
        /*}
        else
            ball.pull = false;

        ball.pull = true;
        ball.pulling(playerLeft.position);
    }

    public void pullRight()
    {
        print("pullright");
    }*/

    public void moveLeftPlayer(Vector3 direction)
    {
<<<<<<< HEAD
        //body = playerLeft.GetComponent<Rigidbody>();
        body.position += direction * speed;
=======
        rbLeftPlayer.position += direction;
>>>>>>> origin/PushPullMechanism
    }

    public void moveRightPlayer(Vector3 direction)
    {
<<<<<<< HEAD
        Rigidbody body = playerRight.GetComponent<Rigidbody>();
        body.position += direction * speed;
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
=======
        rbRightPlayer.position += direction;
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
>>>>>>> origin/PushPullMechanism
        }
    }
}
