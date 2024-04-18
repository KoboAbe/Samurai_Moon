using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    public FadeScript fadeScript;

// ------------------------------------------------------------------------------------------------
    void Start()
    {
        fadeScript = FindObjectOfType<FadeScript>();
    }

// ------------------------------------------------------------------------------------------------
    void StartGame()
    {
        fadeScript.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
// ------------------------------------------------------------------------------------------------
// ------------------------------------------------------------------------------------------------
// ------------------------------------------------------------------------------------------------

}
