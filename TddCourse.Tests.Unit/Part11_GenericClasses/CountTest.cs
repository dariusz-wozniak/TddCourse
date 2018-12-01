using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace TddCourse.Tests.Unit.Part11_GenericClasses
{
    [TestFixture(typeof(ArrayList))]
    [TestFixture(typeof(List<int>))]
    [TestFixture(typeof(Collection<int>))]
    public class ListsTests<T> where T : IList, new()
    {
        [Test]
        public void CountTest()
        {
            var list = new T { 2, 3 };

            Assert.That(list, Has.Count.EqualTo(2));
        }
    }
}