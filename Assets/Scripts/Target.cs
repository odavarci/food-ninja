using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    Rigidbody targetRB;
    float xRange = 5, torqueRange = 10;
    [SerializeField] float forceUpper = 16, forceLower = 12; 
    public int point = 5;
    public ParticleSystem particle;


    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        AddRandomForce();
        AddRandomTorque();
        RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomPosition()
    {
        transform.position = new Vector3( Random.Range(-xRange,xRange), -2,0 );
    }

    void AddRandomTorque()
    {
        targetRB.AddTorque(new Vector3( Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange)), ForceMode.Impulse );
    }

    void AddRandomForce()
    {
        targetRB.AddForce(new Vector3(0, Random.Range(forceLower, forceUpper) ,0), ForceMode.Impulse);
    }

    private void OnMouseDown() {
        GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gm.UpdateScore(point);
        Instantiate(particle, transform.position, particle.transform.rotation);
        Destroy(gameObject);    
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if(other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().GameOver();
        }
    }
}
