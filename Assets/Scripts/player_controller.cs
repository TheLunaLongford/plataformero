using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_controller : MonoBehaviour
{
    [SerializeField] bool is_on_ground;

    public float jump_force = 5.0f;
    public float player_speed = 10.0f;
    private Rigidbody2D playerRB;
    public LayerMask ground;

    [SerializeField] float move_vector;
    [SerializeField] float move_speed;
    [SerializeField] float jump_speed;

    Rigidbody2D rigib_body;
    private SpriteRenderer sprite_renderer;
    private Animator animator;

    public bool alpha_show;
    public GameObject init_point;

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

        alpha_show = true;
        transform.position = init_point.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, Vector2.down * 1.0f, Color.red);
        is_character_on_floor();
        transform.Translate(new Vector3(move_vector, 0, 0) * move_speed * Time.deltaTime);
        if (move_vector == 0.0f)
        {
            animator.SetBool("is_running", false);
        }
        else
        {
            animator.SetBool("is_running", true);
            if (move_vector > 0)
            {
                sprite_renderer.flipX = false;
            }
            else
            {
                sprite_renderer.flipX = true;
            }
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
            animator.SetBool("on_ground", true);
        }
        else
        {
            is_on_ground = false;
            animator.SetBool("on_ground", false);
        }
    }


    public void pit_recoil()
    {
        // Knock back a little bit upper-left in order to recover from a fail
        transform.position = transform.position + new Vector3(-5.0f, 5.0f, 0.0f);
        damage_blink();
    }

    public void damage_blink()
    {
        toggle_alpha();
        Invoke("toggle_alpha", 0.3f);
        Invoke("toggle_alpha", 0.6f);
        Invoke("toggle_alpha", 0.9f);
        Invoke("toggle_alpha", 1.2f);
        Invoke("toggle_alpha", 1.5f);
    }

    public void toggle_alpha()
    {
            Color c = sprite_renderer.color;
            if (alpha_show)
            {
                // dissappear
                sprite_renderer.color = new Color(c.r, c.g, c.b, 0.0f);
                alpha_show = false;
            }
            else
            {
                // re-appear
                sprite_renderer.color = new Color(c.r, c.g, c.b, 255.0f);
                alpha_show = true;
            }
    }
}
