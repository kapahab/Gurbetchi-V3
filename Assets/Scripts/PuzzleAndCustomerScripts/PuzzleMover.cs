using UnityEngine;

public class PuzzleMover : MonoBehaviour
{
    [SerializeField] GameObject puzzlePiece;
    [SerializeField] int columnNum;
    [SerializeField] PuzzleLogic puzzleLogic;
    [SerializeField] PuzzleControllerV2 puzzleController;
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

        this.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, moveDown);

    }

    public void MoveUp()
    {

        this.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, moveUp);

    }

    public void MoveRight()
    {
        this.GetComponent<RectTransform>().anchoredPosition += new Vector2(moveRight, 0);
    }

    public void MoveLeft()
    {
        this.GetComponent<RectTransform>().anchoredPosition += new Vector2(moveLeft, 0);
    }
}
