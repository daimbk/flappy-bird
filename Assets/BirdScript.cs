using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D BirdRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject restWing;
    public GameObject flapWing;
    public bool wingFlapped = false;
    public float flapRate = 50;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            BirdRigidBody.velocity = Vector2.up * flapStrength;
            wingFlap();
        }

        if (timer < flapRate && wingFlapped)
        {
            timer += Time.deltaTime;
        }
        else
        {
            resetWing();
            timer = 0;
        }
    }

    public void wingFlap()
    {
        restWing.SetActive(false);
        flapWing.SetActive(true);
        wingFlapped = true;
    }

    public void resetWing()
    {
        flapWing.SetActive(false);
        restWing.SetActive(true);
        wingFlapped = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
