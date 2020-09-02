using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
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
        if (other.tag == "Player") ;
       Player player = other.GetComponent<Player>();
       if (player != null)
       {
           player.TripleShotPowerupOn();
           
       }

       
       //destroy o power up na colisão
      Destroy(this.gameObject); 
    }
}
