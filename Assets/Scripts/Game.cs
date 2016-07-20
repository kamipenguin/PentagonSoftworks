using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private GameObject ball;
    private GameObject player1Left, player1Right, player2Left, player2Right;

    [SerializeField]
    private Transform player1LeftSpawn, player1RightSpawn, player2LeftSpawn, player2RightSpawn;

    private GameObject[] ballSpawnPositions;
    private Vector3 ballSpawnPos;

    [SerializeField]
    private float moveSpeed = 10f;

    private PlayerController p1L, p1R, p2L, p2R;

    void Start()
    {
        // Create the ball at either the player 1 side or player 2 side of the field
        ballSpawnPositions = GameObject.FindGameObjectsWithTag("BallSpawnPoint");
        ballSpawnPos = ballSpawnPositions[(int)Random.Range(0f, 1f)].transform.position;
        ball = (GameObject) Instantiate(Resources.Load("ball"), ballSpawnPos, Quaternion.identity);

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

        if(Input.GetAxis("Player1LeftTrigger") > 0.0f) {
            Debug.Log("Player1LeftTrigger");
            if(!p1L.IsBoostUsed()) {
                p1L.Boost();
            }
        }

        if(Input.GetAxis("Player1RightTrigger") > 0.0f) {
            Debug.Log("Player1RightTrigger");
            if(!p1R.IsBoostUsed()) {
                p1R.Boost();
            }
        }

        if(Input.GetAxis("Player2LeftTrigger") > 0.0f) {
            Debug.Log("Player2LeftTrigger");
            if(!p2L.IsBoostUsed()) {
                p2L.Boost();
            }
        }

        if(Input.GetAxis("Player2RightTrigger") > 0.0f) {
            Debug.Log("Player2RightTrigger");
            if(!p2R.IsBoostUsed()) {
                p2R.Boost();
            }
        }

        p1L.Move( new Vector3(Input.GetAxis("Player1LeftHorizontal"), 0.0f,  Input.GetAxis("Player1LeftVertical")) );
        p1R.Move( new Vector3(Input.GetAxis("Player1RightHorizontal"), 0.0f, Input.GetAxis("Player1RightVertical")) );
        p2L.Move( new Vector3(Input.GetAxis("Player2LeftHorizontal"), 0.0f, Input.GetAxis("Player2LeftVertical")) );
        p2R.Move( new Vector3(Input.GetAxis("Player2RightHorizontal"), 0.0f, Input.GetAxis("Player2RightVertical")) );

        if(Input.GetAxis("Player1LeftHorizontal") == 0.0f && Input.GetAxis("Player1LeftVertical") == 0.0f)
            p1L.Move(new Vector3(0, 0, 0));
        if(Input.GetAxis("Player1RightHorizontal") == 0.0f && Input.GetAxis("Player1RightVertical") == 0.0f)
            p1R.Move(new Vector3(0, 0, 0));
        if(Input.GetAxis("Player2LeftHorizontal") == 0.0f && Input.GetAxis("Player2LeftVertical") == 0.0f)
            p2L.Move(new Vector3(0, 0, 0));
        if(Input.GetAxis("Player2RightHorizontal") == 0.0f && Input.GetAxis("Player2RightVertical") == 0.0f)
            p2R.Move(new Vector3(0, 0, 0));

        if (Input.GetKey("joystick 1 button 4"))
        {
            if (p1L.canPush)
                p1L.PushBall();
        }

        if (Input.GetKey("joystick 1 button 5"))
        {
            if (p1R.canPush)
                p1R.PushBall();
        }

        if (Input.GetKey("joystick 2 button 4"))
        {
            if (p2L.canPush)
                p2L.PushBall();
        }

        if (Input.GetKey("joystick 2 button 5"))
        {
            if (p2R.canPush)
                p2R.PushBall();
        }
    }
}
