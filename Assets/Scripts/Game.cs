using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private GameObject ball;
    private GameObject player1Left, player1Right, player2Left, player2Right;
    private PlayerController p1Left, p1Right, p2Left, p2Right;

    [SerializeField]
    private Transform player1LeftSpawn, player1RightSpawn, player2LeftSpawn, player2RightSpawn;

    private GameObject[] ballSpawnPositions;
    private Vector3 ballSpawnPos;

    [SerializeField]
    private float moveSpeed = 10f;

    void Start()
    {
        // Create the ball at either the player 1 side or player 2 side of the field
        ballSpawnPositions = GameObject.FindGameObjectsWithTag("BallSpawnPoint");
        ballSpawnPos = ballSpawnPositions[(int)Random.Range(0f, 1f)].transform.position;
        ball = (GameObject) Instantiate(Resources.Load("ball"), ballSpawnPos, Quaternion.identity);

        // Create the left character of player 1
        player1Left = (GameObject) Instantiate(Resources.Load("player"), player1LeftSpawn.position, Quaternion.identity);

        // Create the right character of player 1
        player1Right = (GameObject) Instantiate(Resources.Load("player"), player1RightSpawn.position, Quaternion.identity);

        // Create the left character of player 2
        player2Left = (GameObject) Instantiate(Resources.Load("player"), player2LeftSpawn.position, Quaternion.identity);

        // Create the right character of player 2
        player2Right = (GameObject) Instantiate(Resources.Load("player"), player2RightSpawn.position, Quaternion.identity);

        p1Left = player1Left.GetComponent<PlayerController>();
        p1Right = player1Right.GetComponent<PlayerController>();
        p2Left = player2Left.GetComponent<PlayerController>();
        p2Right = player2Right.GetComponent<PlayerController>();
    }

    void ResetPlayers() {
        player1Left.transform.position = player1LeftSpawn.position;
        player1Right.transform.position = player1RightSpawn.position;
        player2Left.transform.position = player2LeftSpawn.position;
        player2Right.transform.position = player2RightSpawn.position;
    }

    void Update() {
        if (Input.GetAxis("Player1LeftHorizontal") != 0 || Input.GetAxis("Player1LeftVertical") != 0) {
            Vector3 position = (Input.GetAxis("Player1LeftHorizontal") * player1Left.transform.right + Input.GetAxis("Player1LeftVertical") * player1Left.transform.forward).normalized * moveSpeed * Time.deltaTime;
            Debug.Log("Player1Left");
            //Vector3 direction = new Vector3(Input.GetAxis("Player1LeftHorizontal"), 0, 
            //    -Input.GetAxis("Player1LeftVertical"));

            p1Left.Move(position);
         }
        if (Input.GetAxis("Player1RightHorizontal") != 0 || Input.GetAxis("Player1RightVertical") != 0)
        {
            Vector3 position = (Input.GetAxis("Player1RightHorizontal") * player1Right.transform.right + Input.GetAxis("Player1RightVertical") * player1Right.transform.forward).normalized * moveSpeed * Time.deltaTime;
            Debug.Log("Player1Right");
            //Vector3 direction = new Vector3(Input.GetAxis("Player1RightHorizontal"), 0,
            //    -Input.GetAxis("Player1RightVertical"));

            p1Right.Move(position);
        }
        if (Input.GetAxis("Player2LeftHorizontal") != 0 || Input.GetAxis("Player2LeftVertical") != 0) {
            Vector3 position = (Input.GetAxis("Player2LeftHorizontal") * player2Left.transform.right + Input.GetAxis("Player2LeftVertical") * player2Left.transform.forward).normalized * moveSpeed * Time.deltaTime;
            Debug.Log("Player2Left");
            //Vector3 direction = new Vector3(Input.GetAxis("Player1LeftHorizontal"), 0, 
            //    -Input.GetAxis("Player2LeftVertical"));

            p2Left.Move(position);
         }
        if (Input.GetAxis("Player2RightHorizontal") != 0 || Input.GetAxis("Player2RightVertical") != 0)
        {
            Vector3 position = (Input.GetAxis("Player1RightHorizontal") * player2Right.transform.right + Input.GetAxis("Player1RightVertical") * player2Right.transform.forward).normalized * moveSpeed * Time.deltaTime;
            Debug.Log("Player2Right");
            //Vector3 direction = new Vector3(Input.GetAxis("Player2RightHorizontal"), 0,
            //    -Input.GetAxis("Player2RightVertical"));

            p2Right.Move(position);
        }
    }
}
