using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 striker;
    public float m_hori, m_vert;
    int st_count;
    SpriteRenderer aim_spr, power_spr;

    // Start is called before the first frame update
    void Start()
    {
        striker = transform.position;
        striker.y = -8.8f;
        st_count = 0;

        aim_spr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        power_spr = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = striker;
        StrikerControl();
    }

    void StrikerControl()
    {
        if (st_count == 0)
        {
            m_hori += Input.GetAxis("Mouse X");
            striker.x = Mathf.Clamp(m_hori, -7.5f, 7.5f);

        }
        if (Input.GetMouseButtonDown(0))
        {
            st_count++;

            if (st_count == 1)
            {
                m_hori += Input.GetAxis("Mouse X");
                aim_spr.enabled = true;
            }
            if (st_count == 2)
            {
                aim_spr.enabled = false;
                m_vert += Input.GetAxis("Mouse Y");
                power_spr.enabled = true;
            }
            if (st_count == 3)
            {
                power_spr.enabled = false;
                st_count = 0;
            }
        }

        else
        {
            m_vert += Input.GetAxis("Mouse Y");
        }
    }
}
