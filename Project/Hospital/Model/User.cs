using System;

namespace Model
{
   public class User
   {
      public String Name { get; set; }
      public String Surname { get; set; }
      public int CitizenId { get; set; }
      public Gender Gender { get; set; }
      public DateTime DateOfBirth { get; set; }
      public String Email { get; set; }
      public String PhoneNumber { get; set; }
      
      public Address Address { get; set; }
   
   }
}