using System;
using AutoMapper;

namespace BizBuddy.Application.Mapping;


public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap().PreserveReferences().MaxDepth(2);
}
