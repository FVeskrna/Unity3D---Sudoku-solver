using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Board : MonoBehaviour
{
    private SudokuSolver SudokuSolver;
    public TMP_Text Text_CantSolveThat;
    public GameObject Cell;
    private int[,] Matrix = new int[9,9];
    private Node[,] Grid = new Node[9,9];

    // Start is called before the first frame update
    void Start()
    {


        for(int y = 0;y<9;y++){
            for(int x =0;x<9;x++){
                Grid[x,y] = new Node();
            }
        }

        GenerateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForChanges();
    }

    void GenerateBoard(){
        for(int y = 0;y<9;y++){
            for(int x =0;x<9;x++){
                GameObject GeneratedCell = Instantiate(Cell,transform);
                GeneratedCell.transform.SetParent(gameObject.transform);
                GeneratedCell.transform.localPosition += new Vector3(x*60,-y*60,0);
                Grid[x,y].Text = GeneratedCell.GetComponent<TMP_InputField>();
            }
        }
    }

    public void CheckForChanges(){
        for(int y = 0;y<9;y++){
            for(int x =0;x<9;x++){
                if(Grid[x,y].Text.text != "")
                    Matrix[x,y] = int.Parse(Grid[x,y].Text.text);
                if(Matrix[x,y] == 0)
                    Grid[x,y].Text.text = "";
            }
        }
    }

    public void Solve(){
        SudokuSolver = new SudokuSolver(Matrix);
        Matrix = SudokuSolver.Solve();

        if(Matrix == null){
            Debug.Log("Can't solve");
            ToggleCantSolveOn();
            Matrix = new int[9,9];
        }
        else
        {
            for(int y = 0;y<9;y++){
                for(int x =0;x<9;x++){
                    Grid[x,y].Text.text = Matrix[x,y].ToString();
                }
            }
        }
    }

    public void Reset(){
        Matrix = new int[9,9];

        for(int y = 0;y<9;y++){
            for(int x =0;x<9;x++){
                Grid[x,y].Text.text = "";
            }
        }
    }

    private void ToggleCantSolveOn(){
        CancelInvoke("ToggleCantSolveOff");
        Text_CantSolveThat.gameObject.SetActive(true);
        Invoke("ToggleCantSolveOff",2f);
    }
    private void ToggleCantSolveOff() => Text_CantSolveThat.gameObject.SetActive(false);
}

public class Node
{
    public TMP_InputField Text;

   
    private void Update() {
    }
}
