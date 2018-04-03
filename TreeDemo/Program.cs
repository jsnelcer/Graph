namespace TreeDemo
{
    using System;
    using Tree.Model;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> sampleTree = new Tree<int>(
                    0,                           // root - lvl 0                Min z detí => Min(8,-5) => -5
                    new Tree<int>(100,                // node - lvl 1                Max z detí => Max(Min(Max(10,int.MaxValue), 8), -10) => Max(8, -10) => 8
                        new Tree<int>(110,                // node - lvl 2               Min z detí =>  Min(Max(10,int.MaxValue), 8)
                            new Tree<int>(111,                 // node - lvl 3              Max z detí => Max(10,int.MaxValue)
                                new Tree<int>(10),               // leaf - lvl 4                leaf_value = 10
                                new Tree<int>(int.MaxValue)),    // leaf - lvl 4                leaf_value = int.MaxValue
                            new Tree<int>(112,                // node - lvl 3               Max z detí => 8
                                new Tree<int>(8))),            // leaf - lvl 4                  leaf_value = 8
                        new Tree<int>(200,                    // node - lvl 2           Min z detí => -10
                            new Tree<int>(210,                // node - lvl 3               Max z detí => -10
                                new Tree<int>(-10)))),        // leaf - lvl 4                   leaf_value = -10

                    new Tree<int>(300,                // node - lvl 1               Max z deti  => Max(Min(int.MinValue, Max(7,5)), Min(Max(-7,-5))) => Max(int.MinValue, -5) => -5
                        new Tree<int>(310,        // node   - lvl 2                     Min z deti =>   Min(int.MinValue, Max(7,5))
                            new Tree<int>(311,        // node - lvl 3                       Max z deti => Max(7,5)
                                new Tree<int>(7),           // leaf                             leaf_value = 7
                                new Tree<int>(5)),          // leaf                             leaf_value = 5
                            new Tree<int>(312,              // node - lvl 3                 Max z deti => int.MinValue
                                new Tree<int>(int.MinValue))),     // leaf                      leaf_value = int.MinValue
                        new Tree<int>(400,       // node  - lvl 2                       Min z deti =>   Min(Max(-7,-5))
                            new Tree<int>(410,        // node - lvl 3                       Max z deti =>   Max(-7,-5)
                                    new Tree<int>(-7),          // leaf                         leaf_value = -7
                                    new Tree<int>(-5))))       // leaf                          leaf_value = -5
                    );
        }
    }
}
