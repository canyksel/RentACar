﻿using Application.Features.Users.Models;
using Application.Requests;
using Application.Services.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetListUser;

public class GetListUserQuery : IRequest<UserListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);

            return mappedUserListModel;
        }
    }
}