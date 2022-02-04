using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objeto : MonoBehaviour
{

    [Header("Configuracion Carro")]
    public int index;
    public Image imagenCarro;//Imagen del Objeto
    public Image imagenMoneda;//Imagen de la moneda (Juego / Pago)
    public TextMeshProUGUI precio;//Precio del Objeto

    public bool comprado;//Variable Comprado Si / No
    public bool seleccionado;//Variable Seleccionado Si / No

    public int costo;//Costo del objeto

    [Header("Opciones de Objetos")]

    public GameObject objCarro;//Cargamos el Objeto
    public GameObject objMoneda;//Elemento del prefab donde va la imagen de moneda
    public GameObject objPrecio;//Elemento donde va a ir el precio del objeto
    public GameObject objSeleccionado;//Elemento que muestra que SI esta seleccionado

    private void Start()
    {
        precio.text = costo.ToString();
    }

}
