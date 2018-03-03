using System;
using System.Collections.Generic;

namespace DeuceGear
{
    public static partial class ArrayExtensions
    {
        public static IEnumerable<int[]> Indices(this Array array)
        {
            if (array == null) yield break;
            if (array.Length == 0) yield break;
            var rank = array.Rank;
            var walker = new ArrayTraverse(array);
            do
            {
                var result = new int[rank];
                walker.CurrentPosition.CopyTo(result, 0); // Merge forces a copy, so the there is a reference break;
                yield return result; 
            } while (walker.Step());
        }

        internal class ArrayTraverse
        {
            public int[] CurrentPosition { get; private set; }
            private int[] _lengthPerRank;
            private int _rank;

            public ArrayTraverse(Array array)
            {
                _rank = array.Rank;
                _lengthPerRank = new int[_rank];
                for (var i = 0; i < _rank; ++i)
                    _lengthPerRank[i] = array.GetLength(i) - 1;
                CurrentPosition = new int[_rank];
            }

            public bool Step()
            {
                for (var i = _rank - 1; i >= 0; --i)
                {
                    if (CurrentPosition[i] < _lengthPerRank[i])
                    {
                        CurrentPosition[i]++;
                        for (var j = i + 1; j < _rank; j++)
                        {
                            CurrentPosition[j] = 0;
                        }
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
