/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package zadataklab;

import java.io.BufferedReader;
import java.io.InputStreamReader;

/**
 *
 * @author Jelena
 */
public class Main {
    
    
    static BufferedReader reader;
    
    public static void main(String[] args) 
    {
        try 
        {
             /*System.out.println("Unesite ID");
             int id = Integer.parseInt(reader.readLine());
        */
            RadnaStanica rs = new RadnaStanica();
            rs.init(6);
            rs.start();
            System.out.println("The Server is waiting for communication...");
            reader = new BufferedReader(new InputStreamReader(System.in));
            reader.readLine();
        }
        catch (Exception e) 
        {
            System.out.println("Exception:" + e.getMessage());
        }
    
}
    
}
