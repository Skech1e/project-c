using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    Grid grid;
    public Vector2Int centre;
    public Vector3 pos;
    public Transform Queen, Light, Dark, Striker, StrikerSpawn;
    bool flip;

    [SerializeField] List<Vector2Int> light = new();
    [SerializeField] List<Vector2Int> dark = new();

    // Start is called before the first frame update
    void Start()
    {
        CentreGrid();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void CentreGrid()
    {
        grid = GetComponent<Grid>();
        centre = new Vector2Int(0, 0);

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
        for (int i = 0; i <= 8; i++)
        {
            Instantiate(Light, grid.CellToWorld((Vector3Int)light[i]), Quaternion.identity);
            Instantiate(Dark, grid.CellToWorld((Vector3Int)dark[i]), Quaternion.identity);
        }
        Instantiate(Queen, grid.CellToWorld((Vector3Int)centre), Quaternion.identity);

        Instantiate(Striker, StrikerSpawn.position, Quaternion.identity);
    }
}
