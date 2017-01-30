//AC
//Here we have the Grasshopper class. The grasshopper has a row of leafs and a initial leaf position. Every time he moves, 
// he first eats the leaf he is currently at, and then hops two spaces to an specific direction.
using System;
using System.Linq;
using System.Collections.Generic;

public class Grasshopper
{

    private List<int> leafList;
    private int leaf;
    private int position;
    private int nextLeaf;

    /// <summary>
    /// Initialization of view field with n leaves and grasshopper on leaf 'position'.
    /// </summary>
    /// <param name="n">Number of leaves in row.</param>
    /// <param name="position">Position.</param>
    public Grasshopper(int n, int position)
    {
        this.leafList = Enumerable.Range(1, n).ToList();
        this.leaf = this.leafList[position];
        this.position = this.leafList.FindIndex(l => l.Equals(position));
    }
    /// <summary>
    /// Grasshopper has eaten the current leaf and hopped left.
    /// </summary>
    public void EatAndHopLeft()
    {
        this.leaf = this.leafList[this.position];
        this.nextLeaf = this.leafList[this.position - 2];
        this.leafList.RemoveAt(this.position);

        this.position = this.leafList.FindIndex(l => l.Equals(this.nextLeaf));
    }
    /// <summary>
    /// Grasshopper has eaten the current leaf and hopped right.
    /// </summary>
    public void EatAndHopRight()
    {
        this.leaf = this.leafList[this.position];
        this.nextLeaf = this.leafList[this.position + 2];
        this.leafList.RemoveAt(this.position);

        this.position = this.leafList.FindIndex(l => l.Equals(this.nextLeaf));
    }
    /// <returns>Leaf number that grasshopper is feeding on right now.</returns>
    public int WhereAmI()
    {
        return this.leaf;
    }
    public static void Main(string[] args)
    {
        Grasshopper g = new Grasshopper(10, 2);
        Console.WriteLine(g.WhereAmI());
        g.EatAndHopRight();
        Console.WriteLine(g.WhereAmI());
        g.EatAndHopLeft();
        Console.WriteLine(g.WhereAmI());
        g.EatAndHopRight();
        Console.WriteLine(g.WhereAmI());
        g.EatAndHopRight();
        Console.WriteLine(g.WhereAmI());
        g.EatAndHopRight();
        Console.WriteLine(g.WhereAmI());
        Console.ReadLine();
    }
}
