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

    void Start()
    {
        goalCount = 0;
        SetGoalText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            goalCount++;
            SetGoalText();
            Destroy(other.gameObject);
            if (other.gameObject.transform.position.z < -8)
            {
                game.ball = (GameObject)Instantiate(Resources.Load("ball"), game.BallSpawnPos2(), Quaternion.identity);
            }
            else
            {
                game.ball = (GameObject)Instantiate(Resources.Load("ball"), game.BallSpawnPos1(), Quaternion.identity);
            }
            game.rbBall = game.ball.GetComponent<Rigidbody>();
            game.ResetPlayers();
            Debug.Log("goal location" + other.gameObject.transform.position.z);
            Debug.Log("ballspawnpos1" + game.BallSpawnPos1());
            Debug.Log("ballSpawnPos2" + game.BallSpawnPos2());
        }
    }

    void SetGoalText()
    {
        goalText.text = "Goals:" + goalCount.ToString();
    }

    public int GoalCount()
    {
        return goalCount;
    }
}
