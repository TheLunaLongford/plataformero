using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_controller : MonoBehaviour
{
    [SerializeField] bool is_on_ground;
    private Animator animator;


    public float jump_force = 5.0f;
    public float player_speed = 10.0f;
    private Rigidbody2D playerRB;
    public LayerMask ground;

    [SerializeField] float move_vector;
    [SerializeField] float move_speed;
    [SerializeField] float jump_speed;

    Rigidbody2D rigib_body;
    private SpriteRenderer sprite_renderer;

    void OnMove(InputValue value)
    {
        move_vector = value.Get<float>();
    }

    void OnJump()
    {
        if (is_on_ground)
        {
            rigib_body.AddForce(Vector2.up * jump_speed, ForceMode2D.Impulse);
        }
    }


    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rigib_body = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        rigib_body.gravityScale = 4.7f;
        move_speed = 10;
        jump_speed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, Vector2.down * 1.0f, Color.red);
        is_character_on_floor();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    jump();
        //}
        //player_move();
        transform.Translate(new Vector3(move_vector, 0, 0) * move_speed * Time.deltaTime);
        if (move_vector > 0)
        {
            sprite_renderer.flipX = false;
        }
        else if (move_vector < 0)
        {
            sprite_renderer.flipX = true;
        }
        Debug.DrawRay(this.transform.position, Vector2.down * 1.2f, Color.red);
        Debug.DrawRay(this.transform.position + (new Vector3(0.6f, 0, 0)), Vector2.down * 1.0f, Color.red);
        Debug.DrawRay(this.transform.position + (new Vector3(-0.6f, 0, 0)), Vector2.down * 1.0f, Color.red);
    }


    void is_character_on_floor()
    {
        if (
            Physics2D.Raycast(this.transform.position, Vector2.down, 1.2f, ground)
            || (Physics2D.Raycast(this.transform.position + (new Vector3(0.6f, 0, 0)), Vector2.down, 1.2f, ground))
            || (Physics2D.Raycast(this.transform.position + (new Vector3(-0.6f, 0, 0)), Vector2.down, 1.2f, ground))
           )
        {
            is_on_ground = true;
            //animator.SetBool("on_air", false);
        }
        else
        {
            is_on_ground = false;
            //animator.SetBool("on_air", true);
        }
    }

    //void jump()
    //{
    //    if (is_on_ground)
    //    {
    //        playerRB.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
    //    }
    //}

    //void player_move()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");

    //    Vector2 movement = new Vector2(moveHorizontal, 0.0f);
    //    playerRB.AddForce(movement * player_speed);
    //}
}
