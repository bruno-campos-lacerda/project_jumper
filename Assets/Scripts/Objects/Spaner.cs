using UnityEngine;
using UnityEngine.UIElements;

public class Spaner : MonoBehaviour {

    #region Variables
    [Header("Time for spaw the next plataform")]
    [Range(0, 1)]
    public float timer;
    private float _timer;

    [Space(10)]
    [Header("Set the max distance for plataform spaw")]
    [Min(10)]
    public float maxDistance;
    private Vector3 position;

    [Space(10)]
    [Header("Set the possibility foreach plataform spaw")]
    [SerializeField] private GameObject[] platform;
    #endregion

    private void Awake() {
        _timer = 0;
    }

    void Update() {
        _timer -= Time.deltaTime;
        if (_timer < 0) {
            SpawPlataform();
            _timer = timer;
        }
    }

    void SpawPlataform() {
        position = transform.position + new Vector3(Random.Range(-maxDistance, maxDistance), 0);
        int random = Random.Range(0, platform.Length);
        Instantiate(platform[random], position, Quaternion.identity);
    }
}
