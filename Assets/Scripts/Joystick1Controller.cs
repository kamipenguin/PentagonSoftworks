using UnityEngine;
using System.Collections;

public class Joystick1Controller : MonoBehaviour
{
    [SerializeField]
    private PlayerController player1;
    
    // Use this for initialization
    void Start() {}

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
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalPlayer1Left"), 0, 
                -Input.GetAxis("VerticalPlayer1Left")) * Time.deltaTime;

            player1.moveLeftPlayer(direction);
        }

        if (Input.GetAxis("HorizontalPlayer1Right") != 0 || Input.GetAxis("VerticalPlayer1Right") != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalPlayer1Right"), 0,
                -Input.GetAxis("VerticalPlayer1Right")) * Time.deltaTime;

            player1.moveRightPlayer(direction);
        }

        //print(Input.GetAxis("player1FireLeft"));
        //print(Input.GetAxis("player1FireRight"));
        /*print(Input.GetAxis("player2FireLeft"));
        print(Input.GetAxis("player2FireRight"));*/

    }
}