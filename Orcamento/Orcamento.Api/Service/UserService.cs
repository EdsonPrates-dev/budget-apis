using CSharpFunctionalExtensions;
using Orcamento.Api.DTO.User;
using Orcamento.Api.Models.User;
using Orcamento.Api.Service.MapperDTO;
using System.Threading.Tasks;

namespace Orcamento.Api.Service
{
    public class UserService : IUserService
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(AutoMapper.IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task CreateLoginFromContractor(User user, string cpfContractor) =>
            await _userRepository.CreateLoginFromContractor(user, cpfContractor);

        public async Task<Result<UserDTO>> GetUser(User user)
        {
            var result = await _userRepository.GetUser(user);

            if (result.IsFailure)
                return Result.Failure<UserDTO>(result.Error);

            return Mapper.Map(result.Value, _mapper);
        }
    }
}
