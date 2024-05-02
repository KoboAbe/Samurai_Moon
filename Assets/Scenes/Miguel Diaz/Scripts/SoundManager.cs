using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    public AudioSource audioS;
//------------------------------------------------------------------------------------------------------
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

//------------------------------------------------------------------------------------------------------    
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3){
            audioS.Stop();
        }
        
    }
//------------------------------------------------------------------------------------------------------
    void Awake()
    {
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
//------------------------------------------------------------------------------------------------------
}
