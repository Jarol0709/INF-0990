using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe que é um tipo de obstáculo
/// </summary>
public class Radioactive : Obstacle, Rechargeable{
    //! Construtor
    /*! Construtor da classe Radioactive*/
    public Radioactive() : base("!! "){}
    
    public void Recharge(Robot r){ //! Função Recharge
        r.energy=r.energy-30;
    }
}