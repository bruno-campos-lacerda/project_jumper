using UnityEngine;

public class platform : MonoBehaviour
{
    public float gravity;
    private Jumper jumper;
    private bool canCount;

    private void Start() {
        jumper = FindAnyObjectByType<Jumper>();
        canCount = true;
    }

    void Update()
    {
        transform.Translate(new Vector2(0, gravity * Time.deltaTime));
        if(transform.position.y < -16) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 6 && jumper.canTouch && canCount) {
            jumper.point++;
            canCount = false;
        }
    }
}
