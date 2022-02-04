using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SpawnManager SpawnManager_;
    public ButtonBehaviour ButtonBehaviour_;
    public Player PlayerController;

    [SerializeField]
    private GameObject _Player;

    public bool _playing;

    public GameObject menuPrincipal;
    public GameObject pantallaJuego;
    public GameObject pantallaTienda;

    public Text CoinsValue;
    public Text CorrectValue;
    public Text IncorrectValue;

    [HideInInspector]
    public int correctCount;
    [HideInInspector]
    public int incorrectCount;

    [Header("Datos de Guardado")]
    public int coinsCount;
    public string nombre = "";
    public int edad = 0;
    [Space]

    [HideInInspector]
    public int totalCorrect = 0;
    [HideInInspector]
    public int totalIncorrect = 0;

    [Header("Guardado y Carga")]
    public GameObject pantallaGyC;
    [Space]
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    [Space]
    public TextMeshProUGUI gYCTitulo;
    public TextMeshProUGUI dato1;
    public TextMeshProUGUI dato2;
    public TextMeshProUGUI dato3;

    private int responseValue = 0;
    private int responseOption = 0;
    private bool toMove = false;

    bool pausa = true;

    [Space]
    public GameObject carroSeleccionado;

    public GameObject coin;

    public TextMeshProUGUI monedaTienda;

    public GameObject pantallaPerfil;

    //Estado estado;

    private void Awake()
    {
        instance = this;
        pantallaGyC.SetActive(false);
        //estado = GetComponent<Estado>();

        //if (estado.name == "")
        //    pantallaPerfil.SetActive(true);
        //else
        //    Destroy(pantallaPerfil);
    }

    void Start()
    {
        pantallaTienda.SetActive(true);
        menuPrincipal.SetActive(true);
        _playing = false;
        pantallaTienda.SetActive(false);
        monedaTienda.text = coinsCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (_playing)
        {
            ProcessResponse();
        }
    }

    public void InitGame()
    {
        //FuelController.instance.starBurn = true;
        _playing = true;

        GetComponent<BackGroundParallax>().canRun = true;
        menuPrincipal.SetActive(false);
        pantallaJuego.SetActive(true);

        _Player.GetComponent<SpriteRenderer>().sprite = carroSeleccionado.GetComponent<ICarro>().ImagenCarro.sprite;

        PlayerController = Instantiate(_Player, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Player>();

        if (_playing)
            SpawnManager_.SpawnStart();


        correctCount = 0;
        incorrectCount = 0;

        CoinsValue.text = "" + 0;
        CorrectValue.text = "" + 0;
        IncorrectValue.text = "" + 0;



    }

    private void ProcessResponse()
    {
        if (ButtonBehaviour_.toMove)
        {
            responseValue = ButtonBehaviour_.responseValue;
            responseOption = ButtonBehaviour_.responseOption;
            toMove = ButtonBehaviour_.toMove;

            //Debug.Log("To Move: " + responseValue + " " + responseOption);

            PlayerController.Move(toMove, responseOption);
            SpawnManager_.ValidateResponse(responseValue);

            responseValue = 0;
            responseOption = 0;
            toMove = false;
            ButtonBehaviour_.resetResponse();
        }
    }

    public void CorrectCountAdd()
    {
        totalCorrect++;
        correctCount++;
        CorrectValue.text = "" + correctCount;
        //estado.cantOk++;

    }
    public void IncorrectCountAdd()
    {
        totalIncorrect++;
        incorrectCount++;
        IncorrectValue.text = "" + incorrectCount;
        //estado.cantError++;
    }
    public void CoinsCountAdd()
    {
        coinsCount++;
        UIUpdate();
        //estado.cantCoins++;
    }

    public void UIUpdate()
    {
        CoinsValue.text = "" + coinsCount;

    }

    public void StopGame()
    {
        //menuPrincipal.SetActive(false);
        //Time.timeScale = 0;
        menuPrincipal.SetActive(true);
        pantallaJuego.SetActive(false);
        //botonesUI.GetComponentInChildren<MenuController>().PresBackOperaciones();
        SpawnManager_.StopAllCoroutines();
        GetComponent<BackGroundParallax>().canRun = false;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }


    public void Playing()
    {
        if (pausa)
        {
            Time.timeScale = 0;
            pausa = !pausa;
            GetComponent<BackGroundParallax>().canRun = false;
            _playing = false;
        }
        else
        {
            Time.timeScale = 1;
            pausa = !pausa;
            GetComponent<BackGroundParallax>().canRun = true;
            _playing = true;
        }
    }

    public void Reinicio()
    {
        SceneManager.LoadScene("sceGame Mod");
    }

    //private void OnApplicationQuit()
    //{
    //    GetComponent<GuardaYCarga>().Guardar();
    //}

    public void SalirJuego()
    {
        Application.Quit();
    }

}
