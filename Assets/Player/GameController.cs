using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int acoes;
    public static bool attack;
    public static List<GameObject> enimies;
    public static List<GameObject> spawns; 
    public static List<PlantSide> plants; 
    public static int enimyNumbers = 1;
    public static float humanos;
    public static float poluicao;
    public static float houseMaxLife = 3;
    public static float houseLife;
    public GameObject enimy;
    public bool wave;
    public Text txtHumanos;
    public Text txtPoluicao;
    public Text txtBonus;
    public static bool gas;
    public static bool gased;
    public Text txtFazenda;
    public GameObject reset;
    // Start is called before the first frame update
    void Start()
    {
        enimies = new List<GameObject>();
        spawns = new List<GameObject>();
        plants = new List<PlantSide>();
        houseMaxLife = 3;
        houseLife = 3;
        enimyNumbers = 1;
        humanos = 0;
        poluicao = 0;
        acoes = 3;
        spawns.AddRange(GameObject.FindGameObjectsWithTag("Spawns"));
        plants.AddRange(GameObject.FindObjectsOfType<PlantSide>());
        houseLife = houseMaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        StartWave();
        txtHumanos.text = "Humanos: " + humanos;
        txtPoluicao.text = "Poluição: " + poluicao;
        txtFazenda.text = "Fazenda: " + houseLife;  
		if (GameObject.FindGameObjectWithTag("playerDamage") != null) 
        {
            txtBonus.text = "Bonus: " + (GameObject.FindGameObjectWithTag("playerDamage").GetComponent<HitValue>().bonus + GameObject.FindGameObjectWithTag("playerDamage").GetComponent<HitValue>().humanBonus).ToString()  ;
            if (gas && !gased)
            {
                GameObject.FindGameObjectWithTag("playerDamage").GetComponent<HitValue>().bonus += 3;
                gased = true;
            }
        }
		
        else 
        {
            txtBonus.text = "";
        }
		if (houseLife > houseMaxLife) 
        {
            houseLife = houseMaxLife;
        }
		if (houseLife <= 0) 
        {
            wave = false;
            Time.timeScale = 0;
            reset.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void StartWave() 
    {
		if (acoes <= 0 && !wave) 
        {
            for (int i = 0; i < enimyNumbers; i++)
            {
            foreach (GameObject a in spawns)
            {
                StartCoroutine(Spwan(a.transform));
            }
            }
            wave = true;
        }
		else if (acoes <= 0  && wave) 
        {
            if (enimies.Count == 0) 
            {
                if (gased)
                {
                    GameObject.FindGameObjectWithTag("playerDamage").GetComponent<HitValue>().bonus -= 2;
                }
                gased = false;
                acoes += 3;
                enimyNumbers++;
                wave = false;
                gas = false;
				foreach (PlantSide p in plants) 
                {
                    p.Grow();
                }
                houseLife += humanos / 2;
            }
        }
        
    }
    public static void AddGameValues(float humanosc, float poluicaoc) 
    {
        humanos += humanosc;
		if (humanos % 2 == 0) 
        {
            houseMaxLife += 1;
            houseLife += 1;
        }
        poluicao += poluicaoc;
    }
    IEnumerator Spwan(Transform local) 
    {
        Instantiate(enimy, local.position, local.rotation);
        yield return new WaitForSeconds(2f); 
    }
    
}
