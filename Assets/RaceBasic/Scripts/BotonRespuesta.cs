using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonRespuesta : MonoBehaviour
{
    public List<Button> listBotones;

    public bool Recorrer(bool onOff)
    {
        for (int i = 0; i < listBotones.Count; i++)
        {
            listBotones[i].GetComponent<Button>().interactable = onOff;
        }

        return !onOff;
    }
}
