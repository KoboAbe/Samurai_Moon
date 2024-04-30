using UnityEngine;
using UnityEngine.UI;

public class Barravida : MonoBehaviour
{
    public Slider sliderVida;
    public Slider sliderEnergia;

    private float tiempoInicioRecarga;
    private bool recargandoEnergia = false;

    private float vidaMaxima;
    private float vidaActual;

    private float energiaMaxima;
    private float energiaActual;

    void Start()
    {
        // Obtener las referencias de los sliders
        sliderVida = transform.Find("BarraVidaSlider").GetComponent<Slider>();
        sliderEnergia = transform.Find("SliderEnergia").GetComponent<Slider>();
    }

    public void InicializarBarraDeVida(float maxVida)
    {
        vidaMaxima = maxVida;
        vidaActual = maxVida; // Establecer la vida actual igual a la vida máxima al inicio
        sliderVida.maxValue = maxVida;
        sliderVida.value = maxVida;
    }

    public void InicializarBarraDeEnergia(float maxEnergia)
    {
        energiaMaxima = maxEnergia;
        energiaActual = 0f; // Comienza la energía actual en cero al inicio
        sliderEnergia.maxValue = maxEnergia;
        sliderEnergia.value = 0;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        vidaActual = Mathf.Clamp(cantidadVida, 0f, vidaMaxima); // Asegurar que la vida actual no sea menor que cero ni mayor que la vida máxima
        sliderVida.value = vidaActual;
    }

    public void CambiarEnergiaActual(float cantidadEnergia)
    {
        energiaActual = Mathf.Clamp(cantidadEnergia, 0f, energiaMaxima); // Asegurar que la energía actual no sea menor que cero ni mayor que la energía máxima
        sliderEnergia.value = energiaActual;
    }

    public void RecargarEnergia(float tiempoRecarga)
    {
        tiempoInicioRecarga = Time.time;
        recargandoEnergia = true;
    }

    void Update()
    {
        if (recargandoEnergia)
        {
            float tiempoTranscurrido = Time.time - tiempoInicioRecarga;
            float progresoRecarga = tiempoTranscurrido / 10f; // Reducir el tiempo de recarga
            CambiarEnergiaActual(Mathf.Lerp(0, energiaMaxima, progresoRecarga));

            if (tiempoTranscurrido >= 10f) // Cambiar a 10 segundos
            {
                recargandoEnergia = false;
            }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        vidaActual -= damageAmount;
        CambiarVidaActual(vidaActual);
    }

    public void IncrementarEnergia(float cantidad)
    {
        // Incrementar la energía actual sin exceder la energía máxima
        energiaActual = Mathf.Clamp(energiaActual + cantidad, 0f, energiaMaxima);
        CambiarEnergiaActual(energiaActual);
    }
}
