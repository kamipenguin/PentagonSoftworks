using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    private int goalCount;

    [SerializeField]
    private Text goalText;

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
        }
    }

    void SetGoalText()
    {
        goalText.text = "Goals:" + goalCount.ToString();
    }
}
