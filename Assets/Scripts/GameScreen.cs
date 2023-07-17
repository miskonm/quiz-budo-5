using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    #region Variables

    public AnswerButton[] AnswerButtons;
    public Button HintButton;
    public TMP_Text HpLabel;
    public Image QuestionImage;
    public TMP_Text QuestionLabel;

    #endregion

    #region Events

    public event Action<int> OnButtonClicked;
    public event Action OnHintClicked;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        HintButton.onClick.AddListener(OnHintButtonClicked);

        for (int i = 0; i < 4; i++)
        {
            AnswerButton button = AnswerButtons[i];
            button.SetNumber(i + 1);
            button.SetActive(true);
            button.OnClick(OnClicked);
        }
    }

    #endregion

    #region Public methods

    public void SetActiveHintButton(bool isActive)
    {
        HintButton.gameObject.SetActive(isActive);
    }

    public void SetButtonState(int buttonNumber, bool isRight)
    {
        AnswerButtons[buttonNumber - 1].SetIsRight(isRight);
    }

    public void SetHp(int hp)
    {
        HpLabel.text = $"Hp: {hp}";
    }

    public void SetInteractableAllButtons(bool isInteractable)
    {
        foreach (AnswerButton answerButton in AnswerButtons)
        {
            answerButton.Button.enabled = isInteractable;
        }

        HintButton.enabled = isInteractable;
    }

    public void UpdateUi(QuestionConfig config)
    {
        QuestionImage.sprite = config.Icon;
        QuestionLabel.text = config.Question;

        foreach (AnswerButton answerButton in AnswerButtons)
        {
            answerButton.SetActive(true);
        }

        AnswerButtons[0].SetText(config.Answer1);
        AnswerButtons[1].SetText(config.Answer2);
        AnswerButtons[2].SetText(config.Answer3);
        AnswerButtons[3].SetText(config.Answer4);

        SetActiveHintButton(true);
        SetInteractableAllButtons(true);
    }

    #endregion

    #region Private methods

    private void OnClicked(AnswerButton button)
    {
        OnButtonClicked?.Invoke(button.Number);
    }

    private void OnHintButtonClicked()
    {
        OnHintClicked?.Invoke();
    }

    #endregion
}