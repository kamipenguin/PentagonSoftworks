using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private GameObject ball;
    private Rigidbody rbBall;

    private GameObject player1Left, player1Right, player2Left, player2Right;
    private PlayerController p1Left, p1Right, p2Left, p2Right;

    [SerializeField]
    private Transform player1LeftSpawn, player1RightSpawn, player2LeftSpawn, player2RightSpawn;

    private GameObject[] ballSpawnPositions;
    private Vector3 ballSpawnPos;

    [SerializeField]
    private float moveSpeed = 10f;

    private PlayerController p1L, p1R, p2L, p2R;

    private float p1LhAxis, p1LvAxis, p1RhAxis, p1RvAxis, p2LhAxis, p2LvAxis, p2RhAxis, p2RvAxis, p1LTrigger, p1RTriggerm p2LTrigger, p2RTrigger;

    void Start()
    {
        // Create the ball at either the player 1 side or player 2 side of the field
        ballSpawnPositions = GameObject.FindGameObjectsWithTag("BallSpawnPoint");
        ballSpawnPos = ballSpawnPositions[(int)Random.Range(0f, 1f)].transform.position;
        ball = (GameObject) Instantiate(Resources.Load("ball"), ballSpawnPos, Quaternion.identity);
        rbBall = ball.GetComponent<Rigidbody>();

        // Create the left character of player 1
        player1Left = (GameObject) Instantiate(Resources.Load("player"), player1LeftSpawn.position, Quaternion.identity);
        p1L = player1Left.GetComponent<PlayerController>();

        // Create the right character of player 1
        player1Right = (GameObject) Instantiate(Resources.Load("player"), player1RightSpawn.position, Quaternion.identity);
        p1R = player1Right.GetComponent<PlayerController>();

        // Create the left character of player 2
        player2Left = (GameObject) Instantiate(Resources.Load("player"), player2LeftSpawn.position, Quaternion.identity);
        p2L = player2Left.GetComponent<PlayerController>();

        // Create the right character of player 2
        player2Right = (GameObject) Instantiate(Resources.Load("player"), player2RightSpawn.position, Quaternion.identity);
        p2R = player2Right.GetComponent<PlayerController>();
    }

    void ResetPlayers() {
        player1Left.transform.position = player1LeftSpawn.position;
        player1Right.transform.position = player1RightSpawn.position;
        player2Left.transform.position = player2LeftSpawn.position;
        player2Right.transform.position = player2RightSpawn.position;
    }

    void Update() {
        p1LhAxis = Input.GetAxis("Player1LeftHorizontal");
        p1LvAxis = Input.GetAxis("Player1LeftVertical");
        p1RhAxis = Input.GetAxis("Player1RightHorizontal");
        p1RvAxis = Input.GetAxis("Player1RightVertical");
        p2LhAxis = Input.GetAxis("Player2LeftHorizontal");
        p2LvAxis = Input.GetAxis("Player2LeftVertical");
        p2RhAxis = Input.GetAxis("Player2RightHorizontal");
        p2RvAxis = Input.GetAxis("Player2RightVertical");

        p1LTrigger = Input.GetAxis("Player1LeftTrigger");
        p1RTrigger = Input.GetAxis("Player1RightTrigger");

        p2LTrigger = Input.GetAxis("Player2LeftTrigger");
        p2RTrigger = Input.GetAxis("Player2RightTrigger");

        //Debug.Log("Player1LeftHorizontal:" + p1LhAxis);
        //Debug.Log("Player1LeftVertical:" + p1LvAxis);
        //Debug.Log("Player1RightHorizontal:" + p1RhAxis);
        //Debug.Log("Player1RightVertical:" + p1RvAxis);
        //Debug.Log("Player2LeftHorizontal:" + p2LhAxis);
        //Debug.Log("Player2LeftVertical:" + p2LvAxis);
        //Debug.Log("Player2RightHorizontal:" + p2RhAxis);
        //Debug.Log("Player2RightHorizontal:" + p2RvAxis);

        p1L.Move( new Vector3(p1LhAxis, 0.0f,  p1LvAxis) );
        p1R.Move( new Vector3(p1RhAxis, 0.0f, p1RvAxis) );
        p2L.Move( new Vector3(p2LhAxis, 0.0f, p2LvAxis) );
        p2R.Move( new Vector3(p2RhAxis, 0.0f, p2RvAxis) );

        if(p1LTrigger != 0f && p1L.IsBallInControl()) {
            p1L.Shoot(rbBall);
        }
        if(p1LTrigger != 0f && p1R.IsBallInControl()) {
            p1L.Shoot(rbBall);
        }
        if(p1LTrigger != 0f && p2L.IsBallInControl()) {
            p1L.Shoot(rbBall);
        }
        if(p1LTrigger != 0f && p2R.IsBallInControl()) {
            p1L.Shoot(rbBall);
        }
    }
}
