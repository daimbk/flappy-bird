using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D BirdRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    private Animator animator;
    private string currentState;

    // animation
    const string bird_idle = "bird_idle";
    const string bird_flap = "bird_flap";

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            BirdRigidBody.velocity = Vector2.up * flapStrength;
            ChangeAnimationState(bird_flap);
        }

        ChangeAnimationState(bird_idle);
    }

    void ChangeAnimationState(string newState)
    {
        // prevent same animation repetition
        if (currentState == newState) return;

        //play animation
        animator.Play(newState);

        // reassign current state
        currentState = newState;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
