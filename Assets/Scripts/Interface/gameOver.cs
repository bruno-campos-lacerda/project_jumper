using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    #region Variables
    [Header("Set the gameObjects")]
    public GameObject spawner;
    public GameObject kid;
    public GameObject control;
    public Jumper jumper;
    //private PlayerControl _jumper;
    #endregion

    private void Awake() {
        //_jumper = new PlayerControl();
    }

    void Update()
    {
        if (jumper.isDead) {
            kid.gameObject.SetActive(false);
            control.gameObject.SetActive(false);
        }
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit() {
        Application.Quit();
    }
}
