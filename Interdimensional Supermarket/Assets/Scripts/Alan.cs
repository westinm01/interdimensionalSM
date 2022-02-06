using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alan : MonoBehaviour
{
    private Transform t;
    public bool isUp;
    public int points = 0;
    public Text highScoreText;
    public Animator anim;
    public Powerup heldItem;
    public Vector3 inventoryPos;
    private GameManager gm;
    private Text txt;
    private AudioSource alanAudio;
    // Start is called before the first frame update
    public static bool activeBolt = false;
    void Start()
    {
        txt = GameObject.FindWithTag("coinText").GetComponent<Text>(); 
        t=gameObject.transform;
        anim=gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        alanAudio = gameObject.GetComponent<AudioSource>();
        Spawn();
    }

    public void Spawn(){
        ResetPosition();
        points = 0;
        highScoreText.text = "High score: " + StaticBoard.highScore;
        txt.text = "Score: " + points;
    }

    void ResetPosition(){
        gameObject.transform.position = new Vector3(0, 0);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.tag == "Coin") {
            // Destroy(target.gameObject);
            // target.gameObject.transform.position = new Vector3(5,5);
            int x, y;
            Vector3 newPos;
            x = Random.Range(0, 7);
            y = Random.Range(0, -7);
            newPos = new Vector3(x, y); 
            target.transform.position = newPos;
            alanAudio.Play();
            points += 1;
            if (points > StaticBoard.highScore){
                StaticBoard.highScore = points;
            }

            txt.text = "Score: " + points;
            highScoreText.text = "High score: " + StaticBoard.highScore;
        }
        if (target.gameObject.tag == "Customer"){
            gm.EndGame();
        }
        else if (target.gameObject.tag == "Powerup"){
            heldItem = target.gameObject.GetComponent<Powerup>();
            target.gameObject.transform.position = inventoryPos;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!gm.hasStarted){
            return;
        }
        if(Input.GetKeyDown("space")) {
            if(activeBolt) {
                Debug.Log("POWER");
                GameObject[] g = GameObject.FindGameObjectsWithTag("Customer");
                foreach(GameObject e in g) {
                    e.transform.position = new Vector2(e.transform.position.x, 0);
                }
                activeBolt = false;
            }
        }

        if((Input.GetKeyDown("up") || Input.GetKeyDown("w") )&& t.position.y<0){
            t.position+= new Vector3(0,1);
            isUp=true;
        }
        else if((Input.GetKeyDown("down") || Input.GetKeyDown("s") )&& t.position.y>-1*StaticBoard.numRows+1){
            t.position+= new Vector3(0,-1);
            isUp=false;
        }
        else if((Input.GetKeyDown("right") || Input.GetKeyDown("d") ) && t.position.x<StaticBoard.numCols-1){
            t.position+= new Vector3(1,0);
        }
        else if((Input.GetKeyDown("left") || Input.GetKeyDown("a") )&&t.position.x>0){
            t.position+= new Vector3(-1,0);
        }
        if (Input.GetKeyDown("f") && heldItem != null){
            heldItem.Use();
        }
        anim.SetBool("isUp",isUp);
    }
}
