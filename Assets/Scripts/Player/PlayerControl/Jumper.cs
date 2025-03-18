using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Jumper : MonoBehaviour {
    public int point;
    public int highScore;
    public TextMeshProUGUI count;
    public TextMeshProUGUI highCount;

    public GameObject isOver;
    //public GameObject right, left;

    public float speed, jumpForce;
    public bool isDead;
    public bool canTouch, canJump, canMove;
    private bool isLeft, isRight;
    private Rigidbody2D rb;

    private PlayerControl jumper;

    private void Awake() {
        canMove = true;
        jumper = new PlayerControl();
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        highCount.text = PlayerPrefs.GetInt("HighScore1P").ToString();
        highScore = PlayerPrefs.GetInt("HighScore1P");
    }

    private void OnEnable() {
        jumper.Enable();
    }

    private void OnDisable() {
        jumper.Disable();
    }

    void Update() {
        float direction = Input.GetAxis("Horizontal") * speed;

        float move = jumper.Player1.Movement.ReadValue<float>() * speed;
        float jump = jumper.Player1.Jump.ReadValue<float>();

        if (canMove) {
            rb.velocity = new Vector2(move, rb.velocity.y);
        }
        VelocityCalculator();
        count.text = point.ToString();
        if (highScore < point) {
            highScore = point;
        }
        highCount.text = highScore.ToString();
        PlayerPrefs.SetInt("HighScore1P", highScore);

        /*if (isRight) {
            Right();
        }
        if (isLeft) {
            Left();
        }*/
        if(canJump && jump >= 1) {
            canJump = false;
            rb.velocity = new Vector2(0, jumpForce * 1.5f);
        }
    }

    private void VelocityCalculator() {
        if (transform.position.y > 12.5) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * -.5f);
        }
        /*if(transform.position.x < -19) {
            canMove = false;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (transform.position.x > 19) {
            canMove = false;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }*/
        if (transform.position.y < -16) {
            isDead = true;
            isOver.gameObject.SetActive(true);
        }
        if (rb.velocity.y <= 0) {
            canTouch = true;
        } else {
            canTouch = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 3 && canTouch) {
            canMove = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if(collision.gameObject.layer == 7 && canTouch) {
            canMove = true;
            canJump = true;
            gameObject.transform.parent = collision.transform;
        }
        if(collision.gameObject.CompareTag("Player")) {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == 7) {
            canJump = false;
            gameObject.transform.parent = null;
        }
    }

    /*public void Left(bool canTouch = true) {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        right.gameObject.SetActive(canTouch);
        if (!canTouch) {
            isLeft = true;
        } else {
            isLeft = false;
        }
    }
    public void Right(bool canTouch = true) {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        left.gameObject.SetActive(canTouch);
        if (!canTouch) {
            isRight = true;
        } else {
            isRight = false;
        }
    }*/
}
