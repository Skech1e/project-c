using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 striker;
    public float m_hori, m_vert;
    public int st_count;
    SpriteRenderer aim_spr, power_spr;
    SpriteMask msk_pwr;
    Rigidbody2D rg_striker;
    public float strike_power;

    [SerializeField] InitGame ig;

    // Start is called before the first frame update
    void Start()
    {
        striker.y = transform.position.y;
        //striker.y = -8.8f;
        st_count = 0;
        rg_striker = GetComponent<Rigidbody2D>();

        aim_spr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        power_spr = transform.GetChild(1).GetComponent<SpriteRenderer>();
        msk_pwr = power_spr.GetComponentInChildren<SpriteMask>();

        ig = GameObject.FindWithTag("board").GetComponent<InitGame>();
    }

    // Update is called once per frame
    void Update()
    {        
        StrikerControl();        
    }

    float RangeConvert(float value)
    {
        float newVal;
        newVal = (((value - (-2.6f)) * 200) / 2.6f) + 1;
        return newVal;
    }

    void ResetStrikerPos()
    {
        transform.position = ig.players[0].position;
        transform.rotation = Quaternion.identity;
        st_count = 0;
    }

    void StrikerControl()
    {
        if (st_count <= 0)
        {
            st_count = 0;
            m_hori += Input.GetAxis("Mouse X");
            striker.x = Mathf.Clamp(m_hori, -7.5f, 7.5f);
            aim_spr.enabled = false;
            power_spr.enabled = false;
            transform.position = striker;
        }
        if (st_count == 1)
        {
            m_hori += Input.GetAxis("Mouse X");
            aim_spr.enabled = true;
            rg_striker.transform.rotation = Quaternion.Euler(0, 0, -m_hori);
            power_spr.enabled = false;
        }
        if (st_count == 2)
        {
            aim_spr.enabled = false;
            if (Input.GetMouseButton(0))
            {
                power_spr.enabled = true;
                m_vert += Input.GetAxis("Mouse Y");
                Vector3 maskTransform;
                //power_spr.material.SetFloat("_Arc2", -m_vert);
                //strike_power = RangeConvert(Mathf.Clamp(power_spr.material.GetFloat("_Arc2"), 0f, 360f));
                maskTransform = Vector2.zero;
                maskTransform.y = Mathf.Clamp(m_vert * 0.1f, -2.6f, 0f);
                msk_pwr.transform.localPosition = maskTransform;
                strike_power = RangeConvert(maskTransform.y);
                
            }
            if (Input.GetMouseButtonUp(0))
            {
                power_spr.enabled = false;
                rg_striker.AddRelativeForce(Vector2.up * strike_power, ForceMode2D.Impulse);
                Invoke("ResetStrikerPos", 3f);                
            }
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
