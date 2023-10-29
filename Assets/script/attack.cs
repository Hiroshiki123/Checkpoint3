using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    bool ataquePronto;
    public GameObject ataque;
    public GameObject corte;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posicao = new Vector2(transform.position.x + 1f, transform.position.y);
        if (Input.GetButtonDown("Fire1"))
        {
            corte = Instantiate( ataque,posicao,transform.rotation);
        }
    }
}
