using NUnit.Framework;
using CitySearch;
using System.Collections.Generic;

namespace CitySearchTests
{
    public class Tests
    {
        private ISearchEngine _search;

        [SetUp]
        public void Setup()
        {
            _search = new CitySearchEngine();
        }

        [Test]
        public void TestQueryTooShort()
        {
            Assert.IsEmpty(_search.Search(""));
            Assert.IsEmpty(_search.Search(" "));
            Assert.IsEmpty(_search.Search("V"));
            Assert.IsEmpty(_search.Search("/"));
        }
        [Test]
        public void TestQueryStartMatch()
        {
            var result1 = _search.Search("Va");
            var result2 = _search.Search("va");
            var result3 = _search.Search("vA");
            var expected = new List<string>
            {
                "Valencia",
                "Vancouver"
            };
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
            Assert.AreEqual(expected, result3);
        }
        [Test]
        public void TestQueryMiddleMatch()
        {
            var result1 = _search.Search("ape");
            var result2 = _search.Search("APE");
            var result3 = _search.Search("aPE");
            var expected = new List<string>
            {
                "Budapest"
            };
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
            Assert.AreEqual(expected, result3);
        }
        [Test]
        public void TestQuerySpaces1()
        {
            var result1 = _search.Search("g ");
            var result2 = _search.Search(" K");
            var expected = new List<string>
            {
                "Hong Kong"
            };
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
        }
        [Test]
        public void TestQueryWildcard()
        {
            var result = _search.Search("*");
            var expected = new List<string>(CitySearchEngine.cityString.Split(", "));
            Assert.AreEqual(expected, result);
        }
    }
}