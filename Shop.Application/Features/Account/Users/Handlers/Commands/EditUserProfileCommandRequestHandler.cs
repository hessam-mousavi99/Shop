using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Extentions;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Application.Utils;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Account.Users.Handlers.Commands
{
    internal class EditUserProfileCommandRequestHandler : IRequestHandler<EditUserProfileCommandRequest, EditUserProfileResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public EditUserProfileCommandRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<EditUserProfileResult> Handle(EditUserProfileCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            
            if (user == null) { return EditUserProfileResult.NotFound; }

            user.FirstName=request.EditUserProfileDto.FirstName;
            user.LastName=request.EditUserProfileDto.LastName;
            user.Gender = request.EditUserProfileDto.UserGender;
            if (request.UserAvatar!=null && request.UserAvatar.IsImage())
            {
                var imageName=Guid.NewGuid().ToString("N")+Path.GetExtension(request.UserAvatar.FileName);
                request.UserAvatar.AddImageToServer(imageName, PathExtensions.UserAvatarOrginServer, 150, 150, PathExtensions.UserAvatarThumbServer);
                user.Avatar = imageName;
            }
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
            return EditUserProfileResult.Success;
        }
    }
}
