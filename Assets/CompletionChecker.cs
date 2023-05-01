using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CompletionChecker : MonoBehaviour
{
    public string[][] expectedImageTags;
    
    public TextMeshProUGUI Ülesanne;
    public TextMeshProUGUI Screen;
    
	public SlotScript[] slotScript = new SlotScript[10];
	
    private bool[][] slotCorrect;
    
    private const int MAXLEV = 3;
    
	public int symarv;
	public int numRows;
	public int level = 0;
	

    private void Start()
    {
		level = GameManager.level;
        Debug.Log("Current level: " + level);
		
		
        symarv = 2;
        numRows = 2;
        Ülesanne = GameObject.Find("Ülesanne").GetComponent<TextMeshProUGUI>();
		Screen = GameObject.Find("Screen").GetComponent<TextMeshProUGUI>();
        expectedImageTags = new string[numRows][]; 
        expectedImageTags[0] = new string[10];
        expectedImageTags[0][0] = "X1";
        expectedImageTags[0][1] = "X2";
        expectedImageTags[1] = new string[10];
        expectedImageTags[1][0] = "X2";
        expectedImageTags[1][1] = "X1";
        slotCorrect = new bool[2][];
        slotCorrect[0] = new bool[10];
        slotCorrect[1] = new bool[10];
        SetLevelValues(level);
   
	}
   
    
	public void ClearAllSlots()
	{
		foreach (SlotScript slotScript in slotScript)
		{
			slotScript.clearslots();
		}
	}

	public void SetSlotCorrect(int rowIndex, int slotIndex, bool isCorrect)
	{
	
		slotCorrect[rowIndex][slotIndex-1] = isCorrect;

		bool allCorrect = true;
		for (int i = 0; i < 10; i++)
		{
			if (!slotCorrect[rowIndex][i])
			{
				allCorrect = false;
			}
		}
		
		if (allCorrect)
		{
			ClearAllSlots();
			Debug.Log("Both slots are correct - puzzle complete!");
			level++; 
			GameManager.level = level;
			SetLevelValues(level);
		}
    }
    
    
    private void SetLevelValues(int level)
    {
        switch (level)
        {
            case 1:
                Ülesanne.text = "(X1 -> X2) -> 'X1";
                
                symarv = 4;
                numRows = 2;
                slotCorrect = new bool[numRows][];
                slotCorrect[0] = new bool[10];
                slotCorrect[1] = new bool[10];
                expectedImageTags = new string[2][];
                expectedImageTags[0] = new string[10];
                expectedImageTags[0][0] = "X1";
                expectedImageTags[0][1] = "voi";
                expectedImageTags[0][2] = "inv";
                expectedImageTags[0][3] = "X2";
                expectedImageTags[1] = new string[10];
                expectedImageTags[1][0] = "inv";
                expectedImageTags[1][1] = "X2";
                expectedImageTags[1][2] = "voi";
                expectedImageTags[1][3] = "X1";
                break;
                
                
                
         case 2:
				Ülesanne.text = "(X1 <-> X2) V 'X1";
                symarv = 3;
                numRows = 2;
                slotCorrect = new bool[numRows][];
                slotCorrect[0] = new bool[10];
                slotCorrect[1] = new bool[10];
                expectedImageTags = new string[numRows][];
                expectedImageTags[0] = new string[10];
                expectedImageTags[0][0] = "X1";
                expectedImageTags[0][1] = "voi";
                expectedImageTags[0][2] = "X2";
                expectedImageTags[1] = new string[10];
                expectedImageTags[1][0] = "X2";
                expectedImageTags[1][1] = "voi";
                expectedImageTags[1][2] = "X1";
                break;   
                
                
                
            case 3:
				Screen.text = "Lahenda";
                Ülesanne.text = "X1'X4 xor 'X1'X4 xor X1 xor 'X1";
                numRows = 1;
                symarv = 1;
                slotCorrect = new bool[numRows][];
                slotCorrect[0] = new bool[10];
                expectedImageTags = new string[numRows][];
                expectedImageTags[0] = new string[10];
                expectedImageTags[0][0] = "X4";
                break;
                
                
                
         case 4:
				Ülesanne.text = "'X1X2X3 xor 'X2X3";
                symarv = 5;
                numRows = 2;
                slotCorrect = new bool[numRows][];
                slotCorrect[0] = new bool[10];
                slotCorrect[1] = new bool[10];
                expectedImageTags = new string[numRows][];
                expectedImageTags[0] = new string[10];
                expectedImageTags[0][0] = "X1";
                expectedImageTags[0][1] = "X2";
                expectedImageTags[0][2] = "X3";
                expectedImageTags[0][3] = "xor";
                expectedImageTags[0][4] = "X3";
                expectedImageTags[1] = new string[10];
                expectedImageTags[1][0] = "X3";
                expectedImageTags[1][1] = "xor";
                expectedImageTags[1][1] = "X1";
                expectedImageTags[1][1] = "X2";
                expectedImageTags[1][1] = "X3";
                break;
                
          case 5:
				Ülesanne.text = "'X1'X2X3X4 xor X2'X3'X4 xor X1X3X4 xor X1'X3";
                symarv = 10;
                numRows = 6;
                slotCorrect = new bool[numRows][];
                
                for(int i = 0; i < numRows ;i++)
                {
					slotCorrect[i] = new bool[10];
				}
                expectedImageTags = new string[numRows][];
                expectedImageTags[0] = new string[10];
                expectedImageTags[0][0] = "X1";
                expectedImageTags[0][1] = "X2";
                expectedImageTags[0][2] = "X3";
                expectedImageTags[0][3] = "X4";
                expectedImageTags[0][4] = "xor";
                expectedImageTags[0][5] = "X3";
                expectedImageTags[0][6] = "X4";
                expectedImageTags[0][7] = "xor";
                expectedImageTags[0][8] = "X2";
                expectedImageTags[0][9] = "X4";
                expectedImageTags[1] = new string[10];
                expectedImageTags[1][0] = "X3";
                expectedImageTags[1][1] = "X4";
                expectedImageTags[1][2] = "xor";
                expectedImageTags[1][3] = "X1";
                expectedImageTags[1][4] = "X2";
                expectedImageTags[1][5] = "X3";
                expectedImageTags[1][6] = "X4";
                expectedImageTags[1][7] = "xor";
                expectedImageTags[1][8] = "X2";
                expectedImageTags[1][9] = "X4";
                expectedImageTags[2] = new string[10];
                expectedImageTags[2][0] = "X1";
                expectedImageTags[2][1] = "X2";
                expectedImageTags[2][2] = "X3";
                expectedImageTags[2][3] = "X4";
                expectedImageTags[2][4] = "xor";
                expectedImageTags[2][5] = "X2";
                expectedImageTags[2][6] = "X4";
                expectedImageTags[2][7] = "xor";
                expectedImageTags[2][8] = "X3";
                expectedImageTags[2][9] = "X4";
                expectedImageTags[3] = new string[10];
                expectedImageTags[3][0] = "X2";
                expectedImageTags[3][1] = "X4";
                expectedImageTags[3][2] = "xor";
                expectedImageTags[3][3] = "X3";
                expectedImageTags[3][4] = "X4";
                expectedImageTags[3][5] = "xor";
                expectedImageTags[3][6] = "X1";
                expectedImageTags[3][7] = "X2";
                expectedImageTags[3][8] = "X3";
                expectedImageTags[3][9] = "X4";
                expectedImageTags[4] = new string[10];
                expectedImageTags[4][0] = "X2";
                expectedImageTags[4][1] = "X4";
                expectedImageTags[4][2] = "xor";
                expectedImageTags[4][3] = "X1";
                expectedImageTags[4][4] = "X2";
                expectedImageTags[4][5] = "X3";
                expectedImageTags[4][6] = "X4";
                expectedImageTags[4][7] = "xor";
                expectedImageTags[4][8] = "X3";
                expectedImageTags[4][9] = "X4";
                expectedImageTags[5] = new string[10];
                expectedImageTags[5][0] = "X3";
                expectedImageTags[5][1] = "X4";
                expectedImageTags[5][2] = "xor";
                expectedImageTags[5][3] = "X2";
                expectedImageTags[5][4] = "X4";
                expectedImageTags[5][5] = "xor";
                expectedImageTags[5][6] = "X1";
                expectedImageTags[5][7] = "X2";
                expectedImageTags[5][8] = "X3";
                expectedImageTags[5][9] = "X4";
                break;
                
          case 6:
			level = 0;; 
			GameManager.level = level;
			SceneManager.LoadScene("tubli");
                break;
                
             
                
            default:
            GameManager.level = 0;
                break; 
		}
	}
   
  
}

