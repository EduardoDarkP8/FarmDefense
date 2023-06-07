using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAtack : MonoBehaviour
{
        public float time;
        public float coolDown = 1.10f;
        public Animator anima;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
		    if (time > coolDown) 
            {
			    if (Input.GetButton("Fire1")) 
                {
                    anima.SetTrigger("Atack");
                    time = 0;
                }
            }
            time += Time.deltaTime;
        }
    

}
