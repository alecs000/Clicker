using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject recordsBacground;
    [SerializeField] Animator titlesMoving;
    [SerializeField] Text score;
    [SerializeField] GameObject[] gampleyObjects;
    [SerializeField] EnemiesBehavior enemiesBehavior;
    void Update()
    {
        score.text = "Score: " + GameManager.instance.score;
    }
    public void StartGame()
    {
        menu.SetActive(false);
        enemiesBehavior.StartSpawn();
        foreach (var item in gampleyObjects)
            item.SetActive(true);
    }
    public void ShowScore(GameObject record)
    {
        menu.SetActive(false);
        recordsBacground.SetActive(true);
        record.GetComponent<Text>().text = "";
        var scArr = GameManager.instance.scoreArray;
        Array.Sort(scArr);
        for (int i = scArr.Length - 1; i >= 0; i--)
        {
            if(scArr[i]!= 0)
            record.GetComponent<Text>().text += "score: "+ scArr[i] + "\n\n";
        }
    }
    public void BackgroundScoreClick(GameObject record)
    {
        recordsBacground.SetActive(false);
        menu.SetActive(true);
    }
    public void ShowTitles(GameObject background)
    {
        background.SetActive(true);
        menu.SetActive(false);
        StartCoroutine(ComplicateCorout(background));
    }
    private IEnumerator ComplicateCorout(GameObject background)
    {
        yield return new WaitForSeconds(9.1f);
        background.SetActive(false);
        menu.SetActive(true);
    }
    public void BackgroundTitlesClick(GameObject background)
    {
        background.SetActive(false);
        menu.SetActive(true);
    }
    public void ExitGame()
    {
        Debug.LogWarning("Application.Quit() - не работает в редакторе unity!(Quit call is ignored in the Editor)");
        Application.Quit();
    }
}
