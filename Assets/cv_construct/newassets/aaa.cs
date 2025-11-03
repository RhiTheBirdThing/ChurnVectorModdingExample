using UnityEngine;

public class sdjkfaskdjf : MonoBehaviour
{
    public Transform object1; 
	public static Vector3 aaaaaa = new Vector3(1, 1, 1);
    void Update()
    {
	transform.localScale = object1.localScale + aaaaaa;
    }
}