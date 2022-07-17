using System;
using System.Collections.Generic;

namespace Modsen.App.Core.Models.Dto;

public class TourDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public virtual TourTypeDto TourType { get; set; }
    public virtual TransportDto Transport { get; set; }
}