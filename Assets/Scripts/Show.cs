using System.Collections;
using UnityEngine;

public class Show : MonoBehaviour
{    void Start()
    {
        gameObject.SetActive(Application.isMobilePlatform);
    }
}
