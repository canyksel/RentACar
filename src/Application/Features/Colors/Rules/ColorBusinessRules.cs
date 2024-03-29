using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.CrossCuttingConcerns.Rules;
using Core.Paging;
using Domain.Entities;

namespace Application.Features.Colors.Rules
{
    public class ColorBusinessRules : BusinessRules<Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorBusinessRules(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task ColorNameCannotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Color> result = await _colorRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Color name exists.");
        }

        public void ColorShouldExistsWhenRequested(Color color)
        {
            if (color is null) throw new BusinessException("Color does not exists.");
        }
    }
}
