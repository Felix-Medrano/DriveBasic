using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarDB", menuName = "CarDB", order = 1)]

public class CarDB : ScriptableObject
{
    [System.Serializable]

    public struct Carro{
        public int id;
        public Sprite imgCarro;
        public Sprite imgMoneda;

        public int precio;
        public bool comprado;
        public bool seleccionado;

    }
    
    public Carro[] carros;
}
