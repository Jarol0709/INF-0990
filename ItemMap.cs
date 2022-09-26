using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe para implementar itens em nosso mapa
/// </summary>
public abstract class ItemMap{
    private string Symbol;

    //! Construtor
    /*! Construtor da classe ItemMap*/
    public ItemMap(string Symbol){
        this.Symbol = Symbol;
    }

    public sealed override string ToString(){ //! Função ToString
        return Symbol;
    }
}