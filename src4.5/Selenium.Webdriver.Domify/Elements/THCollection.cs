using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Webdriver.Domify.Elements
{
    public class THCollection : IEnumerable<TH>
    {
        private readonly IList<TH> _headerColumns;

        public THCollection(IEnumerable<TH> tableRows)
        {
            _headerColumns = tableRows.ToList();
        }


        public TH this[int index]
        {
            get { return _headerColumns[index]; }
        }

        public int Count
        {
            get { return _headerColumns.Count; }
        }

        public IEnumerator<TH> GetEnumerator()
        {
            return _headerColumns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}