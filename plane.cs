using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Plane: OnTriggerStay");
            Destroy(this.gameObject);
            Debug.Log("creat plane");
            Vector2 StartPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//左下
            Vector2 EndPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//右上
            float width = EndPos.x - StartPos.x;
            float height = EndPos.y - StartPos.y;
            float x = Random.Range(-0.45f*width,0.45f*width);//规定x轴方向上的范围
            float y = Random.Range(-0.45f*height,0.45f*height);
            GameObject p = Instantiate(Resources.Load("Plane") as GameObject);
            p.transform.localPosition = new Vector3(x,y,0);
            Score.touch += 1;
            Score.destroy += 1;
			Score.txt.text = Score.s+ " TouchedEnemy("+Score.touch+")"+" EGG:OnScreen("+Score.egg+")"+" ENEMY:Count(10) Destroyed("+Score.destroy+")";
        }
        else
        {
            if(life > 0)
            {
                life--;
                SpriteRenderer s = GetComponent<SpriteRenderer>();
                Color c = s.color;
                c.r = c.r * 0.8f;
                c.a = c.a * 0.8f;
                s.color = c;
                Debug.Log("Plane: Color = " + c);
                Destroy(collision.gameObject);
                Score.egg -= 1;
			    Score.txt.text = Score.s+ " TouchedEnemy("+Score.touch+")"+" EGG:OnScreen("+Score.egg+")"+" ENEMY:Count(10) Destroyed("+Score.destroy+")";
            }
            else if(life == 0)
            {
                life = 3;
                Debug.Log("Plane: OnTriggerStay");
                Destroy(this.gameObject);
                Debug.Log("creat plane");
                Vector2 StartPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//左下
                Vector2 EndPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//右上
                float width = EndPos.x - StartPos.x;
                float height = EndPos.y - StartPos.y;
                float x = Random.Range(-0.45f*width,0.45f*width);//规定x轴方向上的范围
                float y = Random.Range(-0.45f*height,0.45f*height);
                GameObject p = Instantiate(Resources.Load("Plane") as GameObject);
                p.transform.localPosition = new Vector3(x,y,0);
                Score.destroy += 1;
                Score.egg -= 1;
                Destroy(collision.gameObject);
			    Score.txt.text = Score.s+ " TouchedEnemy("+Score.touch+")"+" EGG:OnScreen("+Score.egg+")"+" ENEMY:Count(10) Destroyed("+Score.destroy+")";
            }
        }
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Plane: OnTriggerStay");
            Destroy(this.gameObject);
            Debug.Log("creat plane");
            float x=Random.Range(-180f,180f);//规定x轴方向上的范围
            float y=Random.Range(-90f,90f);//规定y轴方向上的范围
            GameObject p = Instantiate(Resources.Load("Plane") as GameObject);
            p.transform.localPosition = new Vector3(x,y,0);
        }
        else if(collision.gameObject.tag == "Respawn")
        {
            if(life > 0)
            {
                life--;
                SpriteRenderer s = GetComponent<SpriteRenderer>();
                Color c = s.color;
                c.r = c.r * 0.8f;
                c.a = c.a * 0.8f;
                s.color = c;
                Debug.Log("Plane: Color = " + c);
            }
            else if(life == 0)
            {
                Debug.Log("Plane: OnTriggerStay");
                Destroy(this.gameObject);
                Debug.Log("creat plane");
                float x=Random.Range(-180f,180f);//规定x轴方向上的范围
                float y=Random.Range(-90f,90f);//规定y轴方向上的范围
                GameObject p = Instantiate(Resources.Load("Plane") as GameObject);
                p.transform.localPosition = new Vector3(x,y,0);
            }
        }
    }*/
}