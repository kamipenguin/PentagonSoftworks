using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private Game game;

    [SerializeField] private Rigidbody rb;

    public Text debug;

    [SerializeField]
    private float defaultSpeed = 3;
    private float speed;

    private float dashTime;
    private const float dashTimeVal = 3f;
    private bool isDashing = false;

    private Vector3 targetDirection = Vector3.zero, moveDirection = Vector3.zero, movement = Vector3.zero;

    float horizontalInput = 0f;
    float verticalInput = 0f;

    Controls controls;

    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        speed = defaultSpeed;
    }

    void FixedUpdate() {
        if(game.GameState == GameState.Playing) {
            horizontalInput = Input.GetAxis(controls._stickHorizontal);
            verticalInput = Input.GetAxis(controls._stickVertical);

            if(horizontalInput >= 0.4)
                rb.drag = 0.0f;
            else if(horizontalInput < 0.4)
                rb.drag = 1f;

            if(verticalInput >= 0.4)
                rb.drag = 0.0f;
            else if(verticalInput < 0.4)
                rb.drag = 1f;

            targetDirection = horizontalInput * transform.right + verticalInput * transform.forward; // might have to edit the transform.right but lets see if it works like this
            // debug.text = "position: " + transform.position + "\n";
            // debug.text += "targetDirection" + targetDirection + "\n";
            // debug.text += "isDashing" + isDashing + "\n";

            moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, 200 * Mathf.Deg2Rad, 1000);
            // debug.text += "moveDirection" + moveDirection;

            movement = moveDirection * 2;

            rb.AddForce(movement * speed);
        }
    }

    void Update()
    {
        if(game.GameState == GameState.Scored)
            rb.velocity = Vector3.zero;
        if(game.GameState == GameState.Playing) {
            if(isDashing) {
                // while(dashTime >= 0) {
                //     dashTime -= Time.deltaTime;
                // }
                
                if(dashTime > 0)
                    dashTime -= Time.deltaTime;

                if(dashTime <= 0) {
                    isDashing = false;
                    speed = defaultSpeed;
                }                
            }

            if(Input.GetAxis(controls._trigger) > 0.3) {
                if(!isDashing)
                    Dash();
            }

            // if(Input.GetButtonDown(controls._bumper)) {
            //     // Bumper
            // }
        }
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Ball")
            col.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - col.gameObject.transform.position) * speed);
    }

    public void AssignControls(Controls controls) {
        this.controls = controls;
    }

    public void Dash()
    {
        isDashing = true;
        dashTime = dashTimeVal;
        speed = defaultSpeed * 1.5f;
    }

    public void LookAt(Vector3 position) {
        
        Vector3 lookPos = position - this.transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 2f);
    }
}
