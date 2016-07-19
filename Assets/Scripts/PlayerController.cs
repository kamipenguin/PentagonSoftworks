using UnityEngine;
using System.Collections;

public enum PlayerEnum{Player1,Player2}
public enum CharacterEnum{Left,Right}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed =3f;
    
    public PlayerEnum myPlayer;
    [SerializeField]
    CharacterEnum character;
    // Use this for initialization
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        /*
        switch(myPlayer){

            case PlayerEnum.Player1: 
            if(character == CharacterEnum.Left)
            transform.position += (Input.GetAxis("HorizontalPlayer1Left")*transform.right + Input.GetAxis("VerticalPlayer1Left")*transform.forward).normalized * moveSpeed * Time.deltaTime;
            
            if(character == CharacterEnum.Right)
            transform.position += (Input.GetAxis("HorizontalPlayer1Left")*transform.right + Input.GetAxis("VerticalPlayer1Left")*transform.forward).normalized * moveSpeed * Time.deltaTime;
            break;
            case PlayerEnum.Player2: 
            if(character == CharacterEnum.Left)
            transform.position += (Input.GetAxis("HorizontalPlayer2Left")*transform.right + Input.GetAxis("VerticalPlayer2Left")*transform.forward).normalized * moveSpeed * Time.deltaTime;
            if(character == CharacterEnum.Right)
            transform.position += (Input.GetAxis("HorizontalPlayer2Left")*transform.right + Input.GetAxis("VerticalPlayer2Left")*transform.forward).normalized * moveSpeed * Time.deltaTime;
            break;
        }

        /*
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

/*using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Transform leftPlayer;
    [SerializeField]
    private Transform rightPlayer;

    private Rigidbody rbLeftPlayer;
    private Rigidbody rbRightPlayer;

    [SerializeField]
    private float force = 1000f;

    [SerializeField]
    private float speed;
    
    public void pushLeft()
    {
        print("pushleft");
    }

    public void pushRight()
    {
        print("pushright");
    }

    public void pullLeft()
    {
        print("pullleft");
    }

    public void pullRight()
    {
        print("pullright");
    }

    public void moveLeftPlayer(Vector3 direction)
    {
        rbLeftPlayer.position += direction * Time.deltaTime * speed;
    }

    public void moveRightPlayer(Vector3 direction)
    {
        rbRightPlayer.position += direction * Time.deltaTime * speed;
    }

    void Start() {
        rbLeftPlayer = leftPlayer.GetComponent<Rigidbody>();
        rbRightPlayer = rightPlayer.GetComponent<Rigidbody>();
    }

    void Update() {

        // wasd & up, left, down and right key movement

        // Player 1 moves forward with w or with the xbox controller by using the left analog stick
        if(Input.GetKey("w")) {
            leftPlayer.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        // Player 1 moves left with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("a")) {
            leftPlayer.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Player 1 moves backward with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("s")) {
            leftPlayer.Translate(Vector3.back * Time.deltaTime * speed);
        }
        // Player 1 moves right with w or with the xbox controller by using the left analog stick
        else if(Input.GetKey("d")) {
            leftPlayer.Translate(Vector3.right * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        if(Input.GetKey("up")) {
            rightPlayer.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("left")) {
            rightPlayer.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("down")) {
            rightPlayer.Translate(Vector3.back * Time.deltaTime * speed);
        }
        // Player 2 moves right with w or with the xbox controller by using the right analog stick
        else if(Input.GetKey("right")) {
            rightPlayer.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    void OnTriggerStay(Collider col)
    {
        //if(col.gameObject.CompareTag("Ball"))
        //{
        //    Debug.Log("ssfsf");
        //}
    }

    public void ForceFieldPush(GameObject gameObject) {
        Debug.Log("ForceFieldPush");
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Vector3 dir = new Vector3(0,0,0);
        rb.AddForce(dir*force);

    }
}
*/
