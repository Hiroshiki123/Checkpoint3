using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    bool ataquePronto;
    public GameObject ataque;
    public float direcao;
    public float tempo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direcao = Input.GetAxisRaw("Horizontal");

        tempo -= Time.deltaTime;
        if (tempo < 0)
        {
            ataquePronto = true;
            ataque.SetActive(false);
        }
        if (Input.GetButtonDown("Fire1")&& ataquePronto)
        {
            ataque.SetActive(true);
            ataquePronto = false;
            tempo = 0.5f;
        }
        if (direcao > 0)
        {
            ataque.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (direcao < 0)
        {
            ataque.transform.eulerAngles = new Vector3(0, 180f, 0);
        }
    }
}
