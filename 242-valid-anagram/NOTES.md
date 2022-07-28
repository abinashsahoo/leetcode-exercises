return **Enumerable**.SequenceEqual(sArray, tArray);
OR,
return sArray.SequenceEqual(tArray);
​
return s.OrderBy(c => c).SequenceEqual(t.OrderBy(c => c));