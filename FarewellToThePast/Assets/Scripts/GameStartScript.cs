using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    // 0 - alx ship
    // 1 - fur ship
    // 2 - uzd ship

    private List<GameObject> ships = new List<GameObject>();

    private GameObject player1Prefab;
    private GameObject player2Prefab;

    // Start is called before the first frame update
    void Start()
    {
        
        int player1ShipIndex = StaticGameData.Player1ShipIndex;
        int player2ShipIndex = StaticGameData.Player2ShipIndex;

        var player1 = Instantiate<GameObject>(ships[player1ShipIndex]);
        var player2 = Instantiate<GameObject>(ships[player2ShipIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
