using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HoleManager : MonoBehaviour
{

    private float circleCapacity;
    [SerializeField] private Image circleImg;
    [SerializeField] private Transform holeTransform;
    [SerializeField] private TextMeshProUGUI timer_txt;


    [Serializable] public class HoleSizeClass{
        public Vector3 size;
    }

    HoleSizeClass _holeSizeClass = new HoleSizeClass();

    void Start()
    {
        StartCoroutine(timer(20));
    }

    private void progressBarCircle(int number){
        circleCapacity = 1f/number;

        circleImg.fillAmount += circleCapacity;

        if(circleImg.fillAmount.Equals(1f)){
            holeTransform.localScale += new Vector3(0.3f,0,0.3f);
            holeTransform.position=new Vector3(holeTransform.position.x,0,holeTransform.position.z);
            circleImg.fillAmount =0f;

            _holeSizeClass.size = holeTransform.localScale;

            string SetToJson = JsonUtility.ToJson(_holeSizeClass);
        }

    } 

    private IEnumerator timer(int time){
        int remainTime = time;
        while (remainTime >= 0f)
        {
            timer_txt.text = "00:"+remainTime;
            remainTime--;

            if(remainTime <= 0f){
                yield return new WaitForSecondsRealtime(2f);
                SceneManager.LoadScene("Boss");
            }

            yield return new WaitForSecondsRealtime(1f);
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Collectable")){
            progressBarCircle(5);
            other.gameObject.SetActive(false);
            DataManager.Instance.Collectable = 1;
        }
    }
}
