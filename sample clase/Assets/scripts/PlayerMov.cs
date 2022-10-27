using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float velociad = 1;
    public float JumpForce = 1;
    public Rigidbody2D playerRig;
    private Animator robotControler;

    // Start is called before the first frame update
    void Start()
    {
        robotControler = gameObject.GetComponent<Animator>();
        robotControler.SetBool("Jump", false);
        playerRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * velociad;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(playerRig.velocity.y) < 0.001f){
            robotControler.SetBool("Jump", true);
            playerRig.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        float Mov_x = Input.GetAxis("Horizontal");

        if (Mov_x > 0f)
        {
            transform.localScale = new Vector3(0.5f, 2.1019f, 1f);
        }
        if (Mov_x < -0.1f)
        {
            transform.localScale = new Vector3(-0.5f, 2.1019f, 1f);
        }
    }

   
}
