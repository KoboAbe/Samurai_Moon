using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

// ---------------------------------------------------------------------------------------------
    void Start()
    {
        
    }

// ---------------------------------------------------------------------------------------------
    void Update()
    {

    }
// ---------------------------------------------------------------------------------------------
    // Funcion para activar la animacion de transicion
    public void FadeToLevel(int levelIndex){

        levelToLoad = levelIndex;
        Debug.Log("Escena a cargar " + levelToLoad);
        animator.SetTrigger("FadeOut");
    }
// ---------------------------------------------------------------------------------------------
    // Funcion para cargar una escena en concreto
    // Este metodo se ejecuta como evento en el animator (FadeOut)
    public void NextLevel(){  
        SceneManager.LoadScene(levelToLoad);
    }
// ---------------------------------------------------------------------------------------------
    // Funcion para volver al menu inicio
    public void MenuInicio(){
        SceneManager.LoadScene(0);
    }
// ------------------------------------------------------------------------------------------------
    // Funcion para comenzar el juego
    public void StartGame(){
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
// ---------------------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------

}
