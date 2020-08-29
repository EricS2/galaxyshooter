using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //se espaço ou click é pressionado
        //disparar o laser
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            //Time.time = é o tempo em segundos desde que a aplicação foi iniciada
            // ou seja 3 minutos jogo Time.Time será 180 segundos
            if (Time.time > _canFire)
            {
              Shoot();
            }
        }

    }

    private void Shoot()
    {
          //renderizar a prefab  na posição do jogador
                //Instantiate(nome_prefab, posição do jogador, mantém o valor de rotação) 
                // Instantiate(laserPrefab, transform.position, Quaternion.identity);
                
                //renderizar prefab acima do jogador
                Instantiate(_laserPrefab, transform.position + new Vector3(0,0.88f,0),Quaternion.identity);
                
                //cooldown
                _canFire = Time.time + _fireRate;
    }

    private void Movement()
    {
        //movimentação básica
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime );
        transform.Translate(Vector3.up * _speed * verticalInput *  Time.deltaTime );
        
        //limitar area do jogador (eixo vertical)
        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y < -4.2f)
        {
        transform.position = new Vector3(transform.position.x, -4.2f ,0);
        }
        //transição do jogador p/ outro lado da tela
        //eixo horizontal
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y,0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y,0);
        }

    }
}
