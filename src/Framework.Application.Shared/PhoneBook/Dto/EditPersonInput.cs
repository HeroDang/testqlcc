using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.PhoneBook.Dto
{
    public class EditPersonInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
    }

    public class GetPersonForEditOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
    }

    public class GetPersonForEditInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
    }
}
