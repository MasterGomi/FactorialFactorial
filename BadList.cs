using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mistake
{
    public struct NodeValue
    {
        private Dictionary<int, List<int>> _value;

        public NodeValue(int value)
        {
            _value = new Dictionary<int, List<int>>();
            List<int> valueList = new List<int>();
            valueList.Add(value);
            _value.Add(0, valueList);
        }

        public int GetValue()
        {
            List<int> valueList = _value[0];
            return valueList.Sum();
        }
    }

    class BadList
    {
        private BadList _next = null;
        private NodeValue _value;
        private int _pos;
        private int _stackSize;
        public int this [int index]
        {
            get
            {
                if (index == 0) return _value.GetValue();
                else if (_pos == _stackSize - 1) throw new StackOverflowException(); 
                else return _next[index - 1];
            }
        }

        public BadList(int value, int stackSize)
        {
            _value = new NodeValue(value);
            _stackSize = stackSize;
            _pos = 0;
        }

        protected BadList(int value, int stackSize, int pos)
        {
            _value = new NodeValue(value);
            _stackSize = stackSize;
            _pos = pos;
        }

        public void Append(int value, int pos = 0)
        {
            if (_next != null) _next.Append(value, pos + 1);
            else
            {
                if (pos + 1 < _stackSize) _next = new BadList(value, _stackSize, pos + 1);
                else throw new StackOverflowException();
            }
        }
    }

    class BadListWrapper
    {
        private readonly int _stackSize;
        List<List<List<List<List<BadList>>>>> _badLists = new List<List<List<List<List<BadList>>>>>();
        public int this [int x]
        {
            get
            {
                int y = 0;
                int i = 0;
                int k = 0;
                int e = 0;
                int s = 0;
                int remaining = x;
                while (true)
                {
                    try
                    {
                        try
                        {
                            try
                            {
                                try
                                {
                                    try
                                    {
                                        try
                                        {
                                            return _badLists[y][i][k][e][s][remaining];
                                        }
                                        catch (StackOverflowException)
                                        {
                                            remaining -= _stackSize;
                                            s++;
                                            _ = _badLists[y][i][k][e][s];
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        e++;
                                        _ = _badLists[y][i][k][e]; s = 0;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    k++;
                                    _ = _badLists[y][i][k]; e = 0; s = 0;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                i++;
                                _ = _badLists[y][i]; k = 0; e = 0; s = 0;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            y++;
                            _ = _badLists[y]; i = 0; k = 0; e = 0; s = 0;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new Exception("I have been defeated");
                    }
                }
            }
        }

        public void Add(int value)
        {
            int level5list = 0, level4list = 0, level3list = 0, level2list = 0;
            while (true)
            {
                try
                {
                    _badLists[level5list][level4list][level3list][level2list][0].Append(value);
                    return;
                }
                catch (StackOverflowException)
                {
                    try
                    {
                        _badLists[level5list][level4list][level3list].Add(new List<BadList>());
                        level2list++;
                        _badLists[level5list][level4list][level3list][level2list].Add(new BadList(value, _stackSize));
                    }
                    catch (OutOfMemoryException)
                    {
                        try
                        {
                            _badLists[level5list][level4list].Add(new List<List<BadList>>());
                            level3list++;
                            level2list = 0;
                            _badLists[level5list][level4list][level3list].Add(new List<BadList>());
                            _badLists[level5list][level4list][level3list][level2list].Add(new BadList(value, _stackSize));
                        }
                        catch (OutOfMemoryException)
                        {
                            try
                            {
                                _badLists[level5list].Add(new List<List<List<BadList>>>());
                                level4list++;
                                level3list = 0;
                                level2list = 0;
                                _badLists[level5list][level4list].Add(new List<List<BadList>>());
                                _badLists[level5list][level4list][level3list].Add(new List<BadList>());
                                _badLists[level5list][level4list][level3list][level2list].Add(new BadList(value, _stackSize));
                            }
                            catch (OutOfMemoryException)
                            {
                                try
                                {
                                    level5list++;
                                    level4list = 0;
                                    level3list = 0;
                                    level2list = 0;
                                    _badLists.Add(new List<List<List<List<BadList>>>>());
                                    _badLists[level5list].Add(new List<List<List<BadList>>>());
                                    _badLists[level5list][level4list].Add(new List<List<BadList>>());
                                    _badLists[level5list][level4list][level3list].Add(new List<BadList>());
                                    _badLists[level5list][level4list][level3list][level2list].Add(new BadList(value, _stackSize));
                                }
                                catch (OutOfMemoryException)
                                {
                                    throw new Exception("I have been defeated");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
