using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class spawner : MonoBehaviour
{
    //spawn eggs
    [SerializeField] float minDelay;
    [SerializeField] Vector2[] poses;
    [SerializeField] GameObject gEgg;
    [SerializeField] GameObject egg;
    private int random;

    //lives management
    [SerializeField] TMPro.TMP_Text score;
    [SerializeField] GameObject[] lives;
    [SerializeField] Sprite heartDisabled;

    private int i = 3;
    private void Start()
    {
        i = 3;
        StartCoroutine(spawn());
    }
    private IEnumerator spawn()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            random = Random.Range(0, 3);
            GameObject inst = Instantiate(Random.Range(0, 5) > 4 ? gEgg : egg, poses[random], Quaternion.identity);
            if(random < 2)
            {
                inst.layer = 6;
            }
            else
            {
                inst.layer = 7;
            }
            yield return new WaitForSeconds(Mathf.Clamp(3 - Mathf.Sqrt(Mathf.Sqrt(int.Parse(score.text))),minDelay, 2));
        }
    }
    public void damage()
    {
        if (i > 1)
        {
            lives[3 - i].GetComponent<Image>().sprite = heartDisabled;
            i--;
        }
        else
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score",0) + int.Parse(score.text));
            SceneManager.LoadScene(0);
        }
    }
}
