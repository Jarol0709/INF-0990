using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe que irá armazenar informações do obstáculo
/// </summary>
public abstract class Obstacle : ItemMap{
    //! Construtor
    /*! Construtor da classe Obstacle*/
    public Obstacle(string Symbol) : base(Symbol){}
}