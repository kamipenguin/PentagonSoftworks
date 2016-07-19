using UnityEngine;
using System.Collections;

public class GoalMechanism : MonoBehaviour
{
    public isOrangeGoal orangeGoal;
    public isBlueGoal blueGoal;

    // Use this for initialization
    void Start()
    {
        orangeGoal = gameObject.AddComponent<isOrangeGoal>();
        blueGoal = gameObject.AddComponent<isBlueGoal>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BallSpawn()
    {
    }
}
