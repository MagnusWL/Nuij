using System;
using UnityEngine;
using UnityEngine.U2D;

public class Movement : MonoBehaviour
{
    float vertSpeed = 0;
    public FloatVariable Floor;
    public FloatVariable Gravity;
    public FloatVariable JumpPower;
    public FloatVariable Speed;
    public FloatVariable Nuij;
    public FloatVariable MaxSpeed;
    public FloatVariable MaxRotation;
    public FloatVariable MaxXSpeed;
    public FloatVariable NuijJumpCost;
    public BoolVariable GameStarted;
    private bool Falling = false;
    private float startX, startY;
    public AudioSource audioData;

    private void Start()
    {
        startX = gameObject.transform.position.x;
        startY = gameObject.transform.position.y;


        Debug.Log("started");
    }

    void Update()
    {
        if (!GameStarted.Value)
            return;

        //var newPos = gameObject.transform.position;
        //newPos.x += Speed.Value;
        //gameObject.transform.position = newPos;

        //gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * Speed.Value, ForceMode2D.Force);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed.Value, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            //.AddForce(new Vector3(1, 0, 0) * Speed.Value, ForceMode2D.Force);

        if (gameObject.GetComponent<Rigidbody2D>().angularVelocity > MaxRotation.Value)
        {
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = MaxRotation.Value;
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > MaxXSpeed.Value)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity.Set(MaxXSpeed.Value, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKeyDown("space"))
        {
            audioData = audioData.GetComponent<AudioSource>();
            audioData.Play(0);
            Falling = false;
        }

        if (Input.GetKey("space") && Nuij.Value > NuijJumpCost.Value && !Falling && gameObject.GetComponent<Rigidbody2D>().velocity.y < MaxSpeed.Value) 
        {
            Nuij.Value -= NuijJumpCost.Value; 
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * JumpPower.Value, ForceMode2D.Force);
        }
        else
        {
            Falling = true;
        }
    }

    void Restart()
    {
        Nuij.Value = 1;
        gameObject.transform.position = new Vector3(startX, startY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision : " + collision.gameObject.name + collision.gameObject.tag);
        if (collision.gameObject.tag == "DIE")
        {
            Debug.Log("Quit");
            Restart();
        }

        if (collision.gameObject.tag == "NUIJ")
        {
            Debug.Log("Nuij");
            Nuij.Value = 1;
        }
    }
}