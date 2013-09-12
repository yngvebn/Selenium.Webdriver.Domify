using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Webdriver.Domify.Elements
{
    public class TableRowCollection: IEnumerable<TR>
    {
        public TableRowCollection(IEnumerable<TR> tableRows)
        {
            int index = 0;
            _tableRows = tableRows.ToList();
            foreach (var row in _tableRows)
            {
                row.Index = index;
                index++;
            }
                
        }

        private readonly IList<TR> _tableRows;
        public TR this[int index]
        {
            get { return _tableRows[index]; }
        }

        public int Count
        {
            get { return _tableRows.Count; }
        }

        public IEnumerator<TR> GetEnumerator()
        {
            return _tableRows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}