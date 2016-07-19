using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    Vector3 player1Spawn = new Vector3(0.14f, 4.44f, 4.75f);
    Vector3 player2Spawn = new Vector3(0.14f, 4.44f, -4.75f);

    // Use this for initialization
    void Start()
    {
        CoinToss();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CoinToss()
    {
        float tossChance = 0.5f;

        if (Random.value < tossChance)
        {
            SpawnBall(player1Spawn);
        }
        else
        {
            SpawnBall(player2Spawn);
        }
    }

    public void SpawnBall(Vector3 position) {
        Instantiate(ball, position, Quaternion.identity);
    }

    public Vector3 GetPlayer1Spawn() {
        return player1Spawn;
    }

    public Vector3 GetPlayer2Spawn() {
        return player2Spawn;
    }
}
