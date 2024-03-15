using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace Test
{
    public class PersonTest
    {
        public Person _person;

        public Mock<IPersonHandler> _persomock;

        public PersonTest()
        {
            _persomock = new Mock<IPersonHandler>();   
        }

        [Fact]
        public void Person_WhenTheIsCreatedSuccessfully_ThentheDataIsCorrect()
        {
            //Arrange
            const string nom = "imad";
            const string prenom = "ettamen";
            const int age = 22;

            // ACT 
            _person = new(nom, prenom, age, _persomock.Object);

            //Assert
            Assert.IsNotNull(_person);
            Assert.Equals(age, _person.Age);
            Assert.Equals(prenom, _person.Prenom);
            Assert.Equals(nom, _person.Nom);
        }

        // test la methode
        // les methodes de test tjr void
        [Fact]
        public void GetFullNam_WhenTheFullNameIsNotEmptye()
        {

            //Arrange
            const string nom = "imad";
            const string prenom = "ettamen";
            const int age = 22;
            _person = new(nom, prenom, age, _persomock.Object);

            //Action
           var result = _person.GetFullName();

            //Assert
            Assert.IsNotNull(result);
            Assert.Equals($"{nom} {prenom} {age}", result);

        }


        [Theory]
        [InlineData(20)]
        [InlineData(16)]
        [InlineData(0)]
        [Fact]
        public void IsMajeur_WhenThePersonIsMajor_YhenRetournTrue(int age)
        {
            // Arrange

            //Action
            var isMajeur = Person.IsMajeur(age);


            // Assert
            if (age >= 18)
            {
                Assert.IsTrue(isMajeur);
            }
            else
            {
                Assert.IsFalse(isMajeur);
            }
          

        }


        [Fact]
        public void CreatePerson_WhenTheCreationIsSuccessfully_ThenretournTrue()
        {
            // Arrange
            const string nom = "imad";
            const string prenom = "ettamen";
            const int age = 22;
            var personToCreate = new Person(nom, prenom, age, _persomock.Object);

            //Action
            _persomock.Setup(x => x.CreatePerson(It.IsAny<Person>())).Returns(true);
        }




        [Fact]
        public void IsMajeur_WhenThePersonIsMajor_YhenRetournTrue()
        {
            // Arrange
            const int age = 20;

            //Action
            var isMajeur = Person.IsMajeur(age);

            // Assert
            Assert.IsFalse(isMajeur);
        }


        [Fact]
        public void IsMinor_WhenThePersonIsMinor_YhenRetournTrue()
        {
            // Arrange
            const int age = 15;

            //Action
            var isMajeur = Person.IsMajeur(age);

            // Assert
            Assert.IsFalse(isMajeur);
        }

        [Fact]
        public void IsMajeur_WhenThePersonAgeIsInvalide_YhenRetournTrue()
        {
            // Arrange
            const int age = 0;

            //Action
            var isMajeur = Person.IsMajeur(age);

            // Assert
            Assert.IsFalse(isMajeur);
        }
    }
}


public class Person
{
    public Guid Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public int Age { get; set; }

    // probleme here :
    public IPersonHandler personHandler;

    public Person(string nom, string prenom, int age, IPersonHandler personHandler)
    {
        Id = Guid.NewGuid();
        Nom = nom;
        Prenom = prenom;
        Age = age;
        this.personHandler = personHandler;
    }

    // full  name
    public string GetFullName()
    {
        return $"{Nom} {Prenom} {Id}";
    }

    // majeur

    public static bool IsMajeur(int age)
    {
        if (age > 0)
        {
            return age >= 18 ? true : false;
        }

        return false;
    }


    public static bool CreatePerson(Person person)
    {
       //   return pe
    }

}
