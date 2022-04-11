#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNameChange()
    {
        bool canStart = (playerNameInput.text.Length > 0);
        startButton.enabled = canStart;
        PersistenceManager.GetInstance().CurrentPlayerName = playerNameInput.text;


    }

    public void StartGame()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
