using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SudokuSolver
{
    private int[,] Matrix = new int[9,9];
    private SudokuNode[,] Grid = new SudokuNode[9,9];
    private List<SudokuNode> TempNodesList = new List<SudokuNode>();


    public SudokuSolver(int[,] _Matrix){
        Matrix = _Matrix;
    }

    private void Construct() {
        for(int y = 0;y<9;y++){
            for(int x =0;x<9;x++){
                Grid[x,y] = new SudokuNode();
                Grid[x,y].PossibleNums = new List<int>{1,2,3,4,5,6,7,8,9};

                if(Matrix[x,y] != 0){
                    Grid[x,y].CurrentNum = Matrix[x,y];
                    Grid[x,y].PossibleNums = new List<int>();
                }
                else{
                    TempNodesList.Add(Grid[x,y]);
                }
            }
        }
    }

    public int[,] Solve(){
        Construct();

        int Tries = 0;

        while(TempNodesList.Count > 0){
            if(Tries > 500)
                return null;

            for(int y = 0;y<9;y++){
                for(int x =0;x<9;x++){
                    CalculatePossibleNums(x,y);
                    if(Matrix[x,y] != 0){
                        continue;
                    }
                    else if(Grid[x,y].PossibleNums.Count == 1){
                        Matrix[x,y] = Grid[x,y].PossibleNums[0];
                        Grid[x,y].CurrentNum = Grid[x,y].PossibleNums[0];
                        Grid[x,y].PossibleNums = new List<int>();
                        TempNodesList.Remove(Grid[x,y]);
                    }
                        
                }
            }

            Tries++;
        }

        return Matrix;
        

    }

    private void CalculatePossibleNums(int x, int y){
        
        //ROW
        for(int _x = 0;_x<9;_x++){
            if(Grid[x,y].PossibleNums.Contains(Matrix[_x,y]))
                Grid[x,y].PossibleNums.Remove(Matrix[_x,y]);
        }

        //COLLUM
        for(int _y = 0;_y<9;_y++){
            if(Grid[x,y].PossibleNums.Contains(Matrix[x,_y]))
                Grid[x,y].PossibleNums.Remove(Matrix[x,_y]);
        }

        //BIG CELL
        int BigX = Mathf.FloorToInt(x/3);
        int BigY = Mathf.FloorToInt(y/3);

        for(int _x = BigX*3 ;_x< (BigX+1)*3;_x++){
            for(int _y = BigY*3 ;_y< (BigY+1)*3;_y++){
                if(Grid[x,y].PossibleNums.Contains(Matrix[_x,_y]))
                Grid[x,y].PossibleNums.Remove(Matrix[_x,_y]);
            }
        }


        foreach(int number in Grid[x,y].PossibleNums){
            if(!CanOtherInRowContain(number,x,y) || !CanOtherInCollumContain(number,x,y) || !CanOtherInBigCellContain(number,x,y)){
                Grid[x,y].PossibleNums = new List<int>{number};
            }
        }
    }

    private bool CanOtherInRowContain(int number,int initX,int initY){
        for(int _x = 0;_x<9;_x++){
            if(_x != initX && Grid[_x,initY].PossibleNums.Contains(number)){
                return true;
            }
        }
        return false;
    }
    private bool CanOtherInCollumContain(int number,int initX,int initY){
        for(int _y = 0;_y<9;_y++){
            if(_y != initY && Grid[initX,_y].PossibleNums.Contains(number)){
                return true;
            }
        }
        return false;
    }
    private bool CanOtherInBigCellContain(int number,int initX,int initY){
        int BigX = Mathf.FloorToInt(initX/3);
        int BigY = Mathf.FloorToInt(initY/3);

        for(int _x = BigX*3 ;_x< (BigX+1)*3;_x++){
            for(int _y = BigY*3 ;_y< (BigY+1)*3;_y++){
                if(Grid[_x,_y].PossibleNums.Contains(number))
                    return true;
            }
        }
        return false;
    }
}

public class SudokuNode
{
    public int CurrentNum = 0;
    public List<int> PossibleNums;
}
