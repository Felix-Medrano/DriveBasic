using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    
    public GameManager GameManager_;
    public Text questionText;
    public Text response1;
    public Text response2;
    public Text response3;

    [HideInInspector]
    public float questionNumber1;
    [HideInInspector]
    public float questionNumber2;
    [HideInInspector]
    public int operationInt=3;//1-Sum, 2-Substract, 3-Multiply, 4-Divide
    private char operationChar;
    private int responseOK;
    private int responseOther1;
    private int responseOther2;
    private int optionOK;

    Vector2 otherResponse1 = new Vector2(0f,0f);
    Vector2 otherResponse2 = new Vector2(0f,0f);

    GameObject coinSpawner;

    float waitTime = 0f;

    bool onOff;

    // Start is called before the first frame update
    void Start()
    {
        Singletone();
        coinSpawner = FindObjectOfType<CoinSpawner>().gameObject;
        //SpawnStart();

}

    public void SpawnStart()
    {
        StartCoroutine(SpawnQuestion());
        waitTime = 1.5f;
    }


    public IEnumerator SpawnQuestion()
    {
        onOff = GetComponent<BotonRespuesta>().Recorrer(onOff);
        yield return new WaitForSeconds(waitTime);
        onOff = GetComponent<BotonRespuesta>().Recorrer(onOff);


        //Se setean las configuraciones de pendiendo de la cantidad de cigras seleccionadas 
        if (OptionSet.instance.cantCifras == CantCifras.una)
        {
            questionNumber1 = Random.Range(1, 10);
            questionNumber2 = Random.Range(1, 10);
            otherResponse1 = new Vector2(Random.Range(1,6), Random.Range(6,10));
            otherResponse2 = new Vector2(Random.Range(1,6), Random.Range(6,10));
        }
        if (OptionSet.instance.cantCifras == CantCifras.dos)
        {
            questionNumber1 = Random.Range(10, 100);
            questionNumber2 = Random.Range(10, 100);
            otherResponse1 = new Vector2(Random.Range(10,60), Random.Range(60,100));
            otherResponse2 = new Vector2(Random.Range(10,60), Random.Range(60,100));
        }
        if (OptionSet.instance.cantCifras == CantCifras.tres)
        {
            questionNumber1 = Random.Range(100, 1000);
            questionNumber2 = Random.Range(100, 1000);
            otherResponse1 = new Vector2(Random.Range(100,600), Random.Range(600,1000));
            otherResponse2 = new Vector2(Random.Range(100,600), Random.Range(600,1000));

        }


        //TODO: Ajustar randoms a mejor funcionalidad educativa

        //Depende el tipo de operacion se realiza la operacion matematica
        switch (OptionSet.instance.operacion)
        {
            case Operacion.sum:
                operationChar = '+';
                if (questionNumber1 >= questionNumber2)
                    responseOK = Mathf.RoundToInt(questionNumber1) + Mathf.RoundToInt(questionNumber2);
                if (questionNumber1 <= questionNumber2)
                    responseOK = Mathf.RoundToInt(questionNumber2) + Mathf.RoundToInt(questionNumber1);
                break;
            case Operacion.res:
                operationChar = '-';
                if (questionNumber1 <= questionNumber2)
                    responseOK = Mathf.RoundToInt(questionNumber2) - Mathf.RoundToInt(questionNumber1);
                if (questionNumber1 >= questionNumber2)
                    responseOK = Mathf.RoundToInt(questionNumber1) - Mathf.RoundToInt(questionNumber2);
                break;
            case Operacion.multi:
                operationChar = 'x';
                responseOK = Mathf.RoundToInt(questionNumber1) * Mathf.RoundToInt(questionNumber2);
                break;
            case Operacion.div:
                operationChar = '/';
                if (questionNumber1 >= questionNumber2)
                    responseOK = Mathf.RoundToInt(questionNumber1) / Mathf.RoundToInt(questionNumber2);
                if (questionNumber1 <= questionNumber2)
                    responseOK = Mathf.RoundToInt(questionNumber2) / Mathf.RoundToInt(questionNumber1);
                break;


        }

        if ((questionNumber2 > questionNumber1 && operationChar == '/') || questionNumber2 > questionNumber1 && operationChar == '-')
            questionText.text = "" + questionNumber2 + " " + operationChar + " " + questionNumber1;
        else
            questionText.text = "" + questionNumber1 + " " + operationChar + " " + questionNumber2;


        optionOK=Random.Range(1, 4);
        responseOther1 = responseOK - Random.Range(Mathf.RoundToInt(otherResponse1.x), Mathf.RoundToInt(otherResponse1.y));
        responseOther2 = responseOK + Random.Range(Mathf.RoundToInt(otherResponse2.x), Mathf.RoundToInt(otherResponse2.y));

        if (optionOK==1)
        {
            response1.text = "" + responseOK;
            response2.text = "" + responseOther1;
            response3.text = "" + responseOther2;

            //coinSpawner.GetComponent<CoinSpawner>().SetPos(1);
        }
        else if (optionOK == 2)
            
        {
            response1.text = "" + responseOther1;
            response2.text = "" + responseOK;
            response3.text = "" + responseOther2;
            //coinSpawner.GetComponent<CoinSpawner>().SetPos(2);
        }
        else if (optionOK == 3)
        {
            response1.text = "" + responseOther1;
            response2.text = "" + responseOther2;
            response3.text = "" + responseOK;
            //coinSpawner.GetComponent<CoinSpawner>().SetPos(3);
        }

        coinSpawner.GetComponent<CoinSpawner>().SetPos(optionOK);

    }

    public void ValidateResponse(int response)
    {
        if (response==responseOK)
        {
            GameManager_.CorrectCountAdd();
            coinSpawner.GetComponent<CoinSpawner>().SpawnCoin();

            
        }
        else
        {
            GameManager_.IncorrectCountAdd();
        }

        StartCoroutine(SpawnQuestion());

    }

    void Singletone()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

}
