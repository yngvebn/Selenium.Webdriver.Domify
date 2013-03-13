using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Webdriver.Domify.Elements
{
    public class TableBodyCollection: IEnumerable<TableBody>
    {
        public TableBodyCollection(IEnumerable<TableBody> tableBodies )
        {
            _tableBodies = tableBodies.ToList();
        }

        private readonly IList<TableBody> _tableBodies;
        public TableBody this[int index]
        {
            get { return _tableBodies[index]; }
        }

        public IEnumerator<TableBody> GetEnumerator()
        {
            return _tableBodies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}