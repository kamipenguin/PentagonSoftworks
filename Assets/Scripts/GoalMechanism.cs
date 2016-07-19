using UnityEngine;
using System.Collections;

public class GoalMechanism : MonoBehaviour
{
    public isOrangeGoal orangeGoal;
    public isBlueGoal blueGoal;
    public GameObject ball;

    // Use this for initialization
    void Start()
    {
        //orangeGoal = gameObject.AddComponent<isOrangeGoal>();
        //blueGoal = gameObject.AddComponent<isBlueGoal>();
        orangeGoal = new isOrangeGoal();
        blueGoal = new isBlueGoal();
    }

    // Update is called once per frame
    void Update()
    {
        BallSpawn();
    }

    void BallSpawn()
    {
        if (blueGoal.isGoal)
        {
            //spawn ball at orange goal
            Instantiate(ball, new Vector3(0.14f, 4.44f, 4.75f), Quaternion.identity);
            blueGoal.isGoal = false;
        }

        else if (orangeGoal.isGoal)
        {
            //spawn ball at blue goal
            Instantiate(ball, new Vector3(0.14f, 4.44f, -4.75f), Quaternion.identity);
            orangeGoal.isGoal = false;
        }
    }
}
