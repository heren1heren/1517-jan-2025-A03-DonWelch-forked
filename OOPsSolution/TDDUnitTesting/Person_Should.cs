using OOPsReview;
using FluentAssertions;

namespace TDDUnitTesting
{
    public class Person_Should
    {
        #region Constructors
        #region Successful
        //the [Fact] unit test executes once
        //without the [Fact] annotation, the method is NOT considered a unit test
        [Fact]
        public void Successfully_Create_An_Instance_Using_The_Default_Constructor()
        {
            //Arrange (this is the setup of values needed for doing the test)
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";
            int expectedEmploymentPositionsCount = 0;

            //Act (this is the action that is under testing)
            //sut (subject under test)
            Person sut = new Person();

            //Assert (checks the results of the Act against expected values
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentPositionsCount);

        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_Greedy_Constructor_No_Address_Employment()
        {
            //Arrange (this is the setup of values needed for doing the test)
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            int expectedEmploymentPositionsCount = 0;

            //Act (this is the action that is under testing)
            //sut (subject under test)
            Person sut = new Person("Don","Welch",null,null);

            //Assert (checks the results of the Act against expected values
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentPositionsCount);
        }

        [Fact]
        public void Successfully_Create_An_Instance_Using_Greedy_Constructor_With_Address_Employment()
        {
            //Arrange (this is the setup of values needed for doing the test)
            string expectedFirstName = "Don";
            string expectedLastName = "Welch";
            ResidentAddress expectedAddress = new ResidentAddress(123, "Maple St,",
                                        "Edmonton", "AB", "T6Y8U9");
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember,
                                                DateTime.Parse("2013/10/10"), 6.5);
            Employment two = new Employment("PG II", SupervisoryLevel.TeamMember,
                                               DateTime.Parse("2020/04/10"));
            List<Employment> expectedEmployments = new List<Employment>();
            expectedEmployments.Add(one);
            expectedEmployments.Add(two);
            int expectedEmploymentPositionsCount = 2;

            //Act (this is the action that is under testing)
            //sut (subject under test)
            Person sut = new Person("Don", "Welch", expectedAddress, expectedEmployments);

            //Assert (checks the results of the Act against expected values
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAddress);
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentPositionsCount);
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedEmployments);
        }
        #endregion
        #region Exception Testing
        #endregion
        #endregion

        #region Properties
        #endregion

        #region Methods
        #endregion
    }
}