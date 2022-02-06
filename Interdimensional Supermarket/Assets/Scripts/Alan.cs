using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Alan : MonoBehaviour
{
    private Transform t;
    public bool isUp;
    public int points = 0;
    public Text highScoreText;
    public Animator anim;
    public Powerup heldItem;
    public Vector3 inventoryPos;
    public TextMeshProUGUI CouponUses;
    public Powerup slushie;
    public Powerup bolt;
    public Powerup coupon;
    private GameManager gm;
    private Text txt;
    private AudioSource alanAudio, powerupAudio, gos;
    // Start is called before the first frame update
    public static bool activeBolt = false;
    void Start()
    {
        txt = GameObject.FindWithTag("coinText").GetComponent<Text>(); 
        t=gameObject.transform;
        anim=gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        alanAudio = gameObject.GetComponent<AudioSource>();
        gos = GameObject.FindGameObjectWithTag("gameoverSound").GetComponent<AudioSource>();
        powerupAudio = GameObject.FindGameObjectWithTag("PickUpSound").GetComponent<AudioSource>();
        Spawn();
    }

    public void Spawn(){
        ResetPosition();
        points = 0;
        highScoreText.text = "High score: " + StaticBoard.highScore;
        txt.text = "Score: " + points;
    }
    public void DisableCouponCounter(){
        CouponUses.gameObject.SetActive(false);
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
            gos.Play();
            gm.EndGame();
        }
        else if (target.gameObject.tag == "Powerup"){
            powerupAudio.Play();
            if (heldItem != null){
                Destroy(heldItem.gameObject);
            }
            Destroy(target.gameObject);
            switch (target.gameObject.name){
                case "Slushie(Clone)":
                    heldItem = Instantiate(slushie, inventoryPos, Quaternion.identity);
                    break;
                case "Bolt(Clone)":
                    heldItem = Instantiate(bolt, inventoryPos, Quaternion.identity);
                    break;
                case "coupon(Clone)":
                    heldItem = Instantiate(coupon, inventoryPos, Quaternion.identity);
                    Debug.Log(heldItem.name);
                    CouponUses.gameObject.SetActive(true);
                    CouponUses.text = "Uses: " + heldItem.GetComponent<CouponScript>().uses;
                    break;
                default:
                    Debug.Log(target.gameObject.name + " not found");
                    break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("u")) {
            points += 50;
        }
        if (!gm.hasStarted){
            return;
        }
        // if(Input.GetKeyDown("space")) {
        //     if(activeBolt) {
        //         Debug.Log("POWER");
        //         GameObject[] g = GameObject.FindGameObjectsWithTag("Customer");
        //         foreach(GameObject e in g) {
        //             e.transform.position = new Vector2(e.transform.position.x, 0);
        //         }
        //         activeBolt = false;
        //     }
        // }

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
            if (heldItem.name == "coupon(Clone)"){
                if (heldItem.GetComponent<CouponScript>().uses == 1){
                    DisableCouponCounter();
                    heldItem.Use();
                }
                else{
                    heldItem.Use();
                    CouponUses.text = "Uses: " + heldItem.GetComponent<CouponScript>().uses;
                }
            }
            else{
                heldItem.Use();
            }
        }
        anim.SetBool("isUp",isUp);
    }
}
