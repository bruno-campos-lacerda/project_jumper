using UnityEngine;

[CreateAssetMenu(fileName = "Name your new character", menuName = "Player", order = 0)]
public class SelectYourJumper : ScriptableObject {

    [Header("Set the genaral features to the character")]
    [Tooltip("Character's name")]
    public string participantName;
    [Tooltip("Character's sprite")]
    public Sprite appearance;

    [Space(15)]

    [Header("Set the primary status")]
    [Range(10, 30), Tooltip("Set the speed in x")]
    public float speed;
    [Range(10, 40), Tooltip("Set the force in y")]
    public float jummpForce;
}
