using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class isBlueGoal : MonoBehaviour
{
    private int goalCount;
    public bool isGoal;
    public Text goalText;
    public GameObject ball;

    void Start()
    {
        goalCount = 0;
        SetGoalText();
        //isGoal = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            goalCount++;
            SetGoalText();
            Destroy(other.gameObject);
            Instantiate(ball, new Vector3(0.14f, 4.44f, 4.75f), Quaternion.identity);
            //isGoal = true;
        }
    }


    public void SetGoalText()
    {
        goalText.text = "Goals:" + goalCount.ToString();
    }
}
