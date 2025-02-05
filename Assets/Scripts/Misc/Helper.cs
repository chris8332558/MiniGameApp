public static class Helper
{
    public static string FormatTime(float timeInSeconds)
    {
        int minutes = (int)timeInSeconds/ 60;
        int seconds = (int)timeInSeconds - 60 * minutes;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public static string FormatScore(float score)
    {
        return string.Format("{000000}", score);
    }
}
