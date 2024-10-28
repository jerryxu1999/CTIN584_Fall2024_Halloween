using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;
    [SerializeField]
    private int hitCounter = 0;
    public bool player1Start = true;

    private Rigidbody rb;


    void Start()
    {
        rb  = GetComponent<Rigidbody>();
        StartCoroutine(LaunchBall());
    }


    public IEnumerator LaunchBall()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if (player1Start) {
            MoveBall(new Vector3(-1, 0, 0));
        } else
        {
            MoveBall(new Vector3(1, 0, 0));
        }
    }

    public void MoveBall(Vector3 dir) {
        dir = dir.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        rb.velocity = dir * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

    private void RestartBall()
    {
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(0, 0, 0);
    }
   
}
