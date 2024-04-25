using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barravida : MonoBehaviour
{
    public Slider sliderVida;
    public Slider sliderEnergia;

    public void InicializarBarraDeVida(float vidaMaxima)
    {
        sliderVida.maxValue = vidaMaxima;
        sliderVida.value = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        sliderVida.value = cantidadVida;
    }

    public void InicializarBarraDeEnergia(float energiaMaxima)
    {
        sliderEnergia.maxValue = energiaMaxima;
        sliderEnergia.value = energiaMaxima;
    }

    public void CambiarEnergiaActual(float cantidadEnergia)
    {
        sliderEnergia.value = cantidadEnergia;
    }
}
