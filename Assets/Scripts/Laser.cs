using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //se move na velocidade 10
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //se a posição y do laser é maior ou igual 6
        //destroi o laser
        if (transform.position.y >= 6 )
        {
            Destroy(this.gameObject);
        }
    }

}
