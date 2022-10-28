using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] foodPerfabs;

    public GameObject owner;
    public GameObject[] runMoon;

    public Text ScorceText;
    public int Scorce = 0;

    public bool isMoon = false;

    public PlayerManager player;

    public GameObject[] showRes;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(DropFood());
        StartCoroutine(showOwner());
    }

    private IEnumerator DropFood() {
        while (true)
        {
            var go = GameObject.Instantiate(foodPerfabs[Random.Range(0, foodPerfabs.Length)], new Vector3(Random.Range(0, 15f) - 7.5f, 4.8f, 0), Quaternion.identity, null);
            Destroy(go, 10f);
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator showOwner() {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(9f, 11f));
            owner.SetActive(true);
            runMoon[0].SetActive(false);
            runMoon[1].SetActive(true);

            yield return new WaitForSeconds(0.5f);
            isMoon = true;
            yield return new WaitForSeconds(2.5f);
            owner.SetActive(false);
            runMoon[1].SetActive(false);
            runMoon[0].SetActive(true);
            isMoon = false;

        }
    }




    public void GetSorce() {

        Scorce++;
        ScorceText.text = "score £º" + Scorce;
        if (Scorce >= 15) {
            Time.timeScale = 0;
            GameWin();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoon) {

            if (Mathf.Abs(player.rig.velocity.magnitude)> 0.3f) {
                Time.timeScale = 0;
                GameOver();
            }
        }
        
    }

    public void GameOver() {
        showRes[1].SetActive(true);
        Debug.Log("GameOver");
    }

    public void GameWin()
    {
        showRes[0].SetActive(true);
        Debug.Log("GameWin");
    }

    public void LoadScene() {

        SceneManager.LoadScene(0);
    }
}
