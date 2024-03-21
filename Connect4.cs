using System;

public class Connect4{
  int currentCol;
  int currentRow;
  char [,] c4Board;
  public Connect4(){
    c4Board = new char[6,7];
    for (int i = 0; i < c4Board.GetLength(0); i++){
      for (int x = 0; x < c4Board.GetLength(1); x++){
        c4Board[i,x] = 'n';
      }
    }
  }
  public void matrixPrinter(){
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("  0    1    2    3    4    5    6");
    for(int r = 0; r < c4Board.GetLength(0); r++){
      Console.Write("\n");
      for(int i = 0; i < c4Board.GetLength(1); i++){
        Console.Write("|---|");
      }
      Console.Write("\n");
      for(int c = 0; c < c4Board.GetLength(1); c++){
        if(c4Board.GetValue(r, c).Equals('r')){
          Console.Write("| ");    
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.Write("O");
          Console.ForegroundColor = ConsoleColor.Blue;
          Console.Write(" |");
        }
        else if(c4Board.GetValue(r, c).Equals('y')){
          Console.Write("| ");    
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write("O");
          Console.ForegroundColor = ConsoleColor.Blue;
          Console.Write(" |");
        }
        else{
          Console.ForegroundColor = ConsoleColor.Blue;
          Console.Write("|   |");    
        }
      }
    }
    Console.Write("\n");
    for(int i = 0; i < c4Board.GetLength(1); i++){
      Console.Write("|---|");
    }
  }
  public int getRow(){
    return currentRow;
  }
  public int getCol(){
    return currentCol;
  }
  public Boolean checkDiagnol(char player){
    int countDown = 1;
    int countUp = 1;
    for (int i = 0; i < c4Board.GetLength(0); i++){
      for (int x = 0; x < c4Board.GetLength(1); x++){
        if (Math.Abs(currentRow - i) == Math.Abs(currentCol - x) && ((currentRow - i > 0 && currentCol - x > 0)||(currentRow - i < 0 && currentCol - x < 0)) && c4Board[i,x].Equals(player)){
          countDown++;
        }
        else if (Math.Abs(currentRow - i) == Math.Abs(currentCol - x) &&((currentRow - i > 0 && currentCol - x > 0)||(currentRow - i < 0 && currentCol - x < 0)) && !(c4Board[i,x].Equals(player))){
          countDown = 1;
        }
        if (Math.Abs(currentRow - i) == Math.Abs(currentCol - x) &&((currentRow - i < 0 && currentCol - x > 0)||(currentRow - i > 0 && currentCol - x < 0)) && c4Board[i,x].Equals(player)){
          countUp++;
        }
        else if (Math.Abs(currentRow - i) == Math.Abs(currentCol - x) && ((currentRow - i < 0 && currentCol - x > 0)||(currentRow - i > 0 && currentCol - x < 0)) && !(c4Board[i,x].Equals(player))){
          countUp = 1;
        }
        if (countUp == 4||countDown == 4){
          return true;
        }
      }
    }
    return false;
  }
  public Boolean checkHorizontal(char player){
    int counter = 0;
    char prev = 'n';
    for(int c = 0; c < c4Board.GetLength(1); c++){
      if(c4Board.GetValue(currentRow, c).Equals(player)){
        if(prev.Equals(player) || counter == 0){
          counter++;
          prev = player;
          if(counter == 4){
            return true;
          }
        }
      }
      else{
        prev = 'n';
        counter = 0;
      }
    }
    return false;
  }
  public Boolean checkVertical(char player){
    int counter = 0;
    char prev = 'n';
    for(int r = 0; r < c4Board.GetLength(0); r++){
      if(c4Board.GetValue(r, currentCol).Equals(player)){
        if(prev.Equals(player) || counter == 0){
          counter++;
          prev = player;
          if(counter == 4){
            return true;
          }
        }
      }
      else{
        prev = 'n';
        counter = 0;
      }
    }
    return false;
  }
  public bool placeToken(int col, char player){
    if (col>6||!(c4Board[0,col].Equals('n'))){
      return false;
      }
    currentCol = col;
    for (int i = 0; i < c4Board.GetLength(0)-1; i++){
      if (!(c4Board.GetValue(i+1,col).Equals('n'))){
        c4Board[i,col] = player;
        currentRow = i;
         return true;
      }
    }
    c4Board[5,col] = player;
    currentRow = 5;
    return true;
  }

  public bool isFull(){
    int counter = 0;
    for(int c = 0; c < c4Board.GetLength(1); c++){
      if(!(c4Board.GetValue(0, c).Equals('n'))){
        counter++;
      }
    }
    if(counter == c4Board.GetLength(1)){
      return true;
    }
    else{
      return false;
    }
  }
}