using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Orders;

namespace BizBuddy.Application.Orders.Queries.GetAppointmentWithPagination;

public class AppointmentListDto: IMapFrom<Appointment>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = default!;

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public string Status { get; set; } = default!;
    public string? Notes { get; set; }
    public string? Custom { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Appointment, AppointmentListDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));
    }
}