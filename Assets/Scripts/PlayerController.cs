using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private GameManager _gm;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _direction = Vector2Int.right;
    }

    private void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            int x = 0;
            int y = 0;

            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                x = 1;
            }
            else if (Input.GetAxis("Horizontal") < -0.1f)
            {
                x = -1;
            }
            if (Input.GetAxis("Vertical") > 0.1f)
            {
                y = 1;
            }
            else if (Input.GetAxis("Vertical") < -0.1f)
            {
                y = -1;
            }

            SetNextMove(new Vector2Int(x, y));
            ChangeDirection();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PacDot pd = null;
        SuperPacDot spd = null;
        collision.TryGetComponent<PacDot>(out pd);
        if (pd != null)
        {
            _gm._pacDotsNumber--;
            pd.gameObject.SetActive(false);
        }
        collision.TryGetComponent<SuperPacDot>(out spd);
        if (spd != null)
        {
            _gm.ScareGhost();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        /*Fantome f = null;
        collision.TryGetComponent<Fantome>(out f);
        if (f != null && f.IsScared)
        {
            f.gameObject.SetActive(false);
        }*/
    }
}