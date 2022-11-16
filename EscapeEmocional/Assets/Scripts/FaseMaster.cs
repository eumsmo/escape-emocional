using UnityEngine;

public class FaseMaster : MonoBehaviour {
    private static int _faseId = 0;
    public static int countFases = 4;

    public static int faseId {
        get { return _faseId; }
        set {
            _faseId = value;
            if (_faseId < 0) {
                _faseId = countFases - 1;
            }
            if (_faseId >= countFases) {
                _faseId = 0;
            }
        }
    }
    
    
    public PlayerController playerController;
    public TilesGenerator tilesGenerator;

    void Start() {
        playerController.EscolhePersonagem(faseId);
        ShowCurrentFase();
    }

    void ShowCurrentFase() {
        TilesController fasePrefab = null;

        foreach (Transform child in transform) {
            FaseMember faseMember = child.GetComponent<FaseMember>();
            if (faseMember != null) {
                if (faseMember.faseId == faseId) {
                    fasePrefab = faseMember.fasePrefab;
                    child.gameObject.SetActive(true);
                } else {
                    child.gameObject.SetActive(false);
                }
            }
        }

        if (fasePrefab != null) {
            tilesGenerator.tilesPrefab = fasePrefab;
            tilesGenerator.GenerateStartingTiles();
        }
    }
}
