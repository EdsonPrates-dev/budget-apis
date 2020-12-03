using CSharpFunctionalExtensions;

namespace TestBudget.User
{
    public static class UserStub
    {
        public static Result<Orcamento.Api.Models.User.User> _1StubUserOk()
        {
            return new Orcamento.Api.Models.User.User
            {
                IdContractor = 1,
                IdUser = 3,
                Login = "user.user",
                Password = "user123"
            };
        }
    }
}
