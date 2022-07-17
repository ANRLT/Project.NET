using Modsen.App.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.API.Services
{
    public class TourService : ITourService //если оставить класс пустым, то пишет 'TourService' does not implement
                                            //interface member 'ITourService.(Название метода)()'
    {
        public Task<TourDto> GetAsync(int id)
        {
            return default; //что сюда писать я не знаю, поэтому return default. Аналогично ниже
        }

        public Task AddAsync(TourDto tourtDto)
        {
            return default;
        }

        public Task UpdateAsync(TourDto tourtDto)
        {
            return default;
        }

        public Task DeleteAsync(int id)
        {
            return default;
        }

        Task<IEnumerable<TourShortDto>> ITourService.GetQueueAsync(int pageNumber, int pageSize)
        {
            return default;
        }

    }
}