using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameObject spawner;
    public GameObject kid;
    public GameObject control;
    public Jumper jumper;
    private JumperMobile _jumper;

    private void Awake() {
        _jumper = new JumperMobile();
    }

    void Update()
    {
        if (jumper.isDead) {
            kid.gameObject.SetActive(false);
            spawner.gameObject.SetActive(false);
            control.gameObject.SetActive(false);
            if (_jumper.Defalt.Game.ReadValue<float>() >= 1) {
                //restart();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit() {
        Application.Quit();
    }
}
