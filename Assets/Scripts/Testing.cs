using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public float OldMin, OldMax, NewMin, NewMax, OldVal, NewVal;
    [SerializeField] float OldRange, NewRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OldRange = (OldMax - OldMin);
        NewRange = (NewMax - NewMin);
        NewVal = (((OldVal - OldMin) * NewRange) / OldRange) + NewMin;
    }
}
