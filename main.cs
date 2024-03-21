using System;
class Program {
  public static void Main (string[] args) {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"   ____   U  ___ u  _   _     _   _   U _____ u   ____   _____             
U / ___|   \/ _ \/ | \ | |   | \ | |  \| ___ |/U / ___| |_   _|      
\| | u     | | | |<|  \| |> <|  \| |>  |  _|   \| | u     | |        
 | |/__.-,_| |_| |U| |\  |u U| |\  |u  | |___   | |/__   /| |\       
  \____|\_)-\___/  |_| \_|   |_| \_|   |_____|   \____| u |_|U      
 _// \\      \\    ||   \\,-.||   \\,-.<<   >>  _// \\  _// \\_     
(__)(__)    (__)   (_ )  (_/ (_ )  (_/(__) (__)(__)(__)(__) (__)  ");
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(@"                         _____   U  ___ u   _   _    ____     
                        |  ___|   \/ _ \/U | |u| |U |  _ \ u  
                       U| |_  u   | | | | \| |\| | \| |_) |/  
                       \|  _|/.-,_| |_| |  | |_| |  |  _ <    
                        |_|    \_)-\___/  <<\___/   |_| \_\   
                        )(\\,-      \\   (__) )(    //   \\_  
                        (__)(_/     (__)      (__)  (__)  (__) ");
    Console.WriteLine("\n");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine ("Player1 please choose your token color. \nType 'r' for red. \nType 'y' for yellow.");
    char p1c = 'n';
    char p2c = 'n';
    while (p1c == 'n' ){
      char choice = Console.ReadKey().KeyChar;
      if (choice.Equals('y')){
        p1c = choice;
        p2c = 'r';
      }
      else if (choice.Equals('r')){
        p1c = choice;
        p2c = 'y';
      }
      else{
        Console.WriteLine("That is not an available color. Please choose 'r' or 'y'.");
      }
    }
    Connect4 game = new Connect4();
    char winner = 'n';
    char currentPlayer = p1c;
    while(winner.Equals('n')){
      Console.Clear();
      if(p1c == 'r'){
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("\nPlayer1 --> Red");
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Player2 --> Yellow");
    }
    else{
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\nPlayer1 --> Yellow");
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("Player2 --> Red");
    }
      game.matrixPrinter();
      Console.ForegroundColor = ConsoleColor.White;
      if(currentPlayer.Equals(p1c)){
        Console.WriteLine("\nPlayer1: Enter a column number to place your token.");
      }
      else{
        Console.WriteLine("\nPlayer2: Enter a column number to place your token.");
      }
      string temp = Console.ReadLine();
      int place;
      while(!int.TryParse(temp, out place) || game.placeToken(place, currentPlayer) == false){
           Console.WriteLine("\nSorry that is an invalid number. Please try again.");
          temp = Console.ReadLine();
      }
      place = Convert.ToInt32(temp);
      if(game.checkHorizontal(currentPlayer) || game.checkVertical(currentPlayer)||game.checkDiagnol(currentPlayer)){
        Console.Clear();
        game.matrixPrinter();
        winner = currentPlayer;
        Console.ForegroundColor = ConsoleColor.White;
        if(currentPlayer.Equals(p1c)){
          Console.WriteLine("\n");
          Console.WriteLine(@"██████╗ ██╗      █████╗ ██╗   ██╗███████╗██████╗      ██████╗ ███╗   ██╗███████╗    ██╗    ██╗██╗███╗   ██╗███████╗██╗
██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝██╔════╝██╔══██╗    ██╔═══██╗████╗  ██║██╔════╝    ██║    ██║██║████╗  ██║██╔════╝██║
██████╔╝██║     ███████║ ╚████╔╝ █████╗  ██████╔╝    ██║   ██║██╔██╗ ██║█████╗      ██║ █╗ ██║██║██╔██╗ ██║███████╗██║
██╔═══╝ ██║     ██╔══██║  ╚██╔╝  ██╔══╝  ██╔══██╗    ██║   ██║██║╚██╗██║██╔══╝      ██║███╗██║██║██║╚██╗██║╚════██║╚═╝
██║     ███████╗██║  ██║   ██║   ███████╗██║  ██║    ╚██████╔╝██║ ╚████║███████╗    ╚███╔███╔╝██║██║ ╚████║███████║██╗
╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝     ╚═════╝ ╚═╝  ╚═══╝╚══════╝     ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚══════╝╚═╝
                                                                                                                    ");
        }
        else{
          Console.WriteLine("\n");
          Console.WriteLine(@"██████╗ ██╗      █████╗ ██╗   ██╗███████╗██████╗     ████████╗██╗    ██╗ ██████╗     ██╗    ██╗██╗███╗   ██╗███████╗██╗
██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝██╔════╝██╔══██╗    ╚══██╔══╝██║    ██║██╔═══██╗    ██║    ██║██║████╗  ██║██╔════╝██║
██████╔╝██║     ███████║ ╚████╔╝ █████╗  ██████╔╝       ██║   ██║ █╗ ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║███████╗██║
██╔═══╝ ██║     ██╔══██║  ╚██╔╝  ██╔══╝  ██╔══██╗       ██║   ██║███╗██║██║   ██║    ██║███╗██║██║██║╚██╗██║╚════██║╚═╝
██║     ███████╗██║  ██║   ██║   ███████╗██║  ██║       ██║   ╚███╔███╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║███████║██╗
╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝       ╚═╝    ╚══╝╚══╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚══════╝╚═╝
                                                                                                                  ");
        }
      }
      if(currentPlayer.Equals(p1c)){
        currentPlayer = p2c;
      }
      else{
        currentPlayer = p1c;
      }
      if(game.isFull() == true){
        Console.Clear();
        game.matrixPrinter();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n");
        Console.WriteLine(@" ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄       ▄▄  ▄▄▄▄▄▄▄▄▄▄▄          
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌     ▐░░▌▐░░░░░░░░░░░▌         
 ▀▀▀▀█░█▀▀▀▀  ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌   ▐░▐░▌▐░█▀▀▀▀▀▀▀▀▀          
     ▐░▌          ▐░▌     ▐░▌               ▐░▌          ▐░▌       ▐░▌▐░▌▐░▌ ▐░▌▐░▌▐░▌                   
     ▐░▌          ▐░▌     ▐░█▄▄▄▄▄▄▄▄▄      ▐░▌ ▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░▌ ▐░▐░▌ ▐░▌▐░█▄▄▄▄▄▄▄▄▄          
     ▐░▌          ▐░▌     ▐░░░░░░░░░░░▌     ▐░▌▐░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌         
     ▐░▌          ▐░▌     ▐░█▀▀▀▀▀▀▀▀▀      ▐░▌ ▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌   ▀   ▐░▌▐░█▀▀▀▀▀▀▀▀▀          
     ▐░▌          ▐░▌     ▐░▌               ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌                   
     ▐░▌      ▄▄▄▄█░█▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄  ▄  ▄  ▄ 
     ▐░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌▐░▌▐░▌
      ▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀  ▀  ▀ 
                                                                                                         ");
        break;
      }
    }
  }
}
