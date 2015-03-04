using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Webdriver.Domify.Elements
{
    public class TableBodyCollection: IEnumerable<TBody>
    {
        public TableBodyCollection(IEnumerable<TBody> tableBodies )
        {
            _tableBodies = tableBodies.ToList();
        }

        private readonly IList<TBody> _tableBodies;

        public TBody this[int index]
        {
            get { return _tableBodies[index]; }
        }

        public IEnumerator<TBody> GetEnumerator()
        {
            return _tableBodies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get { return _tableBodies.Count; }
        }
    }
}