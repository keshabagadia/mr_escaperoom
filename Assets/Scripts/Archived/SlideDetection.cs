using UnityEngine;

public class SlideDetection : MonoBehaviour
{
    private Vector3 startTouchPos;
    private Vector3 endTouchPos;
    public bool isSliding = false;
    public bool slideRight, slideLeft, slideUp, slideDown;

    // Adjust this threshold to control the sensitivity of the slide detection
    public float slideThreshold = 10f;

    void Update()
    {
        // Check for touch or mouse input
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPos = Input.mousePosition;
            isSliding = true;
        }

        if (isSliding && Input.GetMouseButton(0))
        {
            endTouchPos = Input.mousePosition;
            Vector3 slideVector = endTouchPos - startTouchPos;

            if (slideVector.magnitude > slideThreshold)
            {
                // Calculate the angle of the slide
                float angle = Mathf.Atan2(slideVector.y, slideVector.x) * Mathf.Rad2Deg;

                // Determine the direction of the slide based on the angle
                if (angle >= -45 && angle < 45)
                {
                    //Debug.Log("Sliding right");
                    slideRight = true;
                    slideLeft = false;
                    slideUp = false;
                    slideDown = false;
                }
                else if (angle >= 45 && angle < 135)
                {
                    Debug.Log("Sliding up");
                    slideUp = true;
                    slideDown = false;
                    slideLeft = false;
                    slideRight = false;
                }
                else if (angle >= -135 && angle < -45)
                {
                    Debug.Log("Sliding down");
                    slideUp = false;
                    slideDown = true;
                    slideLeft = false;
                    slideRight = false;
                }
                else
                {
                    Debug.Log("Sliding left");
                    slideUp = false;
                    slideDown = false;
                    slideLeft = true;
                    slideRight = false;
                }

                // You can use the direction information to handle specific actions.
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSliding = false;
            slideRight = false;
            slideLeft = false;
            slideUp = false;
            slideDown = false;
        }
    }
}
