using UnityEngine;

[CreateAssetMenu(fileName = nameof(QuestionsContainerConfig), menuName = "Quiz/Questions Container")]
public class QuestionsContainerConfig : ScriptableObject
{
    #region Variables

    public QuestionConfig[] Questions;

    #endregion
}