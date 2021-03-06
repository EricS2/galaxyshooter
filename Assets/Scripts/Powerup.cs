﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID; // 0 = triple shot, 1 = speed, 2 = shield

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    //exibir o outro objeto da colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);
        //acessar o player
        if (other.tag == "Player");
       Player player = other.GetComponent<Player>();
       if (player != null)
       {
           if (powerupID == 0)
           {
            player.TripleShotPowerupOn();
           }
           else if (powerupID == 1)
           {
            player.SpeedBoostPowerupOn();
           }
           else if (powerupID == 2);
           {
            player.EnableShields();
           }
           
       }

       
       //destroy o power up na colisão
      Destroy(this.gameObject); 
    }
}
