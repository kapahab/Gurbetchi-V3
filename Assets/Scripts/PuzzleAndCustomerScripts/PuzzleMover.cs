using UnityEngine;

public class PuzzleMover : MonoBehaviour
{
    [SerializeField] GameObject puzzlePiece;
    [SerializeField] int columnNum;
    [SerializeField] PuzzleLogic puzzleLogic;
    PuzzleControllerV2 puzzleController;
    PuzzleVerticalCounter puzzleRowCounter;
    float moveRight = -125;
    float moveLeft = 125;
    int moveUp = 115;
    int moveDown = -115;
    float moveScaler;
    int currentColumn = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScaler = 0.6295f;

        puzzleController = this.GetComponentInParent<PuzzleControllerV2>();
        puzzleRowCounter = this.GetComponent<PuzzleVerticalCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PuzzleControllerV2.OnPuzzleUp += MoveUp;
        PuzzleControllerV2.OnPuzzleDown += MoveDown;
        PuzzleControllerV2.OnPuzzleLeft += MoveLeft;
        PuzzleControllerV2.OnPuzzleRight += MoveRight;
    }


    void OnDisable()
    {
        PuzzleControllerV2.OnPuzzleUp -= MoveUp;
        PuzzleControllerV2.OnPuzzleDown -= MoveDown;
        PuzzleControllerV2.OnPuzzleLeft -= MoveLeft;
        PuzzleControllerV2.OnPuzzleRight -= MoveRight;
    }


    public void MoveDown()
    {
        if (puzzleController.currentColumn == puzzleRowCounter.columnNumber)
        {
            this.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(0, moveDown);


        }

    }

    public void MoveUp()
    {
        
        if (puzzleController.currentColumn == puzzleRowCounter.columnNumber)
        {
            this.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(0, moveUp);
        }

    }

    public void MoveRight()
    {
        this.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(moveRight, 0);
    }

    public void MoveLeft()
    {
        this.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(moveLeft, 0);
    }
}
