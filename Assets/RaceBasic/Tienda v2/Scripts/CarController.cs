using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    GameObject tiendaController;

    Color colorCarroComprado = new Color(255, 255, 255);

    private void Awake()
    {
        tiendaController = GameObject.Find("PanelTiendav2");
    }

    private void Start()
    {
        SetComprado();
        SetSelection();
    }


    void SetComprado()
    {
        if (GetComponent<ICarro>().comprado)
        {
            GetComponent<ICarro>().imagenMoneda.enabled = false;
            GetComponent<ICarro>().precio.enabled = false;
            GetComponent<Image>().color = colorCarroComprado;
            

        }
    }

    void SetSelection()
    {
        if (GetComponent<ICarro>().seleccionado)
        {
            GetComponent<ICarro>().imagenSeleccionado.enabled = true;
        }
        else
            GetComponent<ICarro>().imagenSeleccionado.enabled = false;
    }

    public void ClickCarro()
    {
        if (!GetComponent<ICarro>().comprado)
        {
            if ((GameManager.instance.coinsCount - int.Parse(GetComponent<ICarro>().precio.text)) >= 0)
            {
                GameManager.instance.coinsCount -= int.Parse(GetComponent<ICarro>().precio.text);
                GetComponent<ICarro>().comprado = true;
                GetComponent<ICarro>().seleccionado = true;
                ResetCarroSeleccionado();
                SetComprado();
            }
        }
        else
            if (!GetComponent<ICarro>().seleccionado)
            {
                GetComponent<ICarro>().seleccionado = true;
                ResetCarroSeleccionado();

            }
        SetSelection();
        tiendaController.GetComponent<TiendaController>().ActualizarCarro(GetComponent<ICarro>().id);
    }

    void ResetCarroSeleccionado()
    {
        GameManager.instance.carroSeleccionado.GetComponent<ICarro>().seleccionado = false;
        GameManager.instance.carroSeleccionado.GetComponent<ICarro>().imagenSeleccionado.enabled = false;
        GameManager.instance.carroSeleccionado = null;
        GameManager.instance.carroSeleccionado = this.gameObject;
    }

}
