using UnityEngine;

public class PuzzleMover : MonoBehaviour
{
    [SerializeField] GameObject puzzlePiece;
    [SerializeField] int columnNum;
    [SerializeField] PuzzleLogic puzzleLogic;
    [SerializeField] PuzzleController puzzleController;
    float moveRight = -1.9f;
    float moveLeft = 1.9f;
    int moveUp = 2;
    int moveDown = -2;
    float moveScaler;
    int currentColumn = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScaler = 0.6295f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        puzzleController.OnPuzzleUp += MoveUp;
        puzzleController.OnPuzzleDown += MoveDown;
        puzzleController.OnPuzzleLeft += MoveLeft;
        puzzleController.OnPuzzleRight += MoveRight;
    }


    void OnDisable()
    {
        puzzleController.OnPuzzleUp -= MoveUp;
        puzzleController.OnPuzzleDown -= MoveDown;
        puzzleController.OnPuzzleLeft -= MoveLeft;
        puzzleController.OnPuzzleRight -= MoveRight;
    }


    public void MoveDown()
    {
        if(puzzleController.currentColumn == columnNum)
        {
            puzzlePiece.transform.localPosition += new Vector3(0, moveDown, 0);
        }
    }

    public void MoveUp()
    {
        if (puzzleController.currentColumn == columnNum)
        {
            puzzlePiece.transform.localPosition += new Vector3(0, moveUp, 0);
        }
    }

    public void MoveRight()
    {
        puzzlePiece.transform.localPosition += new Vector3(moveRight, 0, 0);
        currentColumn++;
    }

    public void MoveLeft()
    {
        puzzlePiece.transform.localPosition += new Vector3(moveLeft, 0, 0);
    }
}
