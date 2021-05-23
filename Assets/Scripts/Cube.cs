using UnityEngine;
using TMPro;
public class Cube : MonoBehaviour
{
    static int staticID = 0;
    [SerializeField] private TMP_Text[] numbersText;

    [HideInInspector] public int cubeID;
    [HideInInspector] public Color cubeColor;
    [HideInInspector] public int cubeNumber;
    [HideInInspector] public Rigidbody cubeRigidbody;
    [HideInInspector] public bool isMainCube;

    private MeshRenderer cubeMeshRenderer;

    #region Awake Method
    private void Awake()
    {
        cubeID = staticID++;
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        cubeRigidbody = GetComponent<Rigidbody>();
    }
    #endregion // Getcomponent Yapisindan Cikilip, public bir sekilde erisim verilecek.

    #region Cube Set Color Method
    public void SetColor(Color color)
    {
        cubeColor = color;
        cubeMeshRenderer.material.color = color;
    }
    #endregion

    #region Cube Set Number Method
    public void SetNumber(int number)
    {
        cubeNumber = number;
        for (int i = 0; i < 6; i++)
        {
            numbersText[i].text = number.ToString();
        }
    }
    #endregion
}
