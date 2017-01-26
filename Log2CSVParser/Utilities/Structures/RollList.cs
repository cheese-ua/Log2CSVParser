using System.Linq;

namespace Log2CSVParser.Utilities.Structures
{
    public class RollList<T>
    {
        private readonly T[] items;
        private int pos = -1;
        private readonly object syncRoot = new object();

        public RollList(T[] items)
        {
            this.items = items;
        }

        public T Next()
        {
            if (items == null || items.Length == 0)
                return default(T);
            lock (syncRoot) {
                if (++pos > items.Length - 1)
                    pos = 0;
                return items[pos];
            }
        }

        public int Count => items?.Length ?? 0;

        public T FirstOrDefault(object obj)
        {
            return items.FirstOrDefault(i => i.GetHashCode().Equals(obj.GetHashCode()));
        }

        public T[] GetItems => items;
    }
}
