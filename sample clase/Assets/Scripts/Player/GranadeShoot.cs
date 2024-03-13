using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeShoot : MonoBehaviour
{
    public GameObject granadaPrefab;
    public Transform puntoLanzamiento;
    public float fuerzaHorizontal = 5f;
    public float fuerzaVertical = 10f;

    void Update()
    {
        // Lógica para lanzar la granada, por ejemplo, cuando se presiona una tecla
        if (Input.GetKeyDown(KeyCode.F))
        {
            LanzarGranada();
        }
    }

    void LanzarGranada()
    {
        // Instanciar la granada en el punto de lanzamiento
        GameObject granada = Instantiate(granadaPrefab, puntoLanzamiento.position, Quaternion.identity);

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
