namespace Greed;

class Score
{
    private int score  = 0;

    public void addScore()
    {
        score += 10;
    }

    public int getScore() {
        return this.score;
    }
    
    public void removeScore()
    {
        score -= 10;
    }

}