using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enimy : MonoBehaviour
{
    public float life = 3;
    Rigidbody rg;
    public Transform house;
    public static float velocity = 4;
    NavMeshAgent enimyNav;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        enimyNav = GetComponent<NavMeshAgent>();
        house = GameObject.FindGameObjectWithTag("Casa").transform;
        enimyNav.speed = velocity;
        GameController.enimies.Add(gameObject);
        velocity += GameController.poluicao / 3;
        velocity += GameController.enimyNumbers / 3;
        life += GameController.poluicao / 3;
        life += GameController.enimyNumbers;
    }

    // Update is called once per frame
    void Update()
    {
		if (life <= 0) 
        {
            GameController.enimies.Remove(gameObject);   
            Destroy(gameObject);
        }
		else  
        {
            enimyNav.acceleration = velocity;
            enimyNav.SetDestination(house.position);

        }

    }
	private void FixedUpdate()
	{
        rg.velocity = new Vector3(0, 0, 0);
	}
	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "playerDamage") 
        {
            life -= other.GetComponent<HitValue>().damage;
        }
        else if (other.gameObject.tag == "Casa") 
        {
            GameController.houseLife -= 1;
            life = 0;
        }
	}
  
}
