using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundParallax : MonoBehaviour
{

    [Header("Configuración Parallax")]
    [Tooltip("Fondo")]
    public RawImage background;

    [Tooltip("Velocidad de Parallax")]
    public float velocidadParallax = .02f;

    [HideInInspector]
    public bool canRun = false;


    private void Update()
    {
        if (canRun)//Verdadero
            EfectoParallax();//Se ejecuta la funcion
    }


    /// <summary>
    /// Genera el efecto parallax para que se vea un fondo "infinito"
    /// </summary>
    public void EfectoParallax()
    {
        float velParallaxFinal = velocidadParallax * Time.deltaTime; //Se calcula la velocidad que va a tener el fondo
        background.uvRect = new Rect(0f, background.uvRect.y + velocidadParallax, 1f, 1f);//Se aplica el efecto parallax al fondo --(eje X, eje Y, tamaño X, tamaño Y)--
    }
}
