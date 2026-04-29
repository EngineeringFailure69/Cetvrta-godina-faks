/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package zadataklab;

import javax.jms.Message;
import javax.jms.MessageListener;

/**
 *
 * @author Jelena
 */
public class ListenerOdgovoraID implements MessageListener
{
    RadnaStanica rs;
    
    public ListenerOdgovoraID(RadnaStanica s)
    {
        this.rs = s;
    }
    @Override
    public void onMessage(Message message) 
    {
        try
        {
            int idDrugog = message.getIntProperty("idKorisnika");
            System.out.println("Primio sam dobrodoslicu od " + idDrugog);
            
        }catch(Exception e)
        {
            e.printStackTrace();
        }
    }
    
}
