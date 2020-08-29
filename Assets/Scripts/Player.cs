using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    



    // Start is called before the first frame update
    void Start()
    {
        //chama o nome dos objetos em que os script esta vinculado
        //Debug.Log("Name:"+ name);

        //chama a posição x do objeto em que o scrip esta vinculado
        //Debug.Log("x pos: " + transform.position.x);

        //transform é a posição, rotação e escala do objeto
        //posição = nova posição
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }


    private void Movement()
    {
                //o objeto se move a 1 metro por segundo.
        //transform.Translate(Vector3.right * Time.deltaTime);

        //o objeto se move a 5 metros por segundo.
        //transform.Translate(Vector3.right * Time.deltaTime * 5);    
        
        //novo vetor(-5 ou -1?,0,0) * 1 * velocidade
        // transform.Translate(Vector3.right * Time.deltaTime * speed);

        //movimentação básica
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime );
        transform.Translate(Vector3.up * speed * verticalInput *  Time.deltaTime );
        
        //limitar area do jogador (eixo vertical)
        // se o jogador_y é maior q 0
        //jogador_y fica em 0 em Y
        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y < -4.2f)
        {
        transform.position = new Vector3(transform.position.x, -4.2f ,0);
        }

        //se a posição de x é maior q 9.5
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
