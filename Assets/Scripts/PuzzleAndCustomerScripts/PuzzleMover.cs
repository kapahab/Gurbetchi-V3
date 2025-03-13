using DG.Tweening;
using UnityEngine;

public class PuzzleMover : MonoBehaviour
{
    [SerializeField] GameObject puzzlePiece;
    [SerializeField] int columnNum;
    [SerializeField] PuzzleLogic puzzleLogic;
    PuzzleControllerV2 puzzleController;
    PuzzleVerticalCounter puzzleRowCounter;
    RectTransform puzzleRectTransform;
    float moveRight = -125;
    float moveLeft = 125;
    int moveUp = 115;
    int moveDown = -115;
    float moveScaler;
    int currentColumn = 0;
    public float moveTime = 0.1f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveScaler = 0.6295f;

        puzzleController = this.GetComponentInParent<PuzzleControllerV2>();
        puzzleRowCounter = this.GetComponent<PuzzleVerticalCounter>();
        puzzleRectTransform = this.GetComponentInChildren<RectTransform>();
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
            //this.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(0, moveDown);
            puzzleRectTransform.DOAnchorPosY(puzzleRectTransform.anchoredPosition.y + moveDown, 0.1f, false);

        }

    }

    public void MoveUp()
    {
        
        if (puzzleController.currentColumn == puzzleRowCounter.columnNumber)
        {
            //this.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(0, moveUp);
            puzzleRectTransform.DOAnchorPosY(puzzleRectTransform.anchoredPosition.y + moveUp, 0.1f, false);
        }

    }

    public void MoveRight()
    {
        //this.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(moveRight, 0);
        puzzleRectTransform.DOAnchorPosX(puzzleRectTransform.anchoredPosition.x + moveRight, 0.1f, false);

    }

    public void MoveLeft()
    {
        //this.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(moveLeft, 0);
        puzzleRectTransform.DOAnchorPosX( (puzzleRectTransform.anchoredPosition.x + moveLeft), 0.1f, false);

    }
}
