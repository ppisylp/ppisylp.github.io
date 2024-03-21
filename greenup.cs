using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenup : MonoBehaviour
{
    public bool mFollowMousePosition = true;
    public float mHeroSpeed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; // 90-degrees in 2 seconds
    private float LastTime = 0f;
    void Start()
    {
        Debug.Log("Arrow: Started");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            mFollowMousePosition = !mFollowMousePosition;
        }
        if (mFollowMousePosition)
        {
	        Score.s="HERO:Drive(Mouse)";
            Score.txt.text = Score.s+ " TouchedEnemy("+Score.touch+")"+" EGG:OnScreen("+Score.egg+")"+" ENEMY:Count(10) Destroyed("+Score.destroy+")";
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = screenPos.z;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.localPosition = worldPos;
        }
        else
        {
            Score.s="HERO:Drive(Key)";
            Score.txt.text = Score.s+ " TouchedEnemy("+Score.touch+")"+" EGG:OnScreen("+Score.egg+")"+" ENEMY:Count(10) Destroyed("+Score.destroy+")";
            transform.localPosition += ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);
            if (Input.GetKey(KeyCode.W))
            {
                mHeroSpeed += 0.01f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                //transform.localPosition += ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);
                mHeroSpeed -= 0.01f;
            }
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(transform.forward,  mHeroRotateSpeed * Time.smoothDeltaTime);

            if (Input.GetKey(KeyCode.D))
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
        }
        // Move this object to mouse position
        /*Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        transform.localPosition = p;*/

        // Now spawn an egg when space bar is hit
        if (Input.GetKey(KeyCode.Space))
        {
            if(Time.time - LastTime >= 0.2f)
            {
                GameObject e = Instantiate(Resources.Load("Egg") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
                e.transform.localPosition = transform.localPosition;
                Debug.Log("Spawn Eggs:" + e.transform.localPosition);
                e.transform.up = transform.up;
                LastTime = Time.time;
                Score.egg += 1;
			    Score.txt.text = Score.s+ " TouchedEnemy("+Score.touch+")"+" EGG:OnScreen("+Score.egg+")"+" ENEMY:Count(10) Destroyed("+Score.destroy+")";
            }
        }
    }
}