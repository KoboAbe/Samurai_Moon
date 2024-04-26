using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
//------------------------------------------------------------------------------------------------------
    void Start()
    {
        
    }

//------------------------------------------------------------------------------------------------------    
    void Update()
    {
        
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
