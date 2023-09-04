using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement
    void OnMove()
    {
        // sqrMagnitude gets Vector2 and returns its total value
        if (player.Direction.sqrMagnitude > 0)
        {
            if (player.IsRolling)
            {
                anim.SetTrigger("IsRolling");

            }
            else
            {
                anim.SetInteger("Transition", 1);
            }
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }

        if (player.IsChopping)
        {
            anim.SetInteger("Transition", 3);
        }

        // if player direction equals 0 I want it to be the last angle, so the player doesn't swap directions if idle
        if (player.Direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.Direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if (player.IsRunning)
        {
            anim.SetInteger("Transition", 2);
        }

    }
    #endregion
}
