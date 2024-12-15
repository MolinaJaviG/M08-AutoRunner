using UnityEngine;

public class ScenarioGenerator : MonoBehaviour
{
    static public ScenarioGenerator instance;
    [SerializeField] int numPiecesToGenerateOnstart = 4;
    [SerializeField] GameObject[] piecesPrefabs;

    [Header("Debug")]
    [SerializeField] bool debugEndOfPieceReached;

    Transform nextPiecePosition;

    int numPiecesFinished = 0;

    private void OnValidate()
    {
        if (debugEndOfPieceReached)
        {
            debugEndOfPieceReached = false;
            EndOfPieceReached();
        }
    }

    private void Awake()
    {
        instance = this;
        nextPiecePosition = transform;
    }

    void Start()
    {
        for (int i = 0; i < numPiecesToGenerateOnstart; i++)
        {
            AddNewPiece();
        }
    }

    public void EndOfPieceReached()
    {
        numPiecesFinished++;
        if (numPiecesFinished > 1)
        {
            DestroyOldestPiece();
            AddNewPiece();
        }
    }

    void AddNewPiece()
    {
        GameObject pieceToInstantiate = piecesPrefabs[Random.Range(0, piecesPrefabs.Length)];
        GameObject newPiece = Instantiate(pieceToInstantiate, nextPiecePosition.position, nextPiecePosition.rotation, transform);

        nextPiecePosition = newPiece.GetComponentInChildren<NextPiecePosition>().transform;
    }

    void DestroyOldestPiece()
    {
        GameObject oldestPiece = transform.GetChild(0).gameObject;
        Destroy(oldestPiece);
    }
}