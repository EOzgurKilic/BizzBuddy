using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Customers;
using BizBuddy.Domain.Entities.Orders;

namespace BizBuddy.Application.Customers.Queries.GetCustomersWithPagination;

public class GetCustomerListDto : IMapFrom<Customer>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Tags { get; set; }
    public string? Notes { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }

    public ICollection<OrderSummaryDtos>? Orders { get; set; }
    public ICollection<AppointmentSummaryDtos>? Appointments { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, GetCustomerListDto>()
               .ForMember(d => d.Orders, opt => opt.MapFrom(s => s.Orders))
               .ForMember(d => d.Appointments, opt => opt.MapFrom(s => s.Appointments))
               .ReverseMap();

        profile.CreateMap<Order, OrderSummaryDtos>();

        profile.CreateMap<Appointment, AppointmentSummaryDtos>();
    }
}

public class OrderSummaryDtos
{
    public int Id { get; set; }
    public string Status { get; set; }
}

public class AppointmentSummaryDtos
{
    public int Id { get; set; }
    public string? Subject { get; set; }
}

