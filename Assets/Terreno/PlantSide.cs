using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSide : MonoBehaviour
{
    public GameObject root;
    public float size;
    public static int plantsNum;
    public bool planted;
    void Start()
    {
        root.SetActive(false);
        plantsNum = 0;
        planted = false;
    }

    // Update is called once per frame
    void Update()
    {
		
    }
    public void Plant() 
    {
        if (!planted)
        {
            root.SetActive(true);
            planted = true;
            plantsNum++;
            GameController.AddGameValues(1, 1);
    
        }
    }
    public void Grow()
	{
		if (planted) 
        {
            size += 3;
            root.transform.localScale += new Vector3(0,size,0);
        }
	}
}
