using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    private float initialSpeed;
    private int index;
    public List<Transform> paths = new List<Transform>();
    public Animator anim;
    private bool _isWalking;
    public bool IsWalking { get => _isWalking; set => _isWalking = value; }

    void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        IsWalkingAnimation();
        OnMove();
        MovingThroughPaths();
    }

    void IsWalkingAnimation()
    {
        if (DialogueControl.instance.IsShowing)
        {
            speed = 0f;
            anim.SetBool("IsWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("IsWalking", true);
        }
    }

    void OnMove()
    {
        Vector2 direction = paths[index].position - transform.position;

        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void MovingThroughPaths()
    {
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            if (index < paths.Count - 1)
            {
                // index++;
                index = Random.Range(0, paths.Count - 1);
            }
            else
            {
                index = 0;
            }
        }
    }
}
