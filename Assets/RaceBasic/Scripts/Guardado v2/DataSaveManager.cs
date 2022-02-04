using net.TBMSP.Lib.File;
using net.TBMSP.Lib.TBMPk.File;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSaveManager : MonoBehaviour
{
    static string dirGuardado = "Data/SaveData/Slot";

    public CarDB carDB;

    bool state;

    private static string[] slots = new string[3];
    private static Transform p;
    public static DataSaveManager GetComponent() { return p.GetComponent<DataSaveManager>(); }


    void Awake() {
        p = this.transform;
        net.TBMSP.Lib.Program.Init(Application.persistentDataPath + "/", true);
        Debug.Log("En esta carpeta se guardan los archivos: \"" + net.TBMSP.Lib.Program.RootDirectory + "\"");
        FileBase.CreateDirectory("Data/SaveData");
        for (int i = 0; i < 3; i++)
        {
            slots[i] = TDF.CreateString();
            var file = dirGuardado + (i + 1) + ".tdf";
            if (FileBase.FileExist(file))
                slots[i] = TDF.Load(file);
        }

        if (TDF.GetValueOfBlock(slots[0], "Game", "Nombre") == "null" &&
            TDF.GetValueOfBlock(slots[1], "Game", "Nombre") == "null" &&
            TDF.GetValueOfBlock(slots[2], "Game", "Nombre") == "null")
            GameManager.instance.pantallaPerfil.SetActive(true);
        else
        {
            SetState(false);
            UISlots();
        }
    }


    public void Cargar(int slotID)
    {

        var file = dirGuardado + (slotID + 1) + ".tdf";

        if (FileBase.FileExist(file))
            slots[slotID] = TDF.LoadGZ(file); //TDF.LoadGZ

        GameManager.instance.nombre = TDF.GetValueOfBlock(slots[slotID],"Game", "Nombre"); 
        GameManager.instance.edad = int.Parse(TDF.GetValueOfBlock(slots[slotID],"Game", "Edad")); 
        GameManager.instance.coinsCount = int.Parse(TDF.GetValueOfBlock(slots[slotID],"Game", "Monedas")); 

        var comprado = TDF.GetValueOfBlock(slots[slotID], "Game", "Comprados").Split(","[0]);
        var seleccionado = TDF.GetValueOfBlock(slots[slotID], "Game", "Seleccionado").Split(","[0]);
        carDB.carros[0].comprado = bool.Parse(comprado[0]);
        carDB.carros[1].comprado = bool.Parse(comprado[1]);
        carDB.carros[2].comprado = bool.Parse(comprado[2]);
        carDB.carros[3].comprado = bool.Parse(comprado[3]);
        carDB.carros[4].comprado = bool.Parse(comprado[4]);
        carDB.carros[5].comprado = bool.Parse(comprado[5]);
        carDB.carros[6].comprado = bool.Parse(comprado[6]);
        carDB.carros[7].comprado = bool.Parse(comprado[7]);
        carDB.carros[8].comprado = bool.Parse(comprado[8]);
        carDB.carros[9].comprado = bool.Parse(comprado[9]);
        carDB.carros[10].comprado = bool.Parse(comprado[10]);
        carDB.carros[11].comprado = bool.Parse(comprado[11]);
        carDB.carros[12].comprado = bool.Parse(comprado[12]);
        carDB.carros[13].comprado = bool.Parse(comprado[13]);
        carDB.carros[14].comprado = bool.Parse(comprado[14]);
        carDB.carros[15].comprado = bool.Parse(comprado[15]);

        carDB.carros[0].seleccionado = bool.Parse(seleccionado[0]);
        carDB.carros[1].seleccionado = bool.Parse(seleccionado[1]);
        carDB.carros[2].seleccionado = bool.Parse(seleccionado[2]);
        carDB.carros[3].seleccionado = bool.Parse(seleccionado[3]);
        carDB.carros[4].seleccionado = bool.Parse(seleccionado[4]);
        carDB.carros[5].seleccionado = bool.Parse(seleccionado[5]);
        carDB.carros[6].seleccionado = bool.Parse(seleccionado[6]);
        carDB.carros[7].seleccionado = bool.Parse(seleccionado[7]);
        carDB.carros[8].seleccionado = bool.Parse(seleccionado[8]);
        carDB.carros[9].seleccionado = bool.Parse(seleccionado[9]);
        carDB.carros[10].seleccionado = bool.Parse(seleccionado[10]);
        carDB.carros[11].seleccionado = bool.Parse(seleccionado[11]);
        carDB.carros[12].seleccionado = bool.Parse(seleccionado[12]);
        carDB.carros[13].seleccionado = bool.Parse(seleccionado[13]);
        carDB.carros[14].seleccionado = bool.Parse(seleccionado[14]);
        carDB.carros[15].seleccionado = bool.Parse(seleccionado[15]);

        GameManager.instance.UIUpdate();
    }

    public static void Guardado(int slotID)
    {
        
        slots[slotID] = TDF.SaveValueInBlock(slots[slotID], "Game", "Nombre", GameManager.instance.nombre);
        slots[slotID] = TDF.SaveValueInBlock(slots[slotID], "Game", "Edad", GameManager.instance.edad.ToString());
        slots[slotID] = TDF.SaveValueInBlock(slots[slotID], "Game", "Monedas", GameManager.instance.coinsCount.ToString());
        slots[slotID] = TDF.SaveValueInBlock(slots[slotID], "Game", "Correcto", GameManager.instance.totalCorrect.ToString());
        slots[slotID] = TDF.SaveValueInBlock(slots[slotID], "Game", "Error", GameManager.instance.totalIncorrect.ToString());

        slots[slotID] = TDF.SaveValueInBlock(slots[slotID], "Game", "Comprados",
            GetComponent().carDB.carros[0].comprado.ToString() + "," + 
            GetComponent().carDB.carros[1].comprado.ToString() + "," + 
            GetComponent().carDB.carros[2].comprado.ToString() + "," + 
            GetComponent().carDB.carros[3].comprado.ToString() + "," + 
            GetComponent().carDB.carros[4].comprado.ToString() + "," +
            GetComponent().carDB.carros[5].comprado.ToString() + "," + 
            GetComponent().carDB.carros[6].comprado.ToString() + "," + 
            GetComponent().carDB.carros[7].comprado.ToString() + "," + 
            GetComponent().carDB.carros[8].comprado.ToString() + "," + 
            GetComponent().carDB.carros[9].comprado.ToString() + "," + 
            GetComponent().carDB.carros[10].comprado.ToString() + "," + 
            GetComponent().carDB.carros[11].comprado.ToString() + "," + 
            GetComponent().carDB.carros[12].comprado.ToString() + "," + 
            GetComponent().carDB.carros[13].comprado.ToString() + "," + 
            GetComponent().carDB.carros[14].comprado.ToString() + "," + 
            GetComponent().carDB.carros[15].comprado.ToString());

        slots[slotID] = TDF.SaveValueInBlock(slots[slotID], "Game", "Seleccionado", 
            GetComponent().carDB.carros[0].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[1].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[2].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[3].seleccionado.ToString() + "," +
            GetComponent().carDB.carros[4].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[5].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[6].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[7].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[8].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[9].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[10].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[11].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[12].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[13].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[14].seleccionado.ToString() + "," + 
            GetComponent().carDB.carros[15].seleccionado.ToString());

        TDF.SaveGZ(dirGuardado + (slotID + 1) + ".tdf", slots[slotID]); //TDF.SaveGZ


    }

    void UISlots()
    {

        string nombre1 = TDF.GetValueOfBlock(slots[0], "Game", "Nombre");
        string nombre2 = TDF.GetValueOfBlock(slots[1], "Game", "Nombre");
        string nombre3 = TDF.GetValueOfBlock(slots[2], "Game", "Nombre");

        GameManager.instance.pantallaGyC.SetActive(true);

        GameManager.instance.slot1.GetComponent<Button>().interactable = nombre1 == "null" ? false : true;
        GameManager.instance.slot2.GetComponent<Button>().interactable = nombre2 == "null" ? false : true;
        GameManager.instance.slot3.GetComponent<Button>().interactable = nombre3 == "null" ? false : true;

        GameManager.instance.dato1.text = nombre1 == "null" ? "Empty" : nombre1;
        GameManager.instance.dato2.text = nombre2 == "null" ? "Empty" : nombre2;
        GameManager.instance.dato3.text = nombre3 == "null" ? "Empty" : nombre3;
    }

    public void SetState(bool _state)
    {
        state = _state;
    }

    public void Event(int slotID)
    {
        if (state)
            Guardado(slotID);
        else
            Cargar(slotID);

    }

}
