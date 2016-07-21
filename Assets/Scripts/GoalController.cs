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

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            goalCount++;
            SetGoalText();
            Destroy(other.gameObject);
            if (other.gameObject.transform.position.z < 0)
            {
                game.ball = (GameObject)Instantiate(Resources.Load("ball"), game.BallSpawnPos1(), Quaternion.identity);
            }
            else
            {
                game.ball = (GameObject)Instantiate(Resources.Load("ball"), game.BallSpawnPos2(), Quaternion.identity);
            }
            game.rbBall = game.ball.GetComponent<Rigidbody>();
            game.ResetPlayers();
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
