using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Transform leftPlayer;
    [SerializeField]
    private Transform rightPlayer;

    [SerializeField]
    private float speed;

    private Rigidbody rbLeftPlayer;
    private Rigidbody rbRightPlayer;

    private Rigidbody ballBody;
    private Ball ball;

    private float distanceToBall = 0;

    void Start()
    {
        ballBody = GameObject.FindWithTag("Ball").transform.GetComponent<Rigidbody>();
        ball = GameObject.FindWithTag("Ball").transform.GetComponent<Ball>();

        rbLeftPlayer = leftPlayer.GetComponent<Rigidbody>();
        rbRightPlayer = rightPlayer.GetComponent<Rigidbody>();
    }


    public void pushLeft()
    {
        distanceToBall = Vector3.Distance(ballBody.position, rbLeftPlayer.position);

        if (distanceToBall < 10)
            ball.push(leftPlayer);
    }

    public void pushRight()
    {
        distanceToBall = Vector3.Distance(ballBody.position, rbRightPlayer.position);

        if (distanceToBall < 10)
            ball.push(rightPlayer);
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

    public void moveLeft(Vector3 direction)
    {
       rbLeftPlayer.position += direction;
    }

    public void moveRight(Vector3 direction)
    {
      rbRightPlayer.position += direction;
    }

    void Update() {
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
