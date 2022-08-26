using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class h0les : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ok");
        collision.gameObject.name += " Scored";
        CoinScored(collision.transform);
    }
    void CoinScored(Transform coin)
    {
        coin.transform.position = Camera.main.WorldToScreenPoint(new Vector2(1, 0));
    }
}
