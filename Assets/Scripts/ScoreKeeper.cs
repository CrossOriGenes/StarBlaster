using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int value)
    {
        score = Mathf.Clamp(value, 0, int.MaxValue);
        print(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
