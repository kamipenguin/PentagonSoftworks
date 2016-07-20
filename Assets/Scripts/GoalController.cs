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

    }

    void SetGoalText()
    {
        goalText.text = "Goals:" + goalCount.ToString();
    }
}
