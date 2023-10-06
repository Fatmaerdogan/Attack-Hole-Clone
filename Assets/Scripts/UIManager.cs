using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text RegularButtonText;
    [SerializeField] private List<GameObject> GameFinishList;
    void Start()
    {
         CollectableChance();
         Events.OnCollectableChance += CollectableChance;
         Events.OnGameFinish += GameFinish;
    }
    private void OnDisable()
    {
        Events.OnCollectableChance -= CollectableChance;
        Events.OnGameFinish -= GameFinish;
    }
    public void RegularButtonPlay()
    {
        if (DataManager.Instance.Collectable > 0)
        {
            Events.OnAttackBoss?.Invoke();
        }
    }
    public void CollectableChance()
    {
        RegularButtonText.text = DataManager.Instance.Collectable.ToString();
    }
    public void GameFinish(bool temp)
    {
        GameFinishList[0].SetActive(temp);
        GameFinishList[1].SetActive(!temp);
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene(0);
    }
}
