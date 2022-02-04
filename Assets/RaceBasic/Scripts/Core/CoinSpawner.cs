using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Tooltip("Prefab del objeto moneda a spawnear",order = 1)]
    public GameObject coin;
    Vector2 spawnPos;//Posicion donde se va a spawnear la moneda


    /// <summary>
    /// Funcion para spawnear la moneda en coordenadas concretas
    /// </summary>
    public void SpawnCoin()
    {
        //Se crea la moenda con el prefab y las coordenadas concretas
        Instantiate(coin, spawnPos, Quaternion.identity);
    }


    /// <summary>
    /// Se setea la posicion a spawnear el prefab de la moneda dependiendo la op seleccionada
    /// </summary>
    /// <param name="op">Opcion seleccionada en el juego</param>
    public void SetPos(int op)
    {
        if (op==1)//Izquierda
            spawnPos = new Vector2(-3.8f, 2.4f);
        if (op==2)//Centro
            spawnPos = new Vector2(-.2f, 2.4f);
        if (op==3)//Derecha
            spawnPos = new Vector2(4f, 2.4f);

    }

}
