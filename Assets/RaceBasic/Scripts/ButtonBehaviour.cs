using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public int responseValue=0;
    public int responseOption=0;
    public bool toMove = false;

    public void resetResponse()
    {
        responseValue = 0;
        responseOption = 0;
        toMove = false;
    }

    public void ResponseOptionButtonClick(Text ButtonText)
    {
        responseValue = int.Parse(ButtonText.text);
        responseOption = int.Parse(ButtonText.gameObject.name.Substring(ButtonText.gameObject.name.Length - 1));
        toMove = true;

        //Debug.Log("Clicked: " + responseValue + " Option: " + responseOption);

    }

}
