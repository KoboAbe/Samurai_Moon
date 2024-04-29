using UnityEngine;
using UnityEngine.UI;

public class Barravida : MonoBehaviour
{
    public Slider sliderVida;
    public Slider sliderEnergia;

    // Referencia al SamuraiController
    public SamuraiController samuraiController;

    void Start()
    {
        // Inicializa la barra de vida con la vida máxima del SamuraiController
        InicializarBarraDeVida(samuraiController.vidaMaxima);
    }

    void Update()
    {
        // Actualiza la barra de vida con la vida actual del SamuraiController
        CambiarVidaActual(samuraiController.GetVidaActual());
    }

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
