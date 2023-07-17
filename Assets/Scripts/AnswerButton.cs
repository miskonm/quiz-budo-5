using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    #region Variables

    public Button Button;

    public Color DefaultColor = Color.white;
    public Color RightColor = Color.green;
    public Image StateImage;
    public TMP_Text TextLabel;
    public Color WrongColor = Color.red;

    private Action<AnswerButton> _clickCallback;

    #endregion

    #region Properties

    public int Number { get; private set; }

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        Button.onClick.AddListener(OnButtonClicked);
    }

    #endregion

    #region Public methods

    public void OnClick(Action<AnswerButton> clickCallback)
    {
        _clickCallback = clickCallback;
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetIsRight(bool isRight)
    {
        StateImage.color = isRight ? RightColor : WrongColor;
    }

    public void SetNumber(int number)
    {
        Number = number;
    }

    public void SetText(string text)
    {
        TextLabel.text = text;
        SetDefaultState();
    }

    #endregion

    #region Private methods

    private void OnButtonClicked()
    {
        _clickCallback?.Invoke(this);
    }

    private void SetDefaultState()
    {
        StateImage.color = DefaultColor;
    }

    #endregion
}