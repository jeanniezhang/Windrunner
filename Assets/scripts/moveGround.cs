using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGround : MonoBehaviour
{
    //variables
    [SerializeField] private float speed;
    [SerializeField] private float start;
    [SerializeField] private float end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves background according to the speed variable 
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        //repositioning the background and destroying obstacles
        if (transform.position.x <= end)
        {
            if (gameObject.tag =="obstacle")
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector2(start, transform.position.y);
            }
        }
    }
}
