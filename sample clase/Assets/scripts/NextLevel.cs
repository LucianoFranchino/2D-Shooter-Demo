using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int numeroNivel;

    public void nextLevelBtn()
    {
        SceneManager.LoadScene(numeroNivel);
    }
}
