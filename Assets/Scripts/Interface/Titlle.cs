using UnityEngine;

public class Titlle : MonoBehaviour {
    [Header("Atributes")]
    public GameObject canvas;
    //public GameObject control;

    [Space(10)]
    [Header("Conditions to start the game")]
    public bool start, p1CanStart, p2CanStart;
    public int isReady;

    void Start() {
        Time.timeScale = 0;
        isReady = 0;
        start = false;
        p1CanStart = true;
        p2CanStart = true;
    }

    private void Update() {
        if(isReady >= 2) {
            start = true;
        }
        if (start == true) {
            Time.timeScale = 1;
            canvas.gameObject.SetActive(false);
            //control.gameObject.SetActive(true);
        }
    }

    public void Player1IsReady() {
        if (p1CanStart == true) {
            isReady++;
            p1CanStart = false;
        }
    }

    public void Player2IsReady() {
        if (p2CanStart) {
            isReady++;
            p2CanStart = false;
        }
    }

    public void Exit() {
        Application.Quit();
    }
}
