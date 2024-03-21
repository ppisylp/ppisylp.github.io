using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	public static Text txt;//定义静态变量名以用于其他脚本内的引用**
	public static float egg = 0;
	public static float touch = 0;
	public static float destroy = 0;
	public static string s;
	void Start () 
	{
		txt = GameObject.Find ("Text").GetComponent<Text> ();	 
	}
}


