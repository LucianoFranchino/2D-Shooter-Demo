using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeShoot : MonoBehaviour
{
    public Transform puntoLanzamiento;
    public float fuerzaHorizontal = 5f;
    public float fuerzaVertical = 10f;

    protected virtual void Update()
    {
        // Lógica para lanzar la granada, por ejemplo, cuando se presiona una tecla
        if (Input.GetKeyDown(KeyCode.F))
        {
            LanzarGranada();
        }
    }

    void LanzarGranada()
    {
        
        GameObject granada = GranadePool.Instance.RequestGranade();
        granada.transform.position = puntoLanzamiento.position;
        granada.transform.rotation = puntoLanzamiento.rotation;

        // Obtener el componente Rigidbody2D de la granada
        Rigidbody2D rbGranada = granada.GetComponent<Rigidbody2D>();

        // Calcular la dirección de lanzamiento
        Vector2 direccionLanzamiento = new Vector2(fuerzaHorizontal, fuerzaVertical);

        if (transform.localScale.x < 0)
        {
            direccionLanzamiento.x *= -1;
        }

        // Aplicar la fuerza para simular el movimiento de parábola
        rbGranada.AddForce(direccionLanzamiento, ForceMode2D.Impulse);
    }
}
