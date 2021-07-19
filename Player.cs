using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private const float LANE_DISTANCEL = 2.5f;
    private const float LANE_DISTANCER = 3.3f;
    public const float TURN_SPEED = 0.07f;

    public GameObject player;
    Touch touch;
    bool swiped = false;

    public Vector3 moveVector;
    public Vector3 jmp;
    public Vector3 targetPosition;

    public AudioSource coinClick;
    public AudioClip coinPick;

    public ParticleSystem shieldWaves;

    public int score;
    public Text PlayerScore;
    public Text ScorePointsText;

    public GameObject GameOver;

    //Animation
    private Animator anim;

    //Movement
    private CharacterController controller;
    private float verticalVelocity;
    private float speed = 11.0f;
    private Lane desiredLane; // 0 = Left, 1 = Middle, 2 = Right

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        coinClick = GetComponent<AudioSource>();
        desiredLane = Lane.Middle;
        
    }

    private void Update()
    {
        InputBehavior();
       
        CalculatePlayerPosition();

        CalculateMoveDelta();

        SetPlayerMovement();

        SetPlayerRotation();
    }

    void InputBehavior()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                touch = t;
            }
            else if (t.phase == TouchPhase.Moved && !swiped)
            {
                float xMoved = touch.position.x - t.position.x;
                float yMoved = touch.position.y - t.position.y;
                float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));
                bool swipedLeft = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                if (distance > 50f)
                {
                    if (swipedLeft && xMoved > 0)
                    {
                        MoveLane(false);
                    }
                    else if (swipedLeft && xMoved < 0)
                    {
                        MoveLane(true);
                    }
                    else if (swipedLeft == false && yMoved > 0)
                    {
                        anim.SetBool("Sliding", true);
                        Invoke("stopSliding", 0.1f);
                    }
                    else if (swipedLeft == false && yMoved < 0)
                    {
                        anim.SetBool("Jumping", true);
                        Invoke("stopJumping", 0.1f);
                    }
                    swiped = true;
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                touch = new Touch();
                swiped = false;
            }
        }
    }

    void CalculatePlayerPosition()
    {
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == Lane.Left)
        {
            targetPosition += Vector3.left * LANE_DISTANCEL;
        }
        else if (desiredLane == Lane.Right)
        {
            targetPosition += Vector3.right * LANE_DISTANCER;
        }
    }

    void CalculateMoveDelta()
    {
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;
    }

    void SetPlayerMovement()
    {
        controller.Move(moveVector * Time.deltaTime);
    }

    void SetPlayerRotation()
    {
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }
    }

    void stopJumping()
    {
        anim.SetBool("Jumping", false);
    }

    void stopSliding()
    {
        anim.SetBool("Sliding", false);
    }

    private void MoveLane(bool goingRight)
    {
        if ((desiredLane == Lane.Left && !goingRight) || 
            (desiredLane == Lane.Right && goingRight)) return;
        else
            desiredLane += (goingRight) ? 1 : -1;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "coin")
        {
            coinClick.PlayOneShot(coinPick);
            Destroy(hit.gameObject);
            score = score + 5;
            PlayerScore.text = "Score: " + score.ToString();
        }

        if (hit.transform.tag == "Attraction")
        {
            Destroy(hit.gameObject);
            score = score + 250;
            PlayerScore.text = "Score: " + score.ToString();
        }

        if (hit.transform.tag == "enemy")
        {
            anim.SetBool("Death", true);
            GameOver.SetActive(true);
            ScorePointsText.text = score.ToString();
            Time.timeScale = 0f;
        }

        if(hit.transform.tag == "Shield")
        {
            shieldWaves.Play();
        }
    }
}

public enum Lane
{
    Left, Middle, Right
}