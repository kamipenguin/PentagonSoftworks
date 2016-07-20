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
        player2 = GameObject.FindWithTag("player2").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("joystick 1 button 4"))
            player1.pushLeft();

        if (Input.GetKey("joystick 1 button 5"))
            player1.pushRight();

        if (Input.GetKey("joystick 2 button 4"))
            player2.pushLeft();

        if (Input.GetKey("joystick 2 button 5"))
            player2.pushRight();

        /*if (Input.GetAxis("Player1PullLeft") == 1)
            player1.pullLeft();


        if (Input.GetAxis("Player1PullRight") == 1)
            player1.pullRight();*/

        if (Mathf.Round(Input.GetAxis("HorizontalPlayer1Left")) != 0 || Mathf.Round(Input.GetAxis("VerticalPlayer1Left")) != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalPlayer1Left"), 0, 
                -Input.GetAxis("VerticalPlayer1Left")) * Time.deltaTime;

            player1.moveLeft(direction);
        }

        if (Mathf.Round(Input.GetAxis("HorizontalPlayer1Right")) != 0 || Mathf.Round(Input.GetAxis("VerticalPlayer1Right")) != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalPlayer1Right"), 0,
                -Input.GetAxis("VerticalPlayer1Right")) * Time.deltaTime;

            player1.moveRight(direction);
        }


        if (Mathf.Round(Input.GetAxis("HorizontalPlayer2Left")) != 0 || Mathf.Round(Input.GetAxis("VerticalPlayer2Left")) != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalPlayer2Left"), 0,
                -Input.GetAxis("VerticalPlayer2Left")) * Time.deltaTime;

            player2.moveLeft(direction);
        }

        if (Mathf.Round(Input.GetAxis("HorizontalPlayer2Right")) != 0 || Mathf.Round(Input.GetAxis("VerticalPlayer2Right")) != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalPlayer2Right"), 0,
                -Input.GetAxis("VerticalPlayer2Right")) * Time.deltaTime;

            player2.moveRight(direction);
        }

    }
}