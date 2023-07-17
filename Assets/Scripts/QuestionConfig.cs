using UnityEngine;

[CreateAssetMenu(fileName = nameof(QuestionConfig), menuName = "Quiz/Question")]
public class QuestionConfig : ScriptableObject
{
    #region Variables

    public string Answer1;
    public string Answer2;
    public string Answer3;
    public string Answer4;
    
    public Sprite Icon;
    
    [TextArea(3, 6)]
    public string Question;

    [Range(1, 4)]
    public int RightAnswerNumber;

    #endregion
}