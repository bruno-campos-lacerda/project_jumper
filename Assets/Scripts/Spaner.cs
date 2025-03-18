using UnityEngine;
using UnityEngine.UIElements;

public class Spaner : MonoBehaviour {
    public float timer;
    private float _timer;
    public float maxDistance;
    [SerializeField] private GameObject[] platform;
    private Vector3 position;

    private void Awake() {
        _timer = 0;
    }

    void Update() {
        _timer -= Time.deltaTime;
        if (_timer < 0) {
            SpawPlataform();
            position = transform.position + new Vector3(Random.Range(-maxDistance, maxDistance), 0);
            _timer = timer;
        }
    }

    void SpawPlataform() {
        position = transform.position + new Vector3(Random.Range(-maxDistance, maxDistance), 0);
        int random = Random.Range(0, platform.Length);
        Instantiate(platform[random], position, Quaternion.identity);
    }
}
