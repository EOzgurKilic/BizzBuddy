using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Customers;
using BizBuddy.Domain.Entities.Orders;
using System.Collections.Generic;

namespace BizBuddy.Application.Customers.Queries.GetCustomerDetail;

public class CustomersDto : IMapFrom<Customer>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Tags { get; set; }
    public string? Notes { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }

    public ICollection<OrderSummaryDto>? Orders { get; set; }
    public ICollection<AppointmentSummaryDto>? Appointments { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, CustomersDto>()
               .ForMember(d => d.Orders, opt => opt.MapFrom(s => s.Orders))
               .ForMember(d => d.Appointments, opt => opt.MapFrom(s => s.Appointments))
               .ReverseMap();

        profile.CreateMap<Order, OrderSummaryDto>();

        profile.CreateMap<Appointment, AppointmentSummaryDto>();
    }
}

public class OrderSummaryDto
{
    public int Id { get; set; }
    public string Status { get; set; } 
}

public class AppointmentSummaryDto
{
    public int Id { get; set; }
    public string? Subject { get; set; } 
}