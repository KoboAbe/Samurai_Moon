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
    public void FadeToLevel(int levelIndex){
        
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
// ---------------------------------------------------------------------------------------------
    public void NextLevel(){  
        SceneManager.LoadScene(levelToLoad);
    }
// ---------------------------------------------------------------------------------------------
    public void MenuInicio(){
        SceneManager.LoadScene(0);
    }
// ---------------------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------

}
