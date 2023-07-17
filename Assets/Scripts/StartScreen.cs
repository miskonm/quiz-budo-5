using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    #region Variables

    public Button PlayButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        PlayButton.onClick.AddListener(OnPlayButtonClicked);
    }

    #endregion

    #region Private methods

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(SceneName.Game);
    }

    #endregion
}