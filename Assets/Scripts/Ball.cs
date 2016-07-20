using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Rigidbody body;
    public bool pull = false;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void pulling(Vector3 targetPos)
    {
        if(pull)
        {
            body.AddForce(Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 5));
        }
    }

    public void push(Transform target)
    {
        body.AddForce(target.TransformDirection(Vector3.forward) * Time.deltaTime * 100);
    }
}
