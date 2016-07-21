using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject ball;
    public Rigidbody rbBall;

    public Material p1r, p1l, p2r, p2l;

    private GameObject player1Left, player1Right, player2Left, player2Right;
    private PlayerController p1Left, p1Right, p2Left, p2Right;

    [SerializeField]
    private Transform player1LeftSpawn, player1RightSpawn, player2LeftSpawn, player2RightSpawn;

    private GameObject[] ballSpawnPositions;
    private Vector3 ballSpawnPos;

    [SerializeField]
    private float moveSpeed = 10f;

    private PlayerController p1L, p1R, p2L, p2R;

    private float p1LhAxis, p1LvAxis, p1RhAxis, p1RvAxis, p2LhAxis, p2LvAxis, p2RhAxis, p2RvAxis, p1LTrigger, p1RTrigger, p2LTrigger, p2RTrigger;

    private bool isPlayState;

    public GoalController goal1, goal2;

    private bool boostStarted = false;

    [SerializeField]
    private Text winText;

    [SerializeField]
    private Text stats;

    //timer variables
    [SerializeField]
    private Text timerText;

    private string timeDisplay;

    private bool stopTime = false;

    private static float timerVal = 181F;
    private static float timer;

    private static float boostTimerVal = 1F;
    private static float boostTimer;

    void Start()
    {
        // Create the ball at either the player 1 side or player 2 side of the field
        ballSpawnPositions = GameObject.FindGameObjectsWithTag("BallSpawnPoint");
        ballSpawnPos = ballSpawnPositions[Random.Range(0, 2)].transform.position;
        ball = (GameObject) Instantiate(Resources.Load("ball"), ballSpawnPos, Quaternion.identity);
        rbBall = ball.GetComponent<Rigidbody>();

        // Create the left character of player 1
        player1Left = (GameObject) Instantiate(Resources.Load("player"), player1LeftSpawn.position, Quaternion.identity);
        p1L = player1Left.GetComponent<PlayerController>();
        p1L.GetComponent<Renderer>().material = p1l;

        // Create the right character of player 1
        player1Right = (GameObject) Instantiate(Resources.Load("player"), player1RightSpawn.position, Quaternion.identity);
        p1R = player1Right.GetComponent<PlayerController>();
        p1R.GetComponent<Renderer>().material = p1r;

        // Create the left character of player 2
        player2Left = (GameObject) Instantiate(Resources.Load("player2"), player2LeftSpawn.position, Quaternion.identity);
        p2L = player2Left.GetComponent<PlayerController>();
        p2L.GetComponent<Renderer>().material = p2l;

        // Create the right character of player 2
        player2Right = (GameObject) Instantiate(Resources.Load("player2"), player2RightSpawn.position, Quaternion.identity);
        p2R = player2Right.GetComponent<PlayerController>();
        p2R.GetComponent<Renderer>().material = p2r;

        timer = timerVal;
        boostTimer = boostTimerVal;
        isPlayState = true;
    }

    public void ResetPlayers() {
        player1Left.transform.position = player1LeftSpawn.position;
        player1Right.transform.position = player1RightSpawn.position;
        player2Left.transform.position = player2LeftSpawn.position;
        player2Right.transform.position = player2RightSpawn.position;
    }

    void Update()
    {
        stats.text = "Player1Left: " + p1L.MovementSpeed();
        stats.text += "\nPlayer1Right: " + p1R.MovementSpeed();
        stats.text += "\nPlayer2Left: " + p2L.MovementSpeed();
        stats.text += "\nPlayer2Right: " + p2R.MovementSpeed();

        if (isPlayState)
        {
            PlayerInput();
            DisplayText();
            if (!stopTime)
                StartTimer();
        }
        if (timer <= 0)
        {
            isPlayState = false;
            stopTime = true;
            DisplayText();
            if (goal1.GoalCount() < goal2.GoalCount())
            {
                //player2 wins
                winText.text = "Player 2 wins!";
            }
            else if (goal1.GoalCount() > goal2.GoalCount())
            {
                //player1 wins
                winText.text = "Player 1 wins!";
            }
            else
            {
                winText.text = "It's a tie!";
            }
        }

        //reset game when space is pressed
        if (Input.GetButtonDown("Player1Back") || Input.GetButtonDown("Player2Back"))
        {
            Application.LoadLevel(0);
        }
    }

    void PlayerInput()
    {
        p1LhAxis = Input.GetAxis("Player1LeftHorizontal");
        p1LvAxis = Input.GetAxis("Player1LeftVertical");
        p1RhAxis = Input.GetAxis("Player1RightHorizontal");
        p1RvAxis = Input.GetAxis("Player1RightVertical");
        p2LhAxis = Input.GetAxis("Player2LeftHorizontal");
        p2LvAxis = Input.GetAxis("Player2LeftVertical");
        p2RhAxis = Input.GetAxis("Player2RightHorizontal");
        p2RvAxis = Input.GetAxis("Player2RightVertical");

        /*Debug.Log("Player1LeftHorizontal:" + p1LhAxis);
        Debug.Log("Player1LeftVertical:" + p1LvAxis);
        Debug.Log("Player1RightHorizontal:" + p1RhAxis);
        Debug.Log("Player1RightVertical:" + p1RvAxis);
        Debug.Log("Player2LeftHorizontal:" + p2LhAxis);
        Debug.Log("Player2LeftVertical:" + p2LvAxis);
        Debug.Log("Player2RightHorizontal:" + p2RhAxis);
        Debug.Log("Player2RightHorizontal:" + p2RvAxis);
        */

        p1LTrigger = Input.GetAxis("Player1LeftTrigger");
        p1RTrigger = Input.GetAxis("Player1RightTrigger");

        p2LTrigger = Input.GetAxis("Player2LeftTrigger");
        p2RTrigger = Input.GetAxis("Player2RightTrigger");

        p1L.transform.LookAt(ball.transform);
        p1R.transform.LookAt(ball.transform);
        p2L.transform.LookAt(ball.transform);
        p2R.transform.LookAt(ball.transform);


        p1L.Move(new Vector3(p1LhAxis, 0.0f, p1LvAxis));
        p1R.Move(new Vector3(p1RhAxis, 0.0f, p1RvAxis));
        p2L.Move(new Vector3(p2LhAxis, 0.0f, p2LvAxis));
        p2R.Move(new Vector3(p2RhAxis, 0.0f, p2RvAxis));


        if (p1LTrigger != 0f && p1L.IsBallInControl())
        {
            p1L.Shoot(rbBall);
        }
        if (p1RTrigger != 0f && p1R.IsBallInControl())
        {
            p1R.Shoot(rbBall);
        }
        if (p2LTrigger != 0f && p2L.IsBallInControl())
        {
            p2L.Shoot(rbBall);
        }
        if (p2RTrigger != 0f && p2R.IsBallInControl())
        {
            p2R.Shoot(rbBall);
        }

        if (Input.GetButtonDown("Player1LeftStickClick") || !boostStarted)
        {
            boostStarted = true;
            p1L.Boost();
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                p1L.BoostEnded();
                boostTimer = boostTimerVal;
                boostStarted = false;
            }
        }

        if (Input.GetButtonDown("Player1RightStickClick"))
        {
            p1R.Boost();
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                p1R.BoostEnded();
                boostTimer = boostTimerVal;
            }
        }

        if (Input.GetButtonDown("Player2LeftStickClick"))
        {
            p2L.Boost();
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                p2L.BoostEnded();
                boostTimer = boostTimerVal;
            }
        }

        if (Input.GetButtonDown("Player2RightStickClick"))
        {
            p2R.Boost();
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                p2R.BoostEnded();
                boostTimer = boostTimerVal;
            }
        }

    }

    public void StartTimer()
    {
        timer -= Time.deltaTime;
    }

    public void ResetTimer()
    {
        timer = timerVal;
    }

    void DisplayText()
    {
        int min = Mathf.FloorToInt(timer / 60F);
        int sec = Mathf.FloorToInt(timer - min * 60);
        if (stopTime)
        {
            min = 0;
            sec = 0;
        }
        timeDisplay = string.Format("{0:0}:{1:00}", min, sec);

        timerText.text = timeDisplay;
    }

    public Vector3 BallSpawnPos1()
    {
        return ballSpawnPositions[0].transform.position;
    }

    public Vector3 BallSpawnPos2()
    {
        return ballSpawnPositions[1].transform.position;
    }
}
