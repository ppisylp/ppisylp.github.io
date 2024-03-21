using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creat : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        for(int i =0;i<9;i++)
        {
            Debug.Log("creat plane");
            float x=Random.Range(-180f,180f);//规定x轴方向上的范围
            float y=Random.Range(-90f,90f);//规定y轴方向上的范围
            GameObject p = Instantiate(Resources.Load("Plane") as GameObject);
            p.transform.localPosition = new Vector3(x,y,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
