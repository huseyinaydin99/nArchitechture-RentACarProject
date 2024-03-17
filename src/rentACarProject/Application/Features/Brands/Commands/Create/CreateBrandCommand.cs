using Application.Features.Brands.Constants;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Brands.Constants.BrandsOperationClaims;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ISecuredRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, BrandsOperationClaims.Create];

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository,
                                         BrandBusinessRules brandBusinessRules)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = _mapper.Map<Brand>(request);

            await _brandRepository.AddAsync(brand);

            CreatedBrandResponse response = _mapper.Map<CreatedBrandResponse>(brand);
            return response;
        }
    }
}