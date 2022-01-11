using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Controller : MonoBehaviour
{
    public UserData transferData;
    public GameObject player;
    public GameObject canvas;
    public Camera cam;
    public float time = 60;
    public float margin = 30;
    

    private float canvWidth;
    private float canvHeight;
    public List<GameObject> goodCandy; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCandy());
        RectTransform canvRect = canvas.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        canvWidth = canvRect.rect.width;
        canvHeight = canvRect.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (Input.GetKey("a")) {

        } 
        if(Input.GetKey("d")) {
            
        }
    }


    private IEnumerator SpawnCandy()
    {
        while (true)
        {
            var screenPoint = new  Vector3 (Random.Range(margin, canvWidth - margin),canvHeight+ 50, 5);
            var worldPos = cam.ScreenToWorldPoint ( screenPoint );
            var obj = Instantiate(goodCandy[0], worldPos, Quaternion.identity );
            yield return new WaitForSeconds(1f);
           
        }
    }



}

