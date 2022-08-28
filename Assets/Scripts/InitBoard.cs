using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBoard : MonoBehaviour
{
    [SerializeField] Grid grid;
    public Vector2Int centre;
    public Vector3 pos;
    public Transform Queen, Light, Dark, Striker;
    public List<Transform> players = new(4);
    bool init;

    [SerializeField] List<Vector2Int> light = new();
    [SerializeField] List<Vector2Int> dark = new();

    GameManager manager;
    [SerializeField] Transform[] j;
    [SerializeField] Transform[] k;

    // Start is called before the first frame update
    void Start()
    {
        j = new Transform[9];
        k = new Transform[9];
        CentreGrid();
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      //MaintainPos();
    }

    void CentreGrid()
    {
        grid = transform.GetChild(0).GetComponent<Grid>();
        centre = new Vector2Int(0, 0);
        grid.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -15f));

        dark.Add(new Vector2Int(-2, -1));
        dark.Add(new Vector2Int(-2, 1));
        dark.Add(new Vector2Int(-1, -1));
        dark.Add(new Vector2Int(-1, 1));
        dark.Add(new Vector2Int(0, -2));
        dark.Add(new Vector2Int(0, 2));
        dark.Add(new Vector2Int(1, -1));
        dark.Add(new Vector2Int(1, 0));
        dark.Add(new Vector2Int(1, 1));

        light.Add(new Vector2Int(-2, 0));
        light.Add(new Vector2Int(-1, -2));
        light.Add(new Vector2Int(-1, 0));
        light.Add(new Vector2Int(-1, 2));
        light.Add(new Vector2Int(1, -2));
        light.Add(new Vector2Int(0, -1));
        light.Add(new Vector2Int(0, 1));
        light.Add(new Vector2Int(1, 2));
        light.Add(new Vector2Int(2, 0));
    }

    public void Init()
    {
        if (init == false)
        {
            for (int i = 0; i <= 8; i++)
            {
                j[i] = Instantiate(Light, grid.CellToWorld((Vector3Int)light[i]), Quaternion.identity); 
                k[i] = Instantiate(Dark, grid.CellToWorld((Vector3Int)dark[i]), Quaternion.identity);

            }
            Instantiate(Queen, grid.CellToWorld((Vector3Int)centre), Quaternion.identity);

            Instantiate(Striker, players[0].position, Quaternion.identity);
        }
    }

    public void MaintainPos()
    {
        for(int i = 0; i <= 8; i++)
        {
         j[i].position = grid.CellToWorld((Vector3Int)light[i]);
         k[i].position = grid.CellToWorld((Vector3Int)dark[i]);
         Queen.position = grid.CellToWorld((Vector3Int)centre);
        }
    }
}
