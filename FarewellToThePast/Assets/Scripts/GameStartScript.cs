using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    // 0 - alx ship
    // 1 - fur ship
    // 2 - uzd ship

    [SerializeField]
    private List<GameObject> ships;
    [SerializeField]
    private ShipControl playerOneShipControl;
    [SerializeField]
    private ShipControl playerTwoShipControl;

    private GameObject player1Prefab;
    private GameObject player2Prefab;

    // Start is called before the first frame update
    void Awake()
    {
        int player1ShipIndex = StaticGameData.Player1ShipIndex;
        int player2ShipIndex = StaticGameData.Player2ShipIndex;

        playerOneShipControl.ship = ships[player1ShipIndex];
        playerTwoShipControl.ship = ships[player2ShipIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
