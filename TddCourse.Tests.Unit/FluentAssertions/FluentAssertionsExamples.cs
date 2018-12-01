using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;

namespace TddCourse.Tests.Unit.FluentAssertions
{
    public class FluentAssertionsExamples
    {
        [Test]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        [SuppressMessage("ReSharper", "CommentTypo")]
        public void AllInOneExamples()
        {
            string firstName = "Jan";
            firstName.Should().Be("Jan");

            firstName = "Agnieszka";
            firstName.Should().StartWith("Ag").And.EndWith("a").And.Contain("szk");

            // Obiekty:
            string theObject = null;
            theObject.Should().BeNull();

            theObject = "sth";
            theObject.Should().NotBeNull();
            theObject.Should().BeOfType<string>();

            int? theInt = 5;
            theInt.Should().HaveValue(); // Nullable type

            // Boolean:
            bool theBoolean = true;
            theBoolean.Should().BeTrue();

            theBoolean = false;
            theBoolean.Should().BeFalse();

            // Stringi:
            string theString = " ";
            theString.Should().BeNullOrWhiteSpace();

            theString = "This is a string";
            theString.Should().Contain("is a");
            theString.Should().NotContain("is an");
            theString.Should().BeEquivalentTo("THIS IS A STRING"); // case insensitive
            theString.Should().StartWith("This");
            
            string emailAddress = "someone@somewhere.com";
            emailAddress.Should().Match("*@*.com"); // wildcards
            emailAddress.Should().MatchEquivalentOf("*@*.COM"); // case insensitive
            
            string someString = "hello world";
            someString.Should().MatchRegex("h.*world");

            // Typy numeryczne:
            int number = 6;
            number.Should().BeGreaterOrEqualTo(5);
            number.Should().BeGreaterThan(4);
            number.Should().BeLessOrEqualTo(7);
            number.Should().BeLessThan(68);
            number.Should().BePositive();
            number.Should().Be(6);
            number.Should().NotBe(10);
            number.Should().BeInRange(1, 10);

            // Daty:
            DateTime theDatetime = new DateTime(year: 2010, month: 3, day: 1, hour: 22, minute: 15, second: 0);
            theDatetime.Should().BeAfter(1.February(2010));
            theDatetime.Should().BeBefore(2.March(2010));
            theDatetime.Should().BeOnOrAfter(1.March(2010));
            theDatetime.Should().Be(1.March(2010).At(22, 15));
            theDatetime.Should().NotBe(1.March(2010).At(22, 16));
            theDatetime.Should().HaveDay(1);
            theDatetime.Should().HaveMonth(3);
            theDatetime.Should().HaveYear(2010);
            theDatetime.Should().HaveHour(22);
            theDatetime.Should().HaveMinute(15);
            theDatetime.Should().HaveSecond(0);

            // Kolekcje:
            var collection = new []{2, 5, 3};
            collection.Should().NotBeEmpty()
                .And.HaveCount(3)
                .And.ContainInOrder(new[] {2, 5});

            collection.Should().HaveCount(3);
            collection.Should().ContainSingle(x => x == 3);
            collection.Should().NotContain(x => x > 10);
            collection.Should().NotContainNulls();
            collection.Should().NotBeEmpty();
            collection.Should().NotBeNullOrEmpty();
            collection.Should().IntersectWith(new[] {5});

            // Wyjątki:
            Action act = () => throw new NotImplementedException();
            act.Should().Throw<NotImplementedException>();
        }
    }
}
