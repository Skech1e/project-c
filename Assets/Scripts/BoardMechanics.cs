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
        if (isTurnActive == true && sc.StrikerControl() == )
        {
            sc.StrikerControl();
            print(coin);
            gameManager.chance++;
            isTurnActive = sc.StrikerControl() == true ? !isTurnActive : isTurnActive;
        }
        if (isTurnActive == false)
            coin = "null";
            
    }

    public void TurnSwitch()
    {
        isTurnActive = !isTurnActive;
    }

}
