using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arby.dataclass
{
    public class MatchbookCredentials
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }

    public partial class Session
    {
        public string SessionToken { get; set; }
        public long UserId { get; set; }
        public string Role { get; set; }
        public Account Account { get; set; }
        public DateTimeOffset LastLogin { get; set; }
    }

    public partial class Account
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public long Balance { get; set; }
        public long Exposure { get; set; }
        public string Language { get; set; }
        public Address Address { get; set; }
        public string Currency { get; set; }
        public long Id { get; set; }
        public Name Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public long PhoneNumber { get; set; }
        public long FreeFunds { get; set; }
        public long CommissionCredit { get; set; }
        public string ForumHandle { get; set; }
        public long LanguageId { get; set; }
        public long CurrencyId { get; set; }
        public string OddsTypeId { get; set; }
        public string OddsType { get; set; }
        public bool BetConfirmation { get; set; }
        public bool DisplayPAndL { get; set; }
        public string ExchangeTypeId { get; set; }
        public string ExchangeType { get; set; }
        public bool OddsRounding { get; set; }
        public UserSecurityQuestion UserSecurityQuestion { get; set; }
        public bool BetSlipPinned { get; set; }
    }

    public partial class Address
    {
        public Country Country { get; set; }
        public long AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string RegionName { get; set; }
        public long PostCode { get; set; }
    }

    public partial class Country
    { 
       public long CountryId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }

    public partial class Name
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string TitleId { get; set; }
    }

    public partial class UserSecurityQuestion
    {
        public long UserSecurityQuestionId { get; set; }
        public Question Question { get; set; }
        public string Answer { get; set; }
    }

    public partial class Question
    {
        public long SecurityQuestionId { get; set; }
        public string SecurityQuestion { get; set; }
    }
}
