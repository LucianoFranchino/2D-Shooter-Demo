using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;

    [Header("Mov")]
    private float movimientoHorizontal = 0f;
    public float velocidad;
    public float suavizadoMov;
    private Vector3 vectorVelocidad = Vector3.zero;
    private bool mirando = true;
    private Vector3 escala;

    [Header("Salto")]
    public int fuerzaDeSalto = 5;
    public bool estaSaltando;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        estaSaltando = false;
        escala = transform.localScale;
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidad;
        if (Input.GetKeyDown(KeyCode.Space) && estaSaltando == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, fuerzaDeSalto, 0);
            estaSaltando = true;
        }

    }

    private void FixedUpdate()
    {
        Mover(movimientoHorizontal * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            estaSaltando = false;
        }
    }

    void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref vectorVelocidad, suavizadoMov);

        if(mover > 0 && !mirando)
        {
            mirando = !mirando;
            transform.localScale = escala;
        }else if (mover < 0 && mirando)
        {
            mirando = !mirando;
            transform.localScale = new Vector3(-escala.x, escala.y, escala.z);
        }
    }

}
