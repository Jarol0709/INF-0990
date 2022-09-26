using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe que irá armazenar informações do robô
/// </summary>
public class Robot : ItemMap{
    private int x, y;
    private List<Jewel> Bag = new List<Jewel>();
    
    public Map map {get; private set;}
    public int energy {get; set;}

    //! Construtor
    /*! Construtor da classe Robot*/
    public Robot(Map map, int x=0, int y=0, int energy=5) : base("ME "){
        this.map = map;
        this.x = x;
        this.y = y;
        this.energy = energy;
        this.map.Insert(this, x, y);
    }

    public void MoveNorth(){ //! Função MoveNorth
        try{
            map.Update(this.x, this.y, this.x-1, this.y);
            this.x--;
            this.energy--;
        }catch (OccupiedPositionException e){
            Console.WriteLine($"Position ({this.x-1},{this.y}) is occupied");
        }
        catch (OutOfMapException e){
            Console.WriteLine($"Position ({this.x-1},{this.y}) is out of map");
        }
        catch (Exception e){
            Console.WriteLine($"Position is prohibit");
        }     
    }

    public void MoveSouth(){ //! Função MoveSouth
        try{
            map.Update(this.x, this.y, this.x+1, this.y);
            this.x++;
            this.energy--;
        }catch (OccupiedPositionException e){
            Console.WriteLine($"Position ({this.x+1},{this.y}) is occupied");
        }
        catch (OutOfMapException e){
            Console.WriteLine($"Position ({this.x+1},{this.y}) is out of map");
        }
        catch (Exception e){
            Console.WriteLine($"Position is prohibit");
        }        
    }

    public void MoveEast(){ //! Função MoveEast
        try{
            map.Update(this.x, this.y, this.x, this.y+1);
            this.y++;
            this.energy--;
        }catch (OccupiedPositionException e){
            Console.WriteLine($"Position ({this.x},{this.y+1}) is occupied");
        }
        catch (OutOfMapException e){
            Console.WriteLine($"Position ({this.x},{this.y+1}) is out of map");
        }
        catch (Exception e){
            Console.WriteLine($"Position is prohibit");
        }     
        
    }

    public void MoveWest(){ //! Função MoveWest
        try{
            map.Update(this.x, this.y, this.x, this.y-1);
            this.y--;
            this.energy--;
        }catch (OccupiedPositionException e){
            Console.WriteLine($"Position ({this.x},{this.y-1}) is occupied");
        }
        catch (OutOfMapException e){
            Console.WriteLine($"Position ({this.x},{this.y-1}) is out of map");
        }
        catch (Exception e){
            Console.WriteLine($"Position is prohibit");
        }     
        
    }

    public void Get(){ //! Função Get
        List<Jewel> NearJewels = map.GetJewels(this.x, this.y);
        Rechargeable? RechargeEnergy = map.GetRechargeable(this.x, this.y);
        RechargeEnergy?.Recharge(this);

        foreach (Jewel j in NearJewels){
            Bag.Add(j); 
        }     
    }

    private (int, int) GetBagInfo(){ //! Função GetBagInfo
        int Points = 0;

        foreach (Jewel j in this.Bag){
            Points += j.Points;
        }    
        return (this.Bag.Count, Points);
    }

    public void Print(){ //! Função Print
        map.Print();
        (int ItensBag, int TotalPoints) = this.GetBagInfo();
        Console.WriteLine($"Itens Bag: {ItensBag} - Total Points: {TotalPoints} - Energy: {this.energy}");
    }

    public bool HasEnergy(){ //! Função HasEnergy
        return this.energy > 0;
    }

}