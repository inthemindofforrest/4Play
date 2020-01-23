using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWall : MonoBehaviour
{
    public GameObject textGameObject;
    // Start is called before the first frame update
    void Start()
    {
        

    string text = (Random.value * 10).ToString();

        textGameObject.GetComponent<TextMesh>().text = text;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
