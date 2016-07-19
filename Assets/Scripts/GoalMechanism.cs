﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        CoinToss();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CoinToss()
    {
        float tossChance = 0.5f;

        if (Random.value < tossChance)
        {
            Instantiate(ball, new Vector3(0.14f, 4.44f, 4.75f), Quaternion.identity);
        }
        else
        {
            Instantiate(ball, new Vector3(0.14f, 4.44f, -4.75f), Quaternion.identity);
        }
    }
}
