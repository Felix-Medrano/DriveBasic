using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{

    public GameObject objEstado;
    Estado estado;   

    private void Awake()
    {
        
        estado = objEstado.GetComponent<Estado>();
        Recorrer();
        //SetCarro();
    }

    public void Recorrer()
    {
        foreach (Transform child in transform)
        {
            Objeto temp = child.gameObject.GetComponent<Objeto>();
            estado.GetComponent<Estado>().listComprado.Add(temp.comprado);
            estado.GetComponent<Estado>().listSeleccionado.Add(temp.seleccionado);

        }

    }

    public void Recorrer(int index)
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Objeto>().index == index)
                estado.GetComponent<Estado>().listSeleccionado[index] = true;
            else
                estado.GetComponent<Estado>().listSeleccionado[i] = false;

            i++;
        }
        estado.GetComponent<Estado>().listComprado[index] = true;

    }


    public void SetCarro()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if (estado.listComprado[i] && estado.listSeleccionado[i])
                GameManager.instance.carroSeleccionado = child.gameObject;
            
            i++;
        }
    }

    public void SetComprado()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if (estado.listComprado[i])
                child.gameObject.GetComponent<BuyController>().ActivarCarro(child.gameObject.GetComponent<Objeto>());

            if (estado.listComprado[i] && estado.listSeleccionado[i])
                child.gameObject.GetComponent<Objeto>().objSeleccionado.SetActive(true);
            else
                child.gameObject.GetComponent<Objeto>().objSeleccionado.SetActive(false);
            i++;
        }
    }


    public void SetSeleccionado(int index)
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Objeto>().index == index && child.gameObject.GetComponent<Objeto>().comprado == true)
            {
                child.gameObject.GetComponent<Objeto>().objSeleccionado.SetActive(true);
                estado.listSeleccionado[index] = true;
            }
            else
            {
                child.gameObject.GetComponent<Objeto>().objSeleccionado.SetActive(false);
                estado.listSeleccionado[i] = false;
            }

            i++;
        }

        
    }

}
