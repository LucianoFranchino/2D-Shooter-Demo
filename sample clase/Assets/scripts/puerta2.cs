using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puerta2 : MonoBehaviour
{
    public int numeroNivel;
    public GameObject texto;
    private bool entrar;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && entrar == true)
        {
            SceneManager.LoadScene(numeroNivel);
        }
    }

    private void OnTriggerEnter2D(Collider2D puertita)
    {
        if(puertita.tag == "Player")
        {
            texto.SetActive(true);
            entrar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            texto.SetActive(false);
            entrar = false;
        }
    }
}
