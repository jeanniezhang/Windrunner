using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    //determines frequency objects will be generated in the game
    [SerializeField] private float maxTime;
    //timer lol
    private float timer;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject obstacle5;
    public GameObject obstacle6;
    public GameObject obstacle7;
    public GameObject obstacle8;

    private int choose;
    
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 0.75f;//1.5
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= maxTime)
        {
            GenerateObject();
            timer = 0f;
        }
    }

    void GenerateObject()
    {
        choose = Random.Range(1, 15);//1,10
        if (choose == 1)
        {
            GameObject newObstacle = Instantiate(obstacle1);
        }
        if (choose == 2)
        {
            GameObject newObstacle = Instantiate(obstacle2);
        }
        if (choose == 3)
        {
            GameObject newObstacle = Instantiate(obstacle3);
        }
        if (choose == 4)
        {
            GameObject newObstacle = Instantiate(obstacle4);
        }
        if (choose == 5)
        {
            GameObject newObstacle = Instantiate(obstacle5);
        }
        if (choose == 6)
        {
            GameObject newObstacle = Instantiate(obstacle6);
        }
        if (choose == 7)
        {
            GameObject newObstacle = Instantiate(obstacle7);
        }
        if (choose == 8)
        {
            GameObject newObstacle = Instantiate(obstacle8);
        }
    }
}
