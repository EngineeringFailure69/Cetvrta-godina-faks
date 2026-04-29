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
public class ListenerNoveStanice implements MessageListener
{
    RadnaStanica rs;
    public ListenerNoveStanice(RadnaStanica stanica)
    {
        this.rs = stanica;
    }
    @Override
    public void onMessage(Message message) 
    {
        try
        {
            int idNovog = message.getIntProperty("idKorisnika");
            if(this.rs.ID == idNovog)
                return;
            System.out.println("Dobrodosla nova stanica " + idNovog);
            
            Message msg = this.rs.sessionQ.createMessage(); // UZVRACA ODGOVOROM STANICI
            msg.setIntProperty("idKorisnika",this.rs.ID);
            this.rs.senderID.send(msg);
            
        }catch(Exception e)
        {
            e.printStackTrace();
        }
    }
    
}
