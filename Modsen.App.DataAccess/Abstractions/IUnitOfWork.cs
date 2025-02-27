﻿using Modsen.App.DataAccess.Repositories;

namespace Modsen.App.DataAccess.Abstractions;

public interface IUnitOfWork
{
    BookingRepository BookingRepository { get; }
    ITourRepository TourRepository { get; }
    ITourTypeRepository TourTypeRepository { get; } 
    ITransportRepository TransportRepository { get; }
}