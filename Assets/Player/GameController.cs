using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int acoes;
    public static bool attack;
    public static List<GameObject> enimies = new List<GameObject>();
    public static List<GameObject> spawns = new List<GameObject>();
    public static List<PlantSide> plants = new List<PlantSide>();
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
    public bool gas;
    public bool gased;
    public Text txtFazenda;
    // Start is called before the first frame update
    void Start()
    {
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
            txtBonus.text = "Bonus: " + GameObject.FindGameObjectWithTag("playerDamage").GetComponent<HitValue>().bonus.ToString();
            if (gas && !gased)
            {
                GameObject.FindGameObjectWithTag("playerDamage").GetComponent<HitValue>().bonus += 2;
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
    }
    public void StartWave() 
    {
		if (acoes <= 0 && !wave) 
        {
            print("AA");
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
                acoes += 2;
                enimyNumbers++;
                wave = false;
                gas = false;
				foreach (PlantSide p in plants) 
                {
                    p.Grow();
                }
               
            }
        }
        
    }
    public static void AddGameValues(float humanosc, float poluicaoc) 
    {
        humanos += humanosc;
        poluicao += poluicaoc;
    }
    IEnumerator Spwan(Transform local) 
    {
        Instantiate(enimy, local.position, local.rotation);
        yield return new WaitForSeconds(2f); 
    }
}
