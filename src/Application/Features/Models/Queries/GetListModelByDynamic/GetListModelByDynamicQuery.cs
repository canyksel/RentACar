﻿using Application.Features.Models.Models;
using Application.Requests;
using Application.Services.Repositories;
using AutoMapper;
using Core.Dynamic;
using Core.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModelByDynamic;

public class GetListModelByDynamicQuery : IRequest<ModelListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepository;

        public GetListModelByDynamicQueryHandler(IMapper mapper, IModelRepository modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }

        public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, include:
                                        m => m.Include(c => c.Brand),
                                        index: request.PageRequest.Page,
                                        size: request.PageRequest.PageSize
                                        );
            ModelListModel mappedModels = _mapper.Map<ModelListModel>(models);
            return mappedModels;
        }
    }
}
