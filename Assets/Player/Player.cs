using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 6;
    public float health;
    public GameObject arvore;
    public Transform arvorePoint;
    public HitValue hit;
    public float bonus;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health > maxHealth) 
        {
            health = maxHealth;
        }
        PlantTree();
        hit.bonus = bonus;
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
        if (Input.GetButtonDown("Interect") && 
            other.gameObject.tag == "PlantSide" && 
            !other.gameObject.GetComponent<PlantSide>().planted && 
            GameController.acoes > 0)
        {
            other.gameObject.GetComponent<PlantSide>().Plant();
            GameController.acoes--;
           
        }
    }
	private void OnTriggerEnter(Collider other)
	{
        if (Input.GetButtonDown("Interect") && 
            other.gameObject.tag == "PlantSide" && 
            !other.gameObject.GetComponent<PlantSide>().planted && 
            GameController.acoes > 0)
        {
            other.gameObject.GetComponent<PlantSide>().Plant();
            GameController.acoes--;

        }
    }
    public void PlantTree() 
    {
		if (GameController.acoes > 0 && Input.GetButtonDown("PlantTree")) 
        {
            Instantiate(arvore, arvorePoint.position, arvorePoint.rotation);
            GameController.acoes--;
        }
    }
}
