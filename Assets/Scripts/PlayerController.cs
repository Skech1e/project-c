using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 striker;
    public float m_hori, m_vert;
    int st_count;
    SpriteRenderer aim_spr, power_spr;
    public Vector2 direction;
    Rigidbody2D rg_striker;

    // Start is called before the first frame update
    void Start()
    {
        striker = transform.position;
        striker.y = -8.8f;
        st_count = 0;
        rg_striker = GetComponent<Rigidbody2D>();

        aim_spr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        power_spr = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = striker;
        StrikerControl();
        Physics.gravity = Vector3.down;
        
    }

    void StrikerControl()
    {
        if (st_count <= 0)
        {
            st_count = 0;
            m_hori += Input.GetAxis("Mouse X");
            //striker.x = Mathf.Clamp(m_hori, -7.5f, 7.5f);
            aim_spr.enabled = false;
        }
        if (st_count == 1)
        {
            m_hori += Input.GetAxis("Mouse X");
            aim_spr.enabled = true;
            rg_striker.transform.rotation = Quaternion.Euler(0, 0, -m_hori);
            direction.y = rg_striker.transform.rotation.eulerAngles.z;
            power_spr.enabled = false;
        }
        if (st_count == 2)
        {
            aim_spr.enabled = false;
            if (Input.GetMouseButton(0))
            {
                m_vert += Input.GetAxis("Mouse Y");
                power_spr.enabled = true;

            }
            if (Input.GetMouseButtonUp(0))
            {
                power_spr.enabled = false;
                //rg_striker.AddForce(direction, ForceMode2D.Impulse);
                rg_striker.AddRelativeForce(direction, ForceMode2D.Impulse);
            }
        }
        if (st_count == 3)
        {
            power_spr.enabled = false;
            st_count = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            st_count++;
        }
        if (Input.GetMouseButtonDown(1))
        {
            st_count--;
        }

        else
        {
            m_vert += Input.GetAxis("Mouse Y");
        }
    }
}
