using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    float light = 20, dark = 10, queen = 50;

    int playerCOunt;
    public int chance;

    // Start is called before the first frame update
    void Start()
    {
        playerCOunt = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeChance()
    {
        chance = Random.Range(0, playerCOunt);
        print(chance);
    }
    
    void Chance()
    {

    }
}
