using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Classe para o tipo de exceção - Fora do mapa
/// </summary>
public class OutOfMapException : Exception{}

/// <summary>
/// Classe para o tipo de exceção - Posição Ocupada
/// </summary>
public class OccupiedPositionException : Exception{}

/// <summary>
/// Classe para o tipo de exceção - Sem energia
/// </summary>
public class RanOutOfEnergyException : Exception{}