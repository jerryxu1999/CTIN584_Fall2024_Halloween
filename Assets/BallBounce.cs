using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public BallMovement movement;

    private void BounceBall(Collision collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.z;

        float positionX = 0;

        if(collision.gameObject.name == "PongPlayer1")
        {
            positionX = 1;
        } else if(collision.gameObject.name == "PongPlayer2")
        {
            positionX = -1;
        }

        float positionY = (ballPosition.z - racketPosition.z) / racketHeight;

        movement.IncreaseHitCounter();
        movement.MoveBall(new Vector3(positionX, 0, positionY));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            BounceBall(collision);
        } else if(collision.gameObject.name == "LeftBoundary")
        {
            movement.player1Start = true;
            StartCoroutine(movement.LaunchBall());
        } else if(collision.gameObject.name == "RightBoundary")
        {
            movement.player1Start = false;
            StartCoroutine(movement.LaunchBall());
        }
    }
}
