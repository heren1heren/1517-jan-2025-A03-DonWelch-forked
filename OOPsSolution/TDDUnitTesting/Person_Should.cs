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
        //check of the firstname to have characters (via the constructor)
        //firstname not null
        //firstname not empty string
        //firstname not blank string

        //the second test anontation used is called [Theory]
        //it will execute n number of times as a loop
        //n is determind by the number [InlineData()] anontations following the [Theory]
        //to setup the test header, you must include a parameter in a parameter list
        //  one for each, value in the InlineData set of values
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void Throw_Exception_Creating_Instance_Missing_First_Name(string testvalue)
        {
            //Arrange
            //possible values for FirstName: null, empty string, blank string
            //the setup of an exception test does not have to be as extensive as a successful test
            //  as the objective is to catch the exception that is thrown
            //for constructors, this means that the instance will never exist
            //in this example there will be no need to check expected values

            //Act
            //the act in this case is the capture of the exception that has been thrown
            //use () => to indicate that the following delegate is to be executed as the required code
            //the "action" variable here is the "subject under test"
            Action action = () => new Person(testvalue, "Welch", null, null);

            //Assert
            //test to see if the expected exception was thrown
            action.Should().Throw<ArgumentNullException>();
        }


        //check of the lastname to have characters (via the constructor)
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void Throw_Exception_Creating_Instance_Missing_Last_Name(string testvalue)
        {
            //Arrange
           

            //Act
            Action action = () => new Person("Don", testvalue, null, null);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null,"Welch")]
        [InlineData("", "Welch")]
        [InlineData("       ", "Welch")]
        [InlineData("Don", null)]
        [InlineData("Don", "")]
        [InlineData("Don", "     ")]
        public void Throw_Exception_Creating_Instance_Missing_Name_Component(string testFNvalue, string testLNvalue)
        {
            //Arrange


            //Act
            Action action = () => new Person(testFNvalue, testLNvalue, null, null);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion
        #endregion

        #region Properties
        #region Successful tests
        //directly change the first name (via property)
        [Fact]
        public void Change_First_Name_Via_Property()
        {
            //Arrange
            string expectedFirstName = "Bob";
            //Person sut = new Person();
            Person sut = new Person("Don", "Welch", null, null);

            //Act
            sut.FirstName = "Bob";

            //Assert
            sut.FirstName.Should().Be(expectedFirstName);
        }

        //directly change the last name (via property)
        //directly change the Address (via property : an address or null)
        //obtain the person's fullname using the existing instance data (last, first)
        #endregion
        #region Exception Tests
        //throw exception on missing first name (via property)
        //throw exception on missing last name (via property)
        //no employment should be added via the set property (rstrict set access)
        #endregion
        #endregion

        #region Methods
        #endregion
    }
}