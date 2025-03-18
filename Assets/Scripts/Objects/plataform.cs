using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class plataform : MonoBehaviour {
    public float gravity;
    private Jumper jumper;
    private Jumper2 jumper2;
    private ParticleSystem particle;
    private bool canCount;

    private void Start() {
        jumper = FindAnyObjectByType<Jumper>();
        jumper2 = FindAnyObjectByType<Jumper2>();
        particle = GetComponent<ParticleSystem>();
        canCount = true;
    }

    void Update() {
        transform.Translate(new Vector2(0, gravity * Time.deltaTime));
        if (transform.position.y < -16) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 8 && jumper.canTouch && canCount) {
            jumper.point++;
            var emission = particle.emission;
            emission.enabled = false;
            canCount = false;
        }
        if (collision.gameObject.layer == 9 && jumper2.canTouch && canCount) {
            jumper2.point++;
            var emission = particle.emission;
            emission.enabled = false;
            canCount = false;
        }
    }
}
