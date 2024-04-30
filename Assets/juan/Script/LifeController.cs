using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public float vidaMax;
    public SamuraiController sami;

    public Slider sliderVida;

    private void Start()
    {
        sliderVida.maxValue = vidaMax;
        sliderVida.value = vidaMax;
    }

    public void TakeDamage(int damagePoint)
    {
        sliderVida.value -= damagePoint;
        if(sliderVida.value <=0)
        {
            sami.Die();
            return;
        }
        sami.TakeDamage();
    }


   
 
}
