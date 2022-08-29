using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class H0les : MonoBehaviour
{
    BoardMechanics board;

    // Start is called before the first frame update
    void Start()
    {
        board = GetComponentInParent<BoardMechanics>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.name += " Scored";
        CoinScored(collision.transform);
    }
    public void CoinScored(Transform coin)
    {
        coin.gameObject.AddComponent<RectTransform>();
        coin.gameObject.AddComponent<Image>();
        coin.gameObject.GetComponent<Image>().sprite = coin.gameObject.GetComponent<SpriteRenderer>().sprite;
        Destroy(coin.gameObject.GetComponent<SpriteRenderer>());
        coin.transform.position = Camera.main.WorldToScreenPoint(new Vector2(0, 0));
        board.coin = coin.name;
        print(coin);
    }
}
