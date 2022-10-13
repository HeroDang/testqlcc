using Framework.PhoneBook.Dto;
using Framework.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Abp.Runtime.Validation;

namespace Framework.Tests.PhoneBook
{
    public class PersonAppService_Tests : AppTestBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonAppService_Tests()
        {
            _personAppService = Resolve<IPersonAppService>();
        }

        [Fact]
        public void Should_Get_All_People_Without_Any_Filter()
        {
            //Act
            var persons = _personAppService.GetPeople(new GetPeopleInput());

            //Assert
            persons.Items.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Create_Person_With_Valid_Arguments()
        {
            //Act
            await _personAppService.CreatePerson(
                new CreatePersonInput
                {
                    Name = "John",
                    Surname = "Nash",
                    EmailAddress = "john.nash@abeautifulmind.com"
                });

            //Assert
            UsingDbContext(
                context =>
                {
                    var john = context.Persons.FirstOrDefault(p => p.EmailAddress == "john.nash@abeautifulmind.com");
                    john.ShouldNotBe(null);
                    john.Name.ShouldBe("John");
                });
        }

        [Fact]
        public async Task Should_Not_Create_Person_With_Invalid_Arguments()
        {
            //Act and Assert
            await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _personAppService.CreatePerson(
                new CreatePersonInput
                                {
                                    Name = "John"
                                });
                });
        }


    }
}
