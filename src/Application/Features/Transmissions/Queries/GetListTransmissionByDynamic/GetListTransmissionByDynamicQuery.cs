using Application.Features.Transmissions.Models;
using Application.Requests;
using Application.Services.Repositories;
using AutoMapper;
using Core.Dynamic;
using Core.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Queries.GetListTransmissionByDynamic;

public class GetListTransmissionByDynamicQuery : IRequest<TransmissionListModel>
{
    public Dynamic Dynamic {  get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListTransmissionByDynamicQueryHandler : IRequestHandler<GetListTransmissionByDynamicQuery, TransmissionListModel>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetListTransmissionByDynamicQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<TransmissionListModel> Handle(GetListTransmissionByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Transmission> transmissions = await _transmissionRepository
                .GetListByDynamicAsync(request.Dynamic,
                                       include: t => t.Include(t => t.Models),
                                       index: request.PageRequest.Page,
                                       size: request.PageRequest.PageSize);

            TransmissionListModel mappedTransmissionListModel = _mapper.Map<TransmissionListModel>(transmissions);

            return mappedTransmissionListModel; 
        }
    }
}
