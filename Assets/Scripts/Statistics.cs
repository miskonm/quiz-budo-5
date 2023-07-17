public static class Statistics
{
    #region Variables

    public static int RightAnswers;
    public static int WrongAnswers;

    #endregion

    #region Public methods

    public static void Reset()
    {
        RightAnswers = 0;
        WrongAnswers = 0;
    }

    #endregion
}