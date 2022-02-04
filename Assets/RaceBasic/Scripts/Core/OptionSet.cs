using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Lista de Operaciones
public enum Operacion
{
    sum, res, multi, div
}

//Lista de cantidad de Cifras
public enum CantCifras
{
    una, dos, tres
}

public class OptionSet : MonoBehaviour
{

    public static OptionSet instance;

    public Operacion operacion;
    public CantCifras cantCifras;


    private void Awake()
    {
        instance = this;
    }

    public void PressSum()
    {
        operacion = Operacion.sum;
        MenuController.instance.PresOpreaciones();
    }
    public void PressRes()
    {
        operacion = Operacion.res;
        MenuController.instance.PresOpreaciones();
    }
    public void PressMul()
    {
        operacion = Operacion.multi;
        MenuController.instance.PresOpreaciones();
    }
    public void PressDiv()
    {
        operacion = Operacion.div;
        MenuController.instance.PresOpreaciones();
    }

    public void PressCantUno()
    {
        cantCifras = CantCifras.una;
        MenuController.instance.PresCantCifra();
        GameManager.instance.InitGame();
        GameManager.instance.UIUpdate();

    }
    public void PressCantDos()
    {
        cantCifras = CantCifras.dos;
        MenuController.instance.PresCantCifra();
        GameManager.instance.InitGame();
        GameManager.instance.UIUpdate();
    }
    public void PressCantTres()
    {
        cantCifras = CantCifras.tres;
        MenuController.instance.PresCantCifra();
        GameManager.instance.InitGame();
        GameManager.instance.UIUpdate();
    }

}
