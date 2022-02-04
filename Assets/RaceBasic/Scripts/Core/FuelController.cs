using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{

    public static FuelController instance;
    [Header("Configuraciones de Gasolina")]
    [Tooltip("Intervalo de Consumo de gasolina")]
    public float fuelBurnTime;

    [Tooltip("Barra de Combustible")]
    public GameObject fuelBar;

    public bool starBurn = false;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (starBurn)
        {
            //Con la siguiente linea se crea el efecto de que Consumo de Gasolina al restarle fuelBurnTime a fuelBar
            fuelBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fuelBar.GetComponent<RectTransform>().rect.width - fuelBurnTime);

            //Comparamos el tamaño de fuelBar, siendo <= que 0 se detiene al setear starBurn a false
            if (fuelBar.GetComponent<RectTransform>().rect.width <= 0)
            {
                //TODO: Programar eventos para cuando se termine la gasolina
                starBurn = false;

                GameManager.instance.StopGame();
            }

        }

    }
}
