/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package zadataklab;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Properties;
import javax.jms.ConnectionFactory;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.Queue;
import javax.jms.QueueConnection;
import javax.jms.QueueConnectionFactory;
import javax.jms.QueueReceiver;
import javax.jms.QueueSender;
import javax.jms.QueueSession;
import javax.jms.Session;
import javax.jms.Topic;
import javax.jms.TopicConnection;
import javax.jms.TopicConnectionFactory;
import javax.jms.TopicPublisher;
import javax.jms.TopicSession;
import javax.jms.TopicSubscriber;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;

/**
 *
 * @author Jelena
 */
public class RadnaStanica implements MessageListener
{
    int ID;
    Posao mojPosao;
    
    Context ictx; // Context
    ConnectionFactory jmsContext;
    
    QueueSession sessionQ;
    QueueConnectionFactory qcf;
    QueueConnection qc;
    
    TopicSession sessionT;
    TopicConnectionFactory tcf;
    TopicConnection tc;
    
    Topic tJaviSeSvima; // TOPIC AKO SE DODA NOVI PROIZVOD SVI SE OBAVESTAVAJU
    
    Topic tZatraziPomoc;
    Queue qOdgovorSaID;
    
    TopicPublisher publisher;
    TopicPublisher publisherZahtevaZaPomoc;
    TopicSubscriber subscriber;
    TopicSubscriber subscriberZahtevaZaPomoc;
    
    QueueSender senderID;
    QueueReceiver recvID;
    public void init(int id) throws NamingException, JMSException, IOException
    {
        this.ID = id;
        ictx = getContext();
        jmsContext = (ConnectionFactory) ictx.lookup("java:comp/DefaultJMSConnectionFactory");
        
        qcf = (QueueConnectionFactory)ictx.lookup("jms/testQueueFactory");
        qc = (QueueConnection)qcf.createConnection();
        sessionQ = qc.createQueueSession(false,Session.AUTO_ACKNOWLEDGE);

        tcf = (TopicConnectionFactory)ictx.lookup("jms/testTopicFactory");
        tc = (TopicConnection)tcf.createConnection();
        sessionT = tc.createTopicSession(false,Session.AUTO_ACKNOWLEDGE); 

        tJaviSeSvima = (Topic)ictx.lookup("jms/testTopic");
       // tJaviSeSvima = (Topic)ictx.lookup("jms/testTopic");
        tZatraziPomoc = (Topic)ictx.lookup("jms/TopicPomoc");
        qOdgovorSaID = (Queue)ictx.lookup("jms/QueueOdogovorID");
        ictx.close();
         
         publisher = sessionT.createPublisher(tJaviSeSvima);
         publisherZahtevaZaPomoc  = sessionT.createPublisher(tZatraziPomoc);
         
         subscriber = (TopicSubscriber)sessionT.createSubscriber(tJaviSeSvima);
         subscriber.setMessageListener(new ListenerNoveStanice(this));
         
        
         
         senderID = (QueueSender)sessionQ.createSender(qOdgovorSaID); //SaljeSvojId
         recvID = sessionQ.createReceiver(qOdgovorSaID);
         recvID.setMessageListener(new ListenerOdgovoraID(this));
         
         qc.start();
         tc.start();
         
         System.out.println("Novi radna stanica");
         System.out.println("Uneti tip posla");
         
         BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
         String tip = reader.readLine();
         
         mojPosao = new Posao(tip);
         System.out.println("Posao spreman");
         
         //KREIRANJE FILTERA----------------------------------------------------------------------------
         String filter = tip;
         subscriberZahtevaZaPomoc = (TopicSubscriber)sessionT.createSubscriber(tZatraziPomoc,filter,true);
         subscriberZahtevaZaPomoc.setMessageListener(this);
        
    }
    
    public void start() throws IOException
    {
        try
        {
            // OBAVESTAVAMO OSTALE DA SMO PRISUTNI
            System.out.println("Zdravo svima");
            Message msg = sessionT.createMessage();
            msg.setIntProperty("idKorisnika", this.ID);
            publisher.send(msg);
                     
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
        
            boolean exiting = false;
            BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
            while(!exiting)
            {
                System.out.println("1) Zatrazi Pomoc");
                System.out.println("2) Exit");
                String opcija = reader.readLine();
                System.out.println("opcija: " + opcija);
                switch(opcija)
                {
                    case "1":
                        this.zatraziPomoc();
                        break;
                    case "2":
                        exiting = true;
                        break;
                }
                
            }
    }
    public void zatraziPomoc()
    {
        try
        {
            Message msg = sessionT.createMessage();
            msg.setStringProperty("tip", mojPosao.tip);
            publisherZahtevaZaPomoc.send(msg);
        }
        catch(Exception e)
        {
            System.out.println(e);
        }
    }
      private static Context getContext() throws NamingException 
    {
            Properties props = new Properties();
            props.setProperty("java.naming.factory.initial", "com.sun.enterprise.naming.SerialInitContextFactory");
            //props.setProperty("java.naming.factory.initial", "com.stc.jms.jndispi.InitialContextFactory");//
            props.setProperty("java.naming.factory.url.pkgs", "com.sun.enterprise.naming");
            props.setProperty("java.naming.provider.url", "iiop://localhost:3700");
            return new InitialContext(props);
    }
    @Override
    public void onMessage(Message message) 
    {
        try
        {
            System.out.println("Primljen zahtev od druge stanice za pomoc u poslu");
            String pomocTip  = message.getStringProperty("tip");
            System.out.println("Primljen tip je " + pomocTip);
            System.out.println("Obavaljam zadatak..........");
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
    }
    
}
