using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    [SerializeField] GameObject _menu, _skins;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void menu()
    {
        _menu.SetActive(true); 
        _skins.SetActive(false);
    }
    public void skins()
    {
        _menu.SetActive(false);
        _skins.SetActive(true);
    }
}
