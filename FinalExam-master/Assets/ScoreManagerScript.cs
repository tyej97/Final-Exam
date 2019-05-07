using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Unity.IO;

public class ScoreManagerScript : MonoBehaviour
{
    public Text HighScores;
    public static int num_scores = 5;
    public static int maxScoresStored = 100;

    void Update()
    {
        ShowTopPlayerScores();
    }

    public void ShowTopPlayerScores()
    {
        string path = "Assets/scores.txt";
        string line;
        string[] fields;
        string[] playerNames = new string[num_scores];
        int[] playerScores = new int[num_scores];
        int scores_read = 0;

        HighScores.text = "";

        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream && scores_read < num_scores)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            if (fields[0] == GameManagerScript.playerName)
            {
                HighScores.text += fields[0] + " : " + fields[1] + "\n";
                scores_read += 1;
            }
        }
    }

    static public void WriteScore()
    {
        string path = "Assets/scores.txt";
        string line;
        string[] fields;
        string[] playerNames = new string[maxScoresStored];
        int[] playerScores = new int[maxScoresStored];
        int scores_read = 0;
        string[,] HighScores = new string[maxScoresStored, 2];
        string[,] newHighScores = new string[maxScoresStored, 2];

        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream && scores_read < maxScoresStored)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            HighScores[scores_read, 0] = fields[0];
            HighScores[scores_read, 1] = fields[1];
            scores_read += 1;
        }

        reader.Close();

        bool placed = false;
        
        for (int i = 0; i < scores_read + 1; i++)
        {
            if (GameManagerScript.totalScore > int.Parse(HighScores[i, 1]) && placed == false)
            {
                newHighScores[i, 0] = GameManagerScript.playerName;
                newHighScores[i, 1] = GameManagerScript.totalScore.ToString();
                placed = true;
            }
            else if (placed == true)
            {
                newHighScores[i, 0] = HighScores[i - 1, 0];
                newHighScores[i, 1] = HighScores[i - 1, 1];
            }
            else
            {
                newHighScores[i, 0] = HighScores[i, 0];
                newHighScores[i, 1] = HighScores[i, 1];
            }
        }
        
        StreamWriter write = new StreamWriter(path);
        for (int j = 0; j < scores_read; j++)
        {
            write.WriteLine(newHighScores[j, 0] + "," + newHighScores[j, 1]);
        }

        write.Close();
        
    }
}
