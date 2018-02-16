namespace Iyzpay.NetCore.Model
{
    public class Buyer : IRequestStringConvertible
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string GsmNumber { get; set; }
        public string RegistrationDate { get; set; }
        public string LastLoginDate { get; set; }
        public string RegistrationAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Ip { get; set; }

        public string ToPkiRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .Append("id", Id)
                .Append("name", Name)
                .Append("surname", Surname)
                .Append("identityNumber", IdentityNumber)
                .Append("email", Email)
                .Append("gsmNumber", GsmNumber)
                .Append("registrationDate", RegistrationDate)
                .Append("lastLoginDate", LastLoginDate)
                .Append("registrationAddress", RegistrationAddress)
                .Append("city", City)
                .Append("country", Country)
                .Append("zipCode", ZipCode)
                .Append("ip", Ip)
                .GetRequestString();
        }
    }
}