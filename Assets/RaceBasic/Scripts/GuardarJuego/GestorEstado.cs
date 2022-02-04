using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorEstado : MonoBehaviour
{

    public static void Guardar(MonoBehaviour objeto, int slotID)
    {
        PlayerPrefs.SetString("Slot"+slotID, JsonUtility.ToJson(objeto));
    }
    
    public static void Cargar(MonoBehaviour objeto, int slotID)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Slot" + slotID), objeto);

    }


}

