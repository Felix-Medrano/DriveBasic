using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado : MonoBehaviour
{
    public string name;
    public int edad;
    public int cantCoins, cantOk, cantError;

    public List<bool> listComprado = new List<bool>();
    public List<bool> listSeleccionado = new List<bool>();

    public void CargarDatos()
    {
        GameManager gameManager = GetComponent<GameManager>();
        gameManager.coinsCount = cantCoins;
        gameManager.correctCount = cantOk;
        gameManager.incorrectCount = cantError;

    }

    public void DatosPlayer()
    {
        name = "";
        cantCoins = 0;
        cantOk = 0;
        cantError = 0;
    }
}
