using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;

public class ASCIILevel : MonoBehaviour
{
    private const string File_Name = "LevelNum.txt";
    private const string File_Dir = "/Levels/";
    private string File_Path;
    private GameObject level;
    private GameObject currentPlayer;
    private GameObject currentBox;
    private int currentLevel = 0;
    
    public GameObject player;
    public GameObject wall;
    public GameObject door;
    public GameObject nextLevel;
    public GameObject danger;
    public GameObject box;

    public float xoffset;
    public float yoffset;
    public Vector2 playerStartPos;
    public Vector2 BoxStartPos;

    
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            levelLoad();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        File_Path = Application.dataPath + File_Dir + File_Name;

        levelLoad();
    }

    bool levelLoad()
    {
        Destroy(level);
        level = new GameObject("level");

        string newPath = File_Path.Replace("Num",currentLevel +"");
        string[] filelines = File.ReadAllLines(newPath);

        for (int yPos = 0; yPos < filelines.Length; yPos++)
        {
            string lineText = filelines[yPos];
            char[] lineChar = lineText.ToCharArray();

            for (int xPos = 0; xPos < lineChar.Length; xPos++)
            {
                char c = lineChar[xPos];

                GameObject newObj;

                switch (c)
                {
                    case 'P':
                        playerStartPos = new Vector2(xoffset + xPos, yoffset - yPos);
                        newObj = Instantiate<GameObject>(player);
                        currentPlayer = newObj;
                        break;
                    case 'W':
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case 'D':
                        newObj = Instantiate<GameObject>(door);
                        break;
                    case 'B':
                        BoxStartPos = new Vector2(xoffset + xPos, yoffset - yPos);
                        newObj = Instantiate<GameObject>(box);
                        currentBox = newObj;
                        break;
                    case 'N':
                        newObj = Instantiate<GameObject>(nextLevel);
                        break;
                    case '^':
                        newObj = Instantiate<GameObject>(danger);
                        break;
                    default:
                        newObj = null;
                        break;
                }

                if (newObj!=null)
                {
                    newObj.transform.position = new Vector2(xoffset + xPos, yoffset - yPos);
                    newObj.transform.parent = level.transform;
                }

            }

            
        }
        return false;

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPlayer()
    {
        currentPlayer.transform.position = playerStartPos;
        currentBox.transform.position = BoxStartPos;
    }
}
