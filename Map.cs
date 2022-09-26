using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Classe que irá armazenar as informações do mapa,  e vai implementar os métodos de adição, remoção de joias e obstáculos.
/// </summary>
public class Map{
    private ItemMap[,] matrix;

    public int h {get; private set;}
    public int w {get; private set;}

    //! Construtor
    /*! Construtor da classe Map*/
    public Map(int w=10, int h=10, int level=1){
        this.w = w <= 30 ? w : 30;
        this.h = h <= 30 ? h : 30;
        matrix = new ItemMap[w, h];

        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j < matrix.GetLength(1); j++){
                matrix[i, j] = new Empty();
            }
        }

        if (level == 1) GenerateFixed();
        else GenerateRandom();
        
    }

    public void Insert(ItemMap Item, int x, int y){ //! Função Insert
        matrix[x, y] = Item;
    }

    public void Update(int x_old, int y_old, int x, int y){ //! Função Update
        if (x < 0 || y < 0 || x > this.w-1 || y > this.h-1){
            throw new OutOfMapException();
        }

        if (IsAllowed(x, y)){
            matrix[x, y] = matrix[x_old, y_old];
            matrix[x_old, y_old] = new Empty(); 
        }

        else{
            throw new OccupiedPositionException();
        }
    }

    public List<Jewel> GetJewels(int x, int y){ //! Função GetJewels
        List<Jewel> NearJewels = new List<Jewel>();
        int[,] Coords = GenerateCoord(x, y);

        for (int i = 0; i < Coords.GetLength(0); i++){
            Jewel? jewel = GetJewel(Coords[i, 0], Coords[i, 1]);
            if (jewel is not null) NearJewels.Add(jewel);
        }
        return NearJewels;
    }

    private Jewel? GetJewel(int x, int y){ //! Função GetJewel
        if (matrix[x, y] is Jewel jewel){
            matrix[x, y] = new Empty();
            return jewel;
        }
        return null;
    }

    public Rechargeable? GetRechargeable(int x, int y){ //! Função GetRechargeable
        int[,] Coords = GenerateCoord(x, y);
        for (int i = 0; i < Coords.GetLength(0); i++) 
            if (matrix[Coords[i, 0], Coords[i, 1]] is Rechargeable r) return r;
        return null;
    }

    private int[,] GenerateCoord(int x, int y){ //! GenerateCoord
        int[,] Coords = new int[4, 2] {
            {x, y+1 < w-1 ? y+1 : w-1},
            {x, y-1 > 0 ? y-1 : 0},
            {x+1 < h-1 ? x+1 : h-1, y},
            {x-1 > 0 ? x-1 : 0, y }
        };
        return Coords;
    }

    private bool IsAllowed(int x, int y){ //! Função IsAllowed
        return matrix[x, y] is Empty;
    }

    public void Print() { //! Função Print
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j < matrix.GetLength(1); j++){
                Console.Write(matrix[i, j]);
            }
            Console.Write("\n");
        }
    }

    public bool IsDone(){ //! Função IsDone
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j < matrix.GetLength(1); j++){
                if (matrix[i, j] is Jewel) return false;
            }
        }
        return true;
    }

    private void GenerateFixed(){ //! Função GenerateFixed
        this.Insert(new JewelRed(), 1, 9);
        this.Insert(new JewelRed(), 8, 8);

        this.Insert(new JewelGreen(), 9, 1);
        this.Insert(new JewelGreen(), 7, 6);

        this.Insert(new JewelBlue(), 3, 4);
        this.Insert(new JewelBlue(), 2, 1);

        this.Insert(new Water(), 5, 0);
        this.Insert(new Water(), 5, 1);
        this.Insert(new Water(), 5, 2);
        this.Insert(new Water(), 5, 3);
        this.Insert(new Water(), 5, 4);
        this.Insert(new Water(), 5, 5);
        this.Insert(new Water(), 5, 6);

        this.Insert(new Tree(), 5, 9);
        this.Insert(new Tree(), 3, 9);
        this.Insert(new Tree(), 8, 3);
        this.Insert(new Tree(), 2, 5);
        this.Insert(new Tree(), 1, 4);
    }

    private void GenerateRandom(){ //! Função GenerateRandom
        Random r = new Random(1); 

        for(int x = 0; x < 3; x++){
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            this.Insert(new JewelBlue(), xRandom, yRandom);
        }

        for(int x = 0; x < 3; x++){
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            this.Insert(new JewelGreen(), xRandom, yRandom);
        }

        for(int x = 0; x < 10; x++){
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            this.Insert(new Water(), xRandom, yRandom);
        }

        for(int x = 0; x < 3; x++){
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            this.Insert(new Radioactive(), xRandom, yRandom);
        }
    }
}
