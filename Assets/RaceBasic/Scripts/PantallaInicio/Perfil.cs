using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Perfil : MonoBehaviour
{
    public Text txtNombre;
    public Text txtEdad;
    public Button btnOk;
    

    private void Update()
    {

        if (txtNombre.text != "" && txtEdad.text != "")
            btnOk.GetComponent<Button>().interactable = true;
        else
            btnOk.GetComponent<Button>().interactable = false;
    }

    public void Ok()
    {
        GameManager.instance.nombre = txtNombre.text;
        GameManager.instance.edad = int.Parse(txtEdad.text);
        Destroy(gameObject);  
    }

}
