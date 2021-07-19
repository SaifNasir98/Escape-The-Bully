using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    public GameObject player;
    Touch touch;
    bool swiped = false;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTouch();
    }

    void CalculateTouch()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                touch = t;
            }
            else if (t.phase == TouchPhase.Moved && !swiped)
            {
                CalculateTouchMove();
            }
            else if (t.phase == TouchPhase.Ended)
            {
                CalculateTouchEnd();
            }
        }
    }

    void CalculateTouchMove()
    {
        float xMoved = touch.position.x - t.position.x;
        float yMoved = touch.position.y - t.position.y;
        float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));
        bool swipedLeft = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

        if (distance > 50f)
        {
            if (swipedLeft && xMoved > 0)
            {
                player.transform.Translate(-2.5f, 0, 0);
            }
            else if (swipedLeft && xMoved < 0)
            {
                player.transform.Translate(3.5f, 0, 0);
            }
            else if (swipedLeft == false && yMoved > 0)
            {
                animator.SetBool("Sliding", true);
                Invoke("stopSliding", 0.1f);
            }
            else if (swipedLeft == false && yMoved < 0)
            {
                animator.SetBool("Jumping", true);
                Invoke("stopJumping", 0.1f);
            }
            swiped = true;
        }
    }

    void CalculateTouchEnd()
    {
        touch = new Touch();
        swiped = false;
    }

    void stopJumping()
    {
        animator.SetBool("Jumping", false);
    }

    void stopSliding()
    {
        animator.SetBool("Sliding", false);
    }
}
