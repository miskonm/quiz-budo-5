using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizService : MonoBehaviour
{
    #region Variables

    public QuestionsContainerConfig ContainerConfig;
    public float DelayBetweenAnswers = 2f;
    public GameScreen GameScreen;
    public int MaxHp = 3;

    private int _currentHp;
    private QuestionConfig _currentQuestion;
    private List<QuestionConfig> _questions;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        Statistics.Reset();
        _currentHp = MaxHp;
        _questions = ContainerConfig.Questions.ToList();

        GameScreen.OnButtonClicked += OnButtonClicked;
        GameScreen.OnHintClicked += OnHintClicked;

        SetCurrentQuestion();
        UpdateQuestionUi();
        UpdateHpUi();
    }

    private void OnDestroy()
    {
        GameScreen.OnButtonClicked -= OnButtonClicked;
        GameScreen.OnHintClicked -= OnHintClicked;
    }

    #endregion

    #region Public methods

    public void UpdateHpUi()
    {
        GameScreen.SetHp(_currentHp);
    }

    #endregion

    #region Private methods

    private void EndGame()
    {
        SceneManager.LoadScene(SceneName.End);
    }

    private QuestionConfig GetCurrentQuestion()
    {
        return _currentQuestion;
    }

    private bool HasNextQuestion()
    {
        return _questions.Count > 0;
    }

    private void OnButtonClicked(int number)
    {
        QuestionConfig currentQuestion = GetCurrentQuestion();
        bool isRight = currentQuestion.RightAnswerNumber == number;
        if (isRight)
        {
            Statistics.RightAnswers++;
        }
        else
        {
            Statistics.WrongAnswers++;
            _currentHp--;
            UpdateHpUi();
        }

        GameScreen.SetButtonState(number, isRight);
        GameScreen.SetInteractableAllButtons(false);

        Invoke(nameof(UpdateToNextQuestion), DelayBetweenAnswers);
    }

    private void OnHintClicked()
    {
        GameScreen.SetActiveHintButton(false);

        QuestionConfig currentQuestion = GetCurrentQuestion();
        List<AnswerButton> notRightButtons = new();

        foreach (AnswerButton answerButton in GameScreen.AnswerButtons)
        {
            if (currentQuestion.RightAnswerNumber != answerButton.Number)
            {
                notRightButtons.Add(answerButton);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, notRightButtons.Count);
            notRightButtons[randomIndex].SetActive(false);
            notRightButtons.RemoveAt(randomIndex);
        }
    }

    private void SetCurrentQuestion()
    {
        int randomIndex = Random.Range(0, _questions.Count);
        _currentQuestion = _questions[randomIndex];
        _questions.RemoveAt(randomIndex);
    }

    private void UpdateQuestionUi()
    {
        GameScreen.UpdateUi(GetCurrentQuestion());
    }

    private void UpdateToNextQuestion()
    {
        if (_currentHp <= 0)
        {
            EndGame();
            return;
        }

        if (HasNextQuestion())
        {
            SetCurrentQuestion();
            UpdateQuestionUi();
        }
        else
        {
            EndGame();
        }
    }

    #endregion
}