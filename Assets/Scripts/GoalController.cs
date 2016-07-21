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
            if (other.gameObject.transform.position.z < -10)
            {

                Instantiate(Resources.Load("ball"), game.BallSpawnPos1(), Quaternion.identity);
            }
            else
            {

                Instantiate(Resources.Load("ball"), game.BallSpawnPos2(), Quaternion.identity);
            }
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
