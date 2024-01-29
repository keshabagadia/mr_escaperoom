using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float distanceToMove=0.1f;
    private Vector3 startTouchPos;
    private Vector3 endTouchPos;
    private Vector3 targetPosition;

    private bool isMoving = false;
    public bool isSliding = false;
    public bool slidingRight, slidingLeft, slidingUp, slidingDown;
    public float slideThreshold = 1f;

    private GameObject controller;

    private ImageInfo imageInfo;
    private TileInfo connectedTileInfo;

    private void Start()
    {
        imageInfo = GetComponent<ImageInfo>();
    }
    void Update()
    {
        //checkSliding();
        moveIfPossible();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controller = other.gameObject;
            startTouchPos = other.transform.position;
            isSliding = true;
            slidingRight = true;
            slidingLeft = true;
            slidingUp = true;
            slidingDown = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            controller = null;
            isSliding = false;
            slidingRight = false;
            slidingLeft = false;
            slidingUp = false;
            slidingDown = false;
        }
    }

    private void checkSliding()
    {
        if (isSliding)
        {
            endTouchPos = controller.transform.position;
            Vector3 slideVector = endTouchPos - startTouchPos;
            Debug.Log("slide " + slideVector.magnitude);
            if (slideVector.magnitude > slideThreshold)
            {
                // Calculate the angle of the slide
                float angle = Mathf.Atan2(slideVector.y, slideVector.x) * Mathf.Rad2Deg;

                Debug.Log("threshold overcome " + angle);

                // Determine the direction of the slide based on the angle
                if (angle >= -45 && angle < 45)
                {
                    Debug.Log("Sliding right");
                    slidingRight = true;
                    slidingLeft = false;
                    slidingUp = false;
                    slidingDown = false;
                }
                else if (angle >= 45 && angle < 135) //as image tiles are upside down
                {
                    Debug.Log("Sliding up");
                    slidingUp = true;
                    slidingDown = false;
                    slidingLeft = false;
                    slidingRight = false;
                }
                else if (angle >= -135 && angle < -45)
                {
                    Debug.Log("Sliding down");
                    slidingUp = false;
                    slidingDown = true;
                    slidingLeft = false;
                    slidingRight = false;
                }
                else
                {
                    Debug.Log("Sliding left");
                    slidingUp = false;
                    slidingDown = false;
                    slidingLeft = true;
                    slidingRight = false;
                }
            }

        }
    }

    private void moveIfPossible()
    {
        if (isSliding)
        {
            connectedTileInfo = imageInfo.connectedTile.GetComponent<TileInfo>();
            if (slidingRight && imageInfo.canSlideRight)
            {
                targetPosition = connectedTileInfo.rightTile.transform.position + new Vector3(0, 0f, -0.01f);
                Debug.Log("problem is with move" + targetPosition);
                Move();
            }
            if (slidingLeft && imageInfo.canSlideLeft)
            {
                targetPosition = connectedTileInfo.leftTile.transform.position + new Vector3(0, 0f, -0.01f);
                Debug.Log("problem is with move" + targetPosition);
                Move();
            }
            if (slidingUp && imageInfo.canSlideUp)
            {
                targetPosition = connectedTileInfo.topTile.transform.position + new Vector3(0, 0f, -0.01f);
                Move();
            }
            if (slidingDown && imageInfo.canSlideDown)
            {
                targetPosition = connectedTileInfo.bottomTile.transform.position + new Vector3(0, 0f, -0.01f);
                Move();
            }
        }

    }

    public void Move()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToTargetPosition());
        }
    }

    private IEnumerator MoveToTargetPosition()
    {
        isMoving = true;
        float startTime = Time.time;
        Vector3 startPosition = transform.position;

        while (Time.time - startTime < distanceToMove / moveSpeed)
        {
            float journeyLength = Time.time - startTime;
            float distanceCovered = journeyLength * moveSpeed;
            float fractionOfJourney = distanceCovered / (distanceToMove);

            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }

        // Ensure that the object reaches the exact target position.
        transform.position = targetPosition;

        isMoving = false;
    }

    /*private IEnumerator MoveToTargetPosition()
    {
        while (isMoving)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, step);

            // Check if the object has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Snap to the exact target position and stop moving when the object reaches the target position
                transform.position = targetPosition;
                isMoving = false;
            }
            yield return null;
        }
    }*/


}