using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe que é um tipo de obstáculo
/// </summary>
public class Tree : Obstacle, Rechargeable{
    //! Construtor
    /*! Construtor da classe Tree*/
    public Tree() : base("$$ "){}
    
    public void Recharge(Robot r){ //! Função Recharge
        r.energy=r.energy+3;
    }
}