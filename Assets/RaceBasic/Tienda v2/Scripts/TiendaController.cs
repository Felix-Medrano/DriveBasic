using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaController : MonoBehaviour
{

    public CarDB carDB;
    List<CarDB> carDBList = new List<CarDB>();

    GameManager gameManager;
    public GameObject carPrefab;
    public GameObject tiendaUI;
    public Transform panelTienda;

    List<ICarro> iCarList = new List<ICarro>();

    bool mostrarTienda = false;

    private void Awake()
    {
        CrearTienda();
    }


    public void CrearTienda()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        for (int i = 0; i < carDB.carros.Length; i++)
        {
            GameObject carro = Instantiate(carPrefab, panelTienda);
            carro.GetComponent<ICarro>().id = carDB.carros[i].id;
            carro.GetComponent<ICarro>().ImagenCarro.sprite = carDB.carros[i].imgCarro;
            carro.GetComponent<ICarro>().imagenMoneda.sprite = carDB.carros[i].imgMoneda;
            carro.GetComponent<ICarro>().precio.text = carDB.carros[i].precio.ToString();
            carro.GetComponent<ICarro>().comprado = carDB.carros[i].comprado;
            carro.GetComponent<ICarro>().seleccionado = carDB.carros[i].seleccionado;
            if (carro.GetComponent<ICarro>().seleccionado)
                GameManager.instance.carroSeleccionado = carro;
        }
    }

    public void ActualizarCarro(int id)
    {
        for (int i = 0; i < carDB.carros.Length; i++)
        {
            if (carDB.carros[i].id == id)
            {
                if (!carDB.carros[i].comprado)
                {
                    carDB.carros[i].comprado = true;
                    carDB.carros[i].seleccionado = true;
                }
                if (!carDB.carros[i].seleccionado)
                {
                    carDB.carros[i].seleccionado = true;
                }
            }
            else
                carDB.carros[i].seleccionado = false;
        }
    }

    public void MostrarTienda()
    {
        mostrarTienda = !mostrarTienda;
        tiendaUI.SetActive(mostrarTienda);
    }
}
