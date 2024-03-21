using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    private const float kEggSpeed = 40f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();
        if (s != null)   // if main camera does not have the script, this will be null
        {
            // intersect my bond with the bounds of the world
            Bounds myBound = GetComponent<Renderer>().bounds;  // this is the bound on the SpriteRenderer
            CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);
            
            // If result is not "inside", then, move the hero to a random position
            if (status != CameraSupport.WorldBoundStatus.Inside)
            {
                Debug.Log("Touching the world edge: " + status);
                Destroy(gameObject);  // kills self
                Score.egg -= 1;
			    Score.txt.text = Score.s+ " TouchedEnemy("+Score.touch+")"+" EGG:OnScreen("+Score.egg+")"+" ENEMY:Count(10) Destroyed("+Score.destroy+")";
            }
        }
        this.transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);
    }
}
