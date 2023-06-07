using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public float maxHealth = 6;
    public float health;
    public GameObject arvore;
    public Transform arvorePoint;
    public HitValue hit;
    public Animator anima;
    float cooldown = 3.1f, time = 0;


    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > maxHealth) 
        {
            health = maxHealth;
        }
        PlantTree();
		if (Input.GetButtonDown("Interect") && time > cooldown) 
        {
            anima.SetTrigger("Interact");
            time = 0;
        }
        time += Time.deltaTime;
    }
    public void minusLife(float life) 
    {
        health -= life;
    }
    public void pluLife(float life)
    {
        health += life;
    }
    public void Die() 
    {
		if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
	private void OnTriggerStay(Collider other)
	{
        PlayerPlant(other);
    }
	private void OnTriggerEnter(Collider other)
	{
        PlayerPlant(other);
    }
    public void PlantTree() 
    {
		if (GameController.acoes > 0 && Input.GetButtonDown("PlantTree")) 
        {
            Instantiate(arvore, arvorePoint.position, arvorePoint.rotation);
            GameController.acoes--;
			
          
        }
    }
    void PlayerPlant(Collider colider) 
    {
        if (colider.gameObject.tag == "PlantSide" &&
            !colider.gameObject.GetComponent<PlantSide>().planted &&
            GameController.acoes > 0)
        {
            colider.gameObject.GetComponent<PlantSide>().Plant();
            GameController.acoes--;
            if (GameController.humanos % 2 == 0)
            {
                gameObject.GetComponent<PlayerMovement>().speed += 1;
                hit.humanBonus++;
            }
        }
		if (colider.gameObject.tag == "Gas" &&
            !GameController.gas) 
        {
            GameController.gas = true;
            GameController.acoes--;
            GameController.poluicao += 2;
        }
        
    }

}
