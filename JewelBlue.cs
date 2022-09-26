using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe que é um tipo de jóia - Blue
/// </summary>
public class JewelBlue : Jewel, Rechargeable{
    //! Construtor
    /*! Construtor da classe JewelBlue*/
    public JewelBlue() : base("JB ", 10){} 
    
    public void Recharge(Robot r){ //! Função Recharge
        r.energy=r.energy+5;
    }
}
