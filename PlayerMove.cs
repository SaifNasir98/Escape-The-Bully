using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public CharacterController controllerPlayer;
    public float speed = 6f;

    public int score;
    public Text PlayerScore;
    public Text ScorePointsText;

    public GameObject GameOver;

    private Animator animator;

    public Vector3 mov;

    private const float jumpPower = 22f;

    // Use this for initialization
    void Start () {

        controllerPlayer = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {

        Move();
        InputCheckJump();
        InputCheckSlide();

    }

    void Move()
    {
        controllerPlayer.Move(GetMovementValue() * Time.deltaTime);
    }

    Vector3 GetMovementValue()
    {
        return new Vector3(SimpleInput.GetAxis("Horizontal") * speed, -2.9f, 6f);
    }

    void InputCheckJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            controllerPlayer.Move(Vector3.up * jumpPower * Time.deltaTime);
            animator.SetBool("Jumping", true);
            Invoke("stopJumping", 0.1f);
        }
    }

    void InputCheckSlide()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("Sliding", true);
            Invoke("stopSliding", 0.1f);
        }
    }

    void stopJumping()
    {
        animator.SetBool("Jumping", false);
    }

    void stopSliding()
    {
        animator.SetBool("Sliding", false);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "coin")
        {
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
            GameOver.SetActive(true);
            ScorePointsText.text = score.ToString();
            Time.timeScale = 0f;
        }
    }
            
}
