using UnityEngine;
using System.Collections;

public class JoystickController : MonoBehaviour
{
    private PlayerController player1;
    private PlayerController player2;
    
    
    // Use this for initialization
    void Start()
    {
        player1 = GameObject.FindWithTag("player1").GetComponent<PlayerController>();
        //player2 = GameObject.FindWithTag("player2").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button4))
            player1.pushLeft();

        if (Input.GetKey(KeyCode.Joystick1Button5))
            player1.pushRight();

        if (Input.GetAxis("Player1PullLeft") == 1)
            player1.pullLeft();


        if (Input.GetAxis("Player1PullRight") == 1)
            player1.pullRight();

        if (Input.GetAxis("HorizontalPlayer1Left") != 0 || Input.GetAxis("VerticalPlayer1Left") != 0)
            print("move");

        if (Input.GetAxis("HorizontalPlayer1Right") != 0 || Input.GetAxis("VerticalPlayer1Right") != 0)
            print("move right");

        //print(Input.GetAxis("player1FireLeft"));
        //print(Input.GetAxis("player1FireRight"));
        /*print(Input.GetAxis("player2FireLeft"));
        print(Input.GetAxis("player2FireRight"));*/

    }
}