using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int width = 8;
    public int height = 8;
    public GameObject piecePrefab;
    public float spacing = 0.1f;

    // 1. Array of possible colors for our pieces
    public Color[] pieceColors;

    // 2. 2D array to hold all instantiated pieces
    private GameObject[,] allPieces;

    void Start()
    {
        allPieces = new GameObject[width, height];
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 piecePosition = new Vector2(x * (1 + spacing), y * (1 + spacing));
                GameObject piece = Instantiate(piecePrefab, piecePosition, Quaternion.identity);

                // 3. Pick a random color and assign it
                int randomColorIndex = Random.Range(0, pieceColors.Length);
                piece.GetComponent<SpriteRenderer>().color = pieceColors[randomColorIndex];

                // 4. Store the piece in our array
                allPieces[x, y] = piece;
            }
        }
    }
}