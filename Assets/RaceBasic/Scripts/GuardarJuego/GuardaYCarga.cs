using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaYCarga : MonoBehaviour
{
    public Tienda tienda;

    Estado estado;

    private void Awake()
    {
        estado = GetComponent<Estado>();

    }

    public void Guardar(int slotID)
    {
        GestorEstado.Guardar(estado, slotID);
    }

    public void Cargar(int slotID)
    {
        estado = GetComponent<Estado>();
        GestorEstado.Cargar(estado, slotID);
        //tienda.SetCarro();
        //tienda.SetComprado();
        estado.CargarDatos();
        //GetComponent<GameManager>().CargarDatos(estado.cantCoins, estado.cantOk, estado.cantError);
    }

}
