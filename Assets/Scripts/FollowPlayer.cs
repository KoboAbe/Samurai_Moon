using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador a seguir
    public float smoothSpeed = 0.125f; // Velocidad de suavizado de la cámara

    void LateUpdate()
    {
        if (target != null)
        {
            // Obtener la posición deseada de la cámara (centrada en el jugador)
            Vector3 desiredPosition = target.position;
            desiredPosition.z = transform.position.z; // Mantener la misma posición Z

            // Calcular la posición suavizada de la cámara usando Lerp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Asignar la posición suavizada a la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
