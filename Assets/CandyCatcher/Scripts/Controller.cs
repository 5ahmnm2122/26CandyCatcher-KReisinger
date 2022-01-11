using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Utility;

public class Controller : MonoBehaviour
{

    [Header("Stats")]
    [Space(10)]
    public float score;
    public float time = 60;

    [Header("Settings")]
    [Space(10)]

    public float speed;
    public float margin = 30;
    public float timeIntervall = 1f;

    [Header("References")]
    [Space(10)]

    public UserData transferData;
    public GameObject player;
    public GameObject canvas;
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

        StartCoroutine(SpawnCandy());
        RectTransform canvRect = canvas.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        canvWidth = canvRect.rect.width;
        canvHeight = canvRect.rect.height;
        GameEvents.current.onCandyCatched += CandyCatched;

    }


    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = "Time: " + Parser.ParseFloatToString(time);

        if(time < 0) {
            transferData.Score = score;
            SceneManager.LoadScene("ScoreScreen");
        }


        if (Input.GetKey("a")) {
            player.transform.position = new Vector3(player.transform.position.x - speed, player.transform.position.y, player.transform.position.z);
        } 
        if(Input.GetKey("d")) {
            player.transform.position = new Vector3(player.transform.position.x + speed, player.transform.position.y, player.transform.position.z);
        }
    }


    private IEnumerator SpawnCandy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeIntervall);
            var screenPoint = new  Vector3 (Random.Range(margin, canvWidth - margin),canvHeight+ 100, 16);
            var worldPos = cam.ScreenToWorldPoint ( screenPoint );
            var obj = Instantiate(candys[0].candyPref, worldPos, Quaternion.identity);
            obj.transform.parent = candyContainer.transform;
            obj.transform.name = ID.ToString();
            candyData.Add(candys[0]);
            ID++;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        Destroy(other.gameObject);
    }

    public void CandyCatched(int id) {
        score += candyData[id].value;
        scoreTxt.text = "Score: " + score.ToString();
    }



}

