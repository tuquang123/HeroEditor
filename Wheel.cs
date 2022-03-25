using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    private int randomvalue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;

    public int Reward;

    [SerializeField]
    private Text winText;


    // Use this for initialization
    private void Start()
    {
        coroutineAllowed = true;

    }

    // Update is called once per frame
    private void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && coroutineAllowed)
        if(Input.GetMouseButtonDown(0)  && coroutineAllowed)
            StartCoroutine(Spin());
       
    }
    private IEnumerator Spin()
    {
        coroutineAllowed = false;
        randomvalue = Random.Range(30, 100);
        timeInterval = 0.1f;


        for (int i = 0; i < randomvalue; i++)
        {

            transform.Rotate(0, 0, 22.5f);
            if (i > Mathf.RoundToInt(randomvalue * 0.5f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomvalue * 0.85f))
                timeInterval = 0.4f;
            yield return new WaitForSeconds(timeInterval);
        }
        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
            transform.Rotate(0, 0, 22.5f);
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (finalAngle)
        {
            case 0 :
                winText.text  = "1";
                Reward = 1;
                break;
            case 45 :
                winText.text = "2";
                Reward = 2;
                break;
            case 90:
                winText.text = "3";
                Reward = 3;
                break;
            case 135:
                winText.text = "4";
                Reward = 4;
                break;
            case 180:
                winText.text = "5";
                Reward = 5;
                break;
            case 225:
                winText.text = "6";
                Reward = 6;
                break;
            case 270:
                winText.text = "7";
                Reward = 7;
                break;
            case 315:
                winText.text = "8";
                Reward = 8;
                break;
        }
        coroutineAllowed = true;
        Debug.Log(winText.text);

    }
}
