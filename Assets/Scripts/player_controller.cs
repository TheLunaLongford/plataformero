using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    [SerializeField] bool is_on_ground;
    private Animator animator;


    public float jump_force = 5.0f;
    public float player_speed = 10.0f;
    private Rigidbody2D playerRB;
    public LayerMask ground;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, Vector2.down * 1.0f, Color.red);
        is_character_on_floor();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        player_move();
    }

    private void FixedUpdate()
    {
        
    }

    void is_character_on_floor()
    {
        if (
            Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, ground)
            || (Physics2D.Raycast(this.transform.position + (new Vector3(1f, 0, 0)), Vector2.down, 1.0f, ground))
            || (Physics2D.Raycast(this.transform.position + (new Vector3(-1f, 0, 0)), Vector2.down, 1.0f, ground))
           )
        {
            is_on_ground = true;
            animator.SetBool("on_air", false);
        }
        else
        {
            is_on_ground = false;
            animator.SetBool("on_air", true);
        }
    }

    void jump()
    {
        if (is_on_ground)
        {
            playerRB.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
        }
    }

    void player_move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        playerRB.AddForce(movement * player_speed);
    }
}
