using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{
    public static MenuController instance;//Instancia de este script para manupularlo

    [Tooltip("Menu principal")]
    public GameObject btnsPrincipal;

    [Tooltip("Menu de Operaciones")]
    public GameObject btnsOperaciones;

    [Tooltip("Menu de cantidad de cifras")]
    public GameObject btnsCantCifras;

    [Tooltip("Tienda")]
    public GameObject tienda;

    

    private void Awake()
    {
        instance = this;//Instancia del script
        btnsPrincipal.SetActive(true);//Se activa el menu principal
        btnsOperaciones.SetActive(false);//Se ocultan los botones de operaciones
        btnsCantCifras.SetActive(false);//Se ocultan los botones de Cifras
        
    }

    /// <summary>
    /// Al precionar el boton Inicio
    /// Se oculta el primer menu y
    /// Se muestra el menu de Operaciones ( +, -, *, / )
    /// </summary>
    public void PresInicio()
    {
        btnsPrincipal.SetActive(false);
        btnsOperaciones.SetActive(true);
    }

    /// <summary>
    /// Al seleccionar una Operacion
    /// Se oculta el menu de operaciones
    /// Se muestra el menu de Cantidad de Cifras
    /// </summary>
    public void PresOpreaciones()
    {
        btnsOperaciones.SetActive(false);
        btnsCantCifras.SetActive(true);
    }

    /// <summary>
    /// Al seleccionar una cantidad de cifras
    /// se oculta el menu
    /// </summary>
    public void PresCantCifra()
    {
        btnsCantCifras.SetActive(false);
        btnsPrincipal.SetActive(true);
    }


    /// <summary>
    /// Al precionar regresar en el menu de Cantidad de Cifras
    /// Se oculta dicho menu y se muestra el
    /// menu de operaciones
    /// </summary>
    public void PresBackCantCifras()
    {
        btnsOperaciones.SetActive(true);
        btnsCantCifras.SetActive(false);

    }
    

    /// <summary>
    /// Al precionar regresar en el menu de Opraciones
    /// se oculta dicho menu y se muestra el
    /// Menu Principal
    /// </summary>
    public void PresBackOperaciones()
    {
        btnsOperaciones.SetActive(false);
        btnsPrincipal.SetActive(true);

    }

    /// <summary>
    /// Al precioanr el boton de Tienda
    /// Se oculta el menu principal
    /// y se muestra la Tienda
    /// </summary>
    public void TiendaOpen()
    {
        tienda.SetActive(true);
        GameManager.instance.monedaTienda.text = GameManager.instance.coinsCount.ToString();
        btnsPrincipal.SetActive(false);
    }


    /// <summary>
    /// Al precioanr el boton regresar en la tienda
    /// Se oculta la Tienda y se muestra
    /// el menu ´rincipal
    /// </summary>
    public void TiendaBack()
    {
        tienda.SetActive(false);
        btnsPrincipal.SetActive(true);
    }

}
