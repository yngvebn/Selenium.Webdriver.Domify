using System.Collections;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class TableTests: PageScenario<HomeSelectLists>
    {
        protected override void When()
        {

        }

        [Then]
        public void TheTableBodyShouldReturnOnlyTwoRows()
        {
            Assert.That(CurrentPage.Table.OwnTableBodies.First().OwnTableRows.Count, Is.EqualTo(2));
        }

        [Then]
        public void WeCanGetATableRowBasedOnCriteria()
        {
            Assert.That(CurrentPage.Table.OwnTableBodies.First().OwnTableRow(By.Id("___s_w_d_757394")), Is.Not.Null);
        }

        [Then]
        public void WeCanGetARowAtSpecificIndex()
        {
            Assert.That(CurrentPage.Table.OwnTableBodies[0].OwnTableRows[0].Id, Is.EqualTo("___s_w_d_757394"));
        }

        [Then]
        public void WeCanGetTableWithMultipleBodies()
        {
            Assert.That(CurrentPage.TableWithBodies.TableBodies.Count, Is.EqualTo(2));
        }



        [Then]
        public void CanGetHeader()
        {
            Assert.That(CurrentPage.TableWithBodies.Head.OwnTableHeaderColumns.Count, Is.EqualTo(1));
        }


        [Then]
        public void ShouldGetNoOwnTableRowsIfRowsAreInBody()
        {
            Assert.That(CurrentPage.TableWithBodies.OwnTableRows.Count, Is.EqualTo(0));
        }

        [Then]
        public void TableRowCollectionIsAList()
        {
            Assert.That(CurrentPage.Table.OwnTableBodies[0].OwnTableRows.ToList(), Is.Not.Null);
            Assert.That((CurrentPage.Table.OwnTableBodies[0].OwnTableRows as IEnumerable).GetEnumerator(), Is.Not.Null);
        }


        [Then]
        public void TheTableShouldReturnTableRowsFromHeaderAndBody()
        {
            Assert.That(CurrentPage.Table.TableRows.Count(),Is.EqualTo(3));
        }


        [Then]
        public void CanGetSpecificTableCellFromTableRow()
        {
            Assert.That(CurrentPage.Table.TableBodies[0].OwnTableRows[0].TableCell(By.ClassName("special")).Text, Is.EqualTo("The special cell"));
            Assert.That(CurrentPage.Table.TableBodies[0].OwnTableRows[0].OwnTableCell(By.ClassName("special")).Text, Is.EqualTo("The special cell"));
        }

        [Then]
        public void CanGetTableCellsFromTableRow()
        {
            Assert.That(CurrentPage.Table.TableBodies[0].OwnTableRows[0].TableCells.Count(), Is.GreaterThan(0));
            Assert.That(CurrentPage.Table.TableBodies[0].OwnTableRows[0].OwnTableCells.Count(), Is.GreaterThan(0));
        }


        [Then]
        public void CanGetTableHeaderByIndex()
        {
            Assert.That(CurrentPage.Table.Head.OwnTableHeaderColumns[0], Is.Not.Null);
            Assert.That(CurrentPage.Table.Head.OwnTableHeaderColumns.Count, Is.GreaterThan(0));
        }

        [Then]
        public void TableCellsShouldReturnAllChildren()
        {
            Assert.That(CurrentPage.Table.TableCells.Count(), Is.GreaterThan(0));
        }
    }
}