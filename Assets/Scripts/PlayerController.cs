using UnityEngine;
using System.Collections;

// public enum PlayerEnum{Player1,Player2}
// public enum CharacterEnum{Left,Right}

public class PlayerController : MonoBehaviour
{
    //public PlayerEnum myPlayer;
    //[SerializeField]
    //public CharacterEnum character;
    // Use this for initialization

    public void Move(Vector3 position)
    {
        this.gameObject.transform.position += position;
    }

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
