using System;
using ClientApp;

public class Client
{

    public static void Main()
    {
        try
        {
            Connection conexiune = new Connection();
            int msg = 3;
            while(msg > 0 )
            {
                msg--;
                //functia send se va apela cu un singur parametru, un string , si va returna raspunsul primit de la server
                string trimite = Console.ReadLine();
                string mesajPrimit = conexiune.Send(trimite);
                Console.WriteLine(mesajPrimit); 
            }
        }
        //la aparitia exceptiei e se poate trata cazul in care se inchide serverul, posibil o fereastra care indica conexiune esuata
        //daca mai aveti chef
        catch (Exception e)
        {
            Console.WriteLine("Conexiunea cu serverul a esuat!");         }

    }

}