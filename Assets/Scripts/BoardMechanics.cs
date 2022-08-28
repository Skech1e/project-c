using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMechanics : MonoBehaviour
{
    public StrikerCode sc;
    GameManager gameManager;
    public bool isTurnActive;

    public string coin;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayTurn();
    }

    void PlayTurn()
    {
        if (isTurnActive == true)
        {
            sc.StrikerControl();
            //print(coin);            
            if (sc.StrikerControl() == true)
            {
                TurnSwitch();
                gameManager.chance++;
            }
        }
        if (isTurnActive == false)
            coin = "nul";

    }

    public void TurnSwitch()
    {
        isTurnActive = !isTurnActive;
    }

}
