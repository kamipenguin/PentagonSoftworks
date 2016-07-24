using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    private int goalCount;

    [SerializeField]
    private Text goalText;

    [SerializeField]
    private Game game;

    private float waitTimeVal = 4F;
    private float waitTime;
    [SerializeField]
    private Text countDown;
    private bool betweenGoals = false;

    void Start()
    {
        goalCount = 0;
        SetGoalText();
    }

    void Update()
    {
        if (betweenGoals)
        {
            game.SetPlayerInactive();
            int min = Mathf.FloorToInt(waitTime / 60F);
            int sec = Mathf.FloorToInt(waitTime - min * 60);
            countDown.text = sec.ToString();
            waitTime -= Time.deltaTime * 1.5f;
            if (waitTime <= 1)
            {
                game.GameState = GameState.Playing;
                countDown.text = "";
                betweenGoals = false;
                game.SetPlayerActive();
                game.ResetPlayers();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            game.GameState = GameState.Scored;
            goalCount++;
            SetGoalText();
            Destroy(other.gameObject);
            BetweenGoalTime();
            if (other.gameObject.transform.position.z < 0)
            {
                game.SpawnBall(game.BallSpawnPos1());
            }
            else
            {
                game.SpawnBall(game.BallSpawnPos2());
            }
        }
    }

    void BetweenGoalTime()
    {
        waitTime = waitTimeVal;
        betweenGoals = true;
    }

    void SetGoalText()
    {
        goalText.text = "Goals: " + goalCount.ToString();
    }

    public int GoalCount()
    {
        return goalCount;
    }
}
