using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private SquareCreator SquareCreatorInstance;
    private GetDate GetDateInstance;
    private ColorChanger ColorChangerReference;
    private int[,] MatrixFromDocument;
    
    private int i0;
    private int j0;
    private void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, false);
        ColorChangerReference = GetComponent<ColorChanger>();
        SquareCreatorInstance = new SquareCreator();
        GetDateInstance = new GetDate();
        MatrixFromDocument = GetDateInstance.ReturnArray();
        SquareCreatorInstance.Initialization(MatrixFromDocument);
        RandomIAndJ();
        ChangeColor();

        // // for (int i = 0; i < MatrixFromDocument[0,9]; i++)
        // {
        //     Debug.Log(MatrixFromDocument[0, i]);
        // }
    }

    private void Update()
    {
        InputW();
        InputS();
        InputA();
        InputD();
    }

    private void RandomIAndJ()
    {
        i0 = Random.Range(0, SquareCreatorInstance.height);
        j0 = Random.Range(0, SquareCreatorInstance.width);
    }

    #region InputMethod
    
    private void InputW()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            i0--;
            CheckLimitsPosition();
            ChangeColor();
        }
    }
    
    private void InputS()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            i0++;
            CheckLimitsPosition();
            ChangeColor();
        }
    }
    
    private void InputA()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            j0--;
            CheckLimitsPosition();
            ChangeColor();
        }
    }
    
    private void InputD()
    { 
        if (Input.GetKeyDown(KeyCode.D))
        {
            j0++;
            CheckLimitsPosition();
            ChangeColor();
        }
    }
    #endregion

    private void ChangeColor()
    {
        string colorOrder = SquareCreatorInstance.CreateSquare(i0, j0, MatrixFromDocument);
        ColorChangerReference.ChangeColor(colorOrder);
    }

    private void CheckLimitsPosition()
    {
        if (i0 < 0)
        {
            i0 = SquareCreatorInstance.height - 1;
        }
        if (i0 > SquareCreatorInstance.height - 1)
        {
            i0 = 0;
        }
        if (j0 < 0)
        {
            j0 = SquareCreatorInstance.width - 1;
        }
        if (j0 > SquareCreatorInstance.width - 1)
        {
            j0 = 0;
        }
    }

}
