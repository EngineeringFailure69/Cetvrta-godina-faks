/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package zadataklab;

import java.io.Serializable;

/**
 *
 * @author Jelena
 */
public class Posao implements Serializable
{
    String tip;
    
    public Posao(String t)
    {
        this.tip = t;
    }
}
