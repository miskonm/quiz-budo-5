using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    #region Variables

    public Button MenuButton;
    public TMP_Text ResultLabel;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        MenuButton.onClick.AddListener(OnMenuButtonClicked);
        ResultLabel.text = $"Right: {Statistics.RightAnswers}\nWrong: {Statistics.WrongAnswers}";
    }

    #endregion

    #region Private methods

    private void OnMenuButtonClicked()
    {
        SceneManager.LoadScene(SceneName.Start);
    }

    #endregion
}