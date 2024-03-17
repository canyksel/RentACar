using Application.Features.Colors.Dtos;
using Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Models;

public class ColorListModel
{
    public IList<ColorListDto> Items { get; set; }
}
