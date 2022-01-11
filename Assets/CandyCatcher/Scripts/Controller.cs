using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Utility;

public class Controller : MonoBehaviour
{

    [Header("Stats")]
    [Space(10)]
    public float score;
    public float time = 60;
    public int life = 3;

    [Header("Settings")]
    [Space(10)]

    public float speed;
    public float margin = 30;
    public float timeIntervall = 1f;
    public bool timeMode;

    [Header("References")]
    [Space(10)]

    public UserData transferData;
    public GameObject player;
    public GameObject canvas;
    public GameObject timePanel;
    public GameObject candyContainer;
    public Camera cam;
    public Text scoreTxt;
    public Text timeTxt;




    private int ID = 0;



    private float canvWidth;
    private float canvHeight;
    public List<CandyData> candys; 
    public List<CandyData> candyData = new List<CandyData>();
    void Start()
    {
        GameEvents.current.onCandyCatched += CandyCatched;





        timeMode = transferData.timeMode;
        if(!timeMode) {
            timeTxt.text = "Leben: 3";
        }
        StartCoroutine(SpawnCandy());
        RectTransform canvRect = canvas.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        canvWidth = canvRect.rect.width;
        canvHeight = canvRect.rect.height;

    }


    void Update()
    {
        if(timeMode) {
            time -= Time.deltaTime;
            timeTxt.text = "Time: " + Parser.ParseFloatToString(time);

            if(time < 0) {
                transferData.score = (int)score;
                SceneManager.LoadScene("ScoreScene");
            }
        }


        if (Input.GetKey("a")) {
            if(-11.65f < player.transform.position.x) {
                player.transform.position = new Vector3(player.transform.position.x - speed, player.transform.position.y, player.transform.position.z);
            }
        } 
        if(Input.GetKey("d")) {
            if(11.65f > player.transform.position.x) {
                player.transform.position = new Vector3(player.transform.position.x + speed, player.transform.position.y, player.transform.position.z);
            }
        }
    }


    private IEnumerator SpawnCandy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeIntervall);
            var candyIndex = Random.Range(0, candys.Count);
            var screenPoint = new  Vector3 (Random.Range(margin, canvWidth - margin),canvHeight+ 100, 16);
            var worldPos = cam.ScreenToWorldPoint ( screenPoint );
            var obj = Instantiate(candys[candyIndex].candyPref, worldPos, Quaternion.identity);
            obj.transform.parent = candyContainer.transform;
            obj.transform.name = ID.ToString();
            if(!timeMode) {
                obj.GetComponent<Rigidbody>().drag = 1;
            }
            candyData.Add(candys[candyIndex]);
            ID++;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        Destroy(other.gameObject);
    }

    public void CandyCatched(int id) {
        if(candyData[id].goodCandy) {
            score += candyData[id].value;
        }  else {
            if(timeMode) {
                score -= candyData[id].value;
            } else {
                life--;
                timeTxt.text = "Leben: " + life.ToString();
                if(life <= 0) {
                    transferData.score = (int)score;
                    SceneManager.LoadScene("ScoreScene");
                }
            }
        }
        scoreTxt.text = "Score: " + score.ToString();
    }



}

