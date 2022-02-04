using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{

    /// <summary>
    /// Funcion para controlar la moneda generada
    /// </summary>
    /// <param name="collision">se detecta contra que objeto colisiona</param>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);//Se destrulle la moneda creada
            GameManager.instance.CoinsCountAdd();//Se agrega al contador de monedas
        }
    }

}
