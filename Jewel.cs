//! Uma classe teste.
/*! Uma descrição mais elaborada.
* \author Nome do Autor.
* \since 10/10/10
* \version 1.0
*/

 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe que armazenará as informações da joia
/// </summary>
public abstract class Jewel : ItemMap{
    public int Points {get; private set;}

    //! Construtor
    /*! Construtor da classe Jewel*/
    public Jewel(string Symbol, int Points) : base(Symbol){
        this.Points = Points;
    }
}