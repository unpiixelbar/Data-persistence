using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public static UIMenu Instance;
    public string playername;
    public string highscore;
    public string highscorePlayer;
    public int HighScorePoints;

    [SerializeField] Text highscoreText;
    [SerializeField] Text PlayerInputText;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    public void MainScene()
    {
        //reads input playername
        playername = PlayerInputText.text;

        if (playername == "") return;
        //saves input player name for next start
        Save();

        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    class SaveData
    {
        public string InputPlayerName;
        public string HighscorePlayerName;
        public int Highscore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.InputPlayerName = playername;
        data.HighscorePlayerName = highscorePlayer;
        data.Highscore = HighScorePoints;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.son", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.son";
        if (!File.Exists(path))
        {
            //when File doesn't exists
            return;
        }
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        //playername
        playername = data.InputPlayerName;
        PlayerInputText.text = playername;

        highscorePlayer = data.HighscorePlayerName;

        HighScorePoints = data.Highscore;
        highscoreText.text = $"Best Score: {highscorePlayer}:{HighScorePoints}";
    }
}
