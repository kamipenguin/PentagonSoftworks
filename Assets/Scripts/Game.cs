using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState {
    Paused,
    Playing,
    Scored,
    Finished,
    Init
}

public struct Controls {
    public string _stickHorizontal;
    public string _stickVertical;
    public string _trigger;

    public Controls(string stickHorizontal, string stickVertical, string trigger) {
        _stickHorizontal = stickHorizontal;
        _stickVertical = stickVertical;
        _trigger = trigger;
    }
}

public class Game : MonoBehaviour
{
    private GameState state = GameState.Init;

    [SerializeField] Text p1LText;
    [SerializeField] Text p1RText;
    [SerializeField] Text p2LText;
    [SerializeField] Text p2RText;

    Controls p1LControls = new Controls("P1_LEFT_STICK_X", "P1_LEFT_STICK_Y", "P1_LEFT_TRIGGER");
    Controls p1RControls = new Controls("P1_RIGHT_STICK_X", "P1_RIGHT_STICK_Y", "P1_RIGHT_TRIGGER");
    Controls p2LControls = new Controls("P2_LEFT_STICK_X", "P2_LEFT_STICK_Y", "P2_LEFT_TRIGGER");
    Controls p2RControls = new Controls("P2_RIGHT_STICK_X", "P2_RIGHT_STICK_Y", "P2_RIGHT_TRIGGER");

    [SerializeField]
    private Material p1Mat, p2Mat;

    [SerializeField]
    private Transform player1LeftSpawn, player1RightSpawn, player2LeftSpawn, player2RightSpawn;

    [SerializeField]
    private Text winText;

    [SerializeField]
    private Text stats;

    //timer variables
    [SerializeField]
    private Text timerText;

    [SerializeField]
    private Sprite leftIcon, rightIcon; // Could make it 4+ if we need to

    private GameObject ball;
    private Rigidbody rbBall;

    private GameObject[] ballSpawnPositions;
    
    //make private
    private GameObject p1L, p1R, p2L, p2R;
    private Character p1LCharacter, p1RCharacter, p2LCharacter, p2RCharacter;

    private bool isPlayState;

    public GoalController goal1, goal2;

    private string timeDisplay;

    private bool stopTime = false;

    private static float timerVal = 181F;
    private static float timer;

    void Start()
    {
        // Create the ball at either the player 1 side or player 2 side of the field
        ballSpawnPositions = GameObject.FindGameObjectsWithTag("BallSpawnPoint");
        SpawnBall(ballSpawnPositions[Random.Range(0, 2)].transform.position);

        // Player 1
        // Left Character
        p1L = Instantiate(Resources.Load("CharacterBall"), player1LeftSpawn.position, Quaternion.identity) as GameObject;
        p1LCharacter = p1L.GetComponent<Character>();
        p1LCharacter.AssignControls(p1LControls);
        p1L.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = leftIcon;
        p1L.transform.GetChild(1).GetComponent<Renderer>().material = player1LeftSpawn.GetComponent<Renderer>().material;
        // p1LCharacter.debug = p1LText;

        // Right Character
        p1R = Instantiate(Resources.Load("CharacterBall"), player1RightSpawn.position, Quaternion.identity) as GameObject;
        p1RCharacter = p1R.GetComponent<Character>();
        p1RCharacter.AssignControls(p1RControls);
        p1R.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = rightIcon;
        p1R.transform.GetChild(1).GetComponent<Renderer>().material = player1RightSpawn.GetComponent<Renderer>().material;
        // p1RCharacter.debug = p1RText;

        // Player 2
        // Left
        p2L = Instantiate(Resources.Load("CharacterBall"), player2LeftSpawn.position, Quaternion.identity) as GameObject;
        p2LCharacter = p2L.GetComponent<Character>();
        p2LCharacter.AssignControls(p2LControls);
        p2L.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = leftIcon;
        p2L.transform.GetChild(1).GetComponent<Renderer>().material = player2LeftSpawn.GetComponent<Renderer>().material;
        // p2LCharacter.debug = p2LText;

        // Right
        p2R = Instantiate(Resources.Load("CharacterBall"), player2RightSpawn.position, Quaternion.identity) as GameObject;
        p2RCharacter = p2R.GetComponent<Character>();
        p2RCharacter.AssignControls(p2RControls);
        p2R.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = rightIcon;
        p2R.transform.GetChild(1).GetComponent<Renderer>().material = player2RightSpawn.GetComponent<Renderer>().material;
        // p2RCharacter.debug = p2RText;


        // Solo Testing
        // p1LCharacter.LookAt(p1R.transform.position);
        // p1RCharacter.LookAt(p1L.transform.position);

        p1LCharacter.LookAt(p2L.transform.position);
        p1RCharacter.LookAt(p2R.transform.position);
        p2LCharacter.LookAt(p1L.transform.position);
        p2RCharacter.LookAt(p1R.transform.position);

        timer = timerVal;
        isPlayState = true;

        state = GameState.Playing;
    }

    public void SpawnBall(Vector3 pos) {
        ball = (GameObject) Instantiate(Resources.Load("ball"), pos, Quaternion.identity);
    }

    public void ResetPlayers() {
        p1L.transform.position = player1LeftSpawn.position;
        p1L.transform.GetChild(1).transform.position = player1LeftSpawn.position;

        p1R.transform.position = player1RightSpawn.position;
        p1R.transform.GetChild(1).transform.position = player1RightSpawn.position;

        p2L.transform.position = player2LeftSpawn.position;
        p2L.transform.GetChild(1).transform.position = player2LeftSpawn.position;


        p2R.transform.position = player2RightSpawn.position;
        p2R.transform.GetChild(1).transform.position = player2RightSpawn.position;
    }

    void Update()
    {
        if(state == GameState.Playing)
        {
            DisplayText();

            if(!stopTime) 
            {
                StartTimer();
            }

            if(timer <= 0)
            {
                state = GameState.Finished;
                stopTime = true;
                DisplayText();

                if (goal1.GoalCount() < goal2.GoalCount())
                {
                 //player2 wins
                    winText.text = "Blue Player Wins!";
                }

                else if (goal1.GoalCount() > goal2.GoalCount())
                {
                 //player1 wins
                 winText.text = "Red Player Wins!";
                }

                else
                {
                    winText.text = "It's a tie!";
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.JoystickButton9)) {
            // Pause
            if(state == GameState.Paused)
                UnPause();
            else if(state == GameState.Playing)
                Pause();        
        }
        if(Input.GetKeyDown(KeyCode.JoystickButton10))
            SceneManager.LoadScene(0);

    }

    public void StartTimer()
    {
        timer -= Time.deltaTime;
    }

    void Pause() {
        state = GameState.Paused;

        p1L.transform.GetChild(1).GetComponent<Rigidbody>().velocity = Vector3.zero;
        p1R.transform.GetChild(1).GetComponent<Rigidbody>().velocity = Vector3.zero;
        p2L.transform.GetChild(1).GetComponent<Rigidbody>().velocity = Vector3.zero;
        p2R.transform.GetChild(1).GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void UnPause() {
        state = GameState.Playing;
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

    public void SetPlayerActive()
    {
        p1L.SetActive(true);
        p1R.SetActive(true);
        p2L.SetActive(true);
        p2R.SetActive(true);
        ball.SetActive(true);
    }

    public void SetPlayerInactive()
    {
        p1L.SetActive(false);
        p1R.SetActive(false);
        p2L.SetActive(false);
        p2R.SetActive(false);
        ball.SetActive(false);
    }

    public Vector3 BallSpawnPos1()
    {
        return ballSpawnPositions[0].transform.position;
    }

    public Vector3 BallSpawnPos2()
    {
        return ballSpawnPositions[1].transform.position;
    }

    public bool IsPlayState
    {
        set { isPlayState = value; }
    }

    public GameState GameState
    {
        get { return state; }
        set { state = value; }
    }
}