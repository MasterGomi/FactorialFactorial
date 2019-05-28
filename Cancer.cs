using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mistake
{
    class Cancer
    {
        public List<List<List<List<List<int>>>>> Mistakes = new List<List<List<List<List<int>>>>>();
        private int level2list = 0;
        private int level3list = 0;
        private int level4list = 0;
        private int level5list = 0;
        private int fullLists = 0;
        public Cancer()
        {
            Mistakes.Add(new List<List<List<List<int>>>>());
            Mistakes[0].Add(new List<List<List<int>>>());
            Mistakes[0][0].Add(new List<List<int>>());
            Mistakes[0][0][0].Add(new List<int>());
        }
        public void FuckComputer(int current)
        {
            for (int i = 0; i < current; i++)
            {
                
                if (current != 1)
                {
                    FuckComputer(current - 1);
                }
                else
                {
                    try
                    {
                        Mistakes[level5list][level4list][level3list][level2list].Add(1);
                    }
                    catch(OutOfMemoryException)
                    {
                        try
                        {
                            Mistakes[level5list][level4list][level3list].Add(new List<int>());
                            fullLists++;
                            Console.WriteLine("Running total: {0}\nFilled lists: {1}", Mistakes[level5list][level4list][level3list][level2list].Count * fullLists, fullLists);
                            level2list++;
                            Mistakes[level5list][level4list][level3list][level2list].Add(1);
                        }
                        catch (OutOfMemoryException)
                        {
                            try
                            {
                                Mistakes[level5list][level4list].Add(new List<List<int>>());
                                level3list++;
                                level2list = 0;
                                Mistakes[level5list][level4list][level3list].Add(new List<int>());
                                Mistakes[level5list][level4list][level3list][level2list].Add(1);
                            }
                            catch (OutOfMemoryException)
                            {
                                try
                                {
                                    Mistakes[level5list].Add(new List<List<List<int>>>());
                                    level4list++;
                                    level3list = 0;
                                    level2list = 0;
                                    Mistakes[level5list][level4list].Add(new List<List<int>>());
                                    Mistakes[level5list][level4list][level3list].Add(new List<int>());
                                    Mistakes[level5list][level4list][level3list][level2list].Add(1);
                                }
                                catch (OutOfMemoryException)
                                {
                                    level5list++;
                                    level4list = 0;
                                    level3list = 0;
                                    level2list = 0;
                                    Mistakes.Add(new List<List<List<List<int>>>>());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
