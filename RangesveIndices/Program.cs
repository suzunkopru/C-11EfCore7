using static System.Console;
string[] kisiler =  
    { "Süleyman", "Fatih", "Yasin", "Ayşe", "Ali", "Veli"};
Range range = ..3;
WriteLine(string.Join('-', kisiler[range]));
range = ^5..3;
WriteLine(string.Join('-', kisiler[range]));
ReadLine();