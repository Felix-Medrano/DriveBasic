using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyController : MonoBehaviour
{

    Color color = new Color(255, 255, 255);

    Objeto objeto;
    public GameObject estado;

    public Tienda tienda;

    private void Awake()
    {
        objeto = GetComponent<Objeto>();
        
        Button b = GetComponent<Button>();
        b.onClick.AddListener(delegate () { ComprarCarro(); });

    }

    public void ComprarCarro()
    {



        if (!objeto.comprado)
        {
            if ((GameManager.instance.coinsCount - objeto.costo) >= 0)
            {

                GameManager.instance.coinsCount -= objeto.costo;
                estado.GetComponent<Estado>().cantCoins -= objeto.costo;
                GameManager.instance.monedaTienda.text = GameManager.instance.coinsCount.ToString();
                ActivarCarro();
                SetObjetos();
                tienda.Recorrer(objeto.index);
            }
        }
        else
        {
            SetObjetos();
        }
    }

    public void ActivarCarro()
    {
        objeto.comprado = true;
        objeto.seleccionado = true;
        objeto.GetComponent<Image>().color = color;
        objeto.objMoneda.SetActive(false);
        objeto.objPrecio.SetActive(false);
    }

    public void ActivarCarro(Objeto obj)
    {
        obj.GetComponent<Image>().color = color;
        obj.objMoneda.SetActive(false);
        obj.objPrecio.SetActive(false);
    }



    public void SetObjetos()
    {
        tienda.GetComponent<Tienda>().SetSeleccionado(objeto.index);
        GameManager.instance.carroSeleccionado = this.gameObject;

    }

}
